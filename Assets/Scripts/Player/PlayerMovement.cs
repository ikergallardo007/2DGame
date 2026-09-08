using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(
    typeof(Rigidbody2D), 
    typeof(Jetpack),
    typeof(PlayerStateController)
    )]
public class PlayerMovement : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private float _horizontalForce = 20f;
    private InputAction _moveAction;
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private float _flyForce = 15f;
    private InputAction _jumpAction;
    [SerializeField] private float _flyDelay = 0.2f;
    private float _spaceTime;
    private Rigidbody2D _rigidbody;
    private Jetpack _jetpack;
    private PlayerStateController _playerState;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jetpack = GetComponent<Jetpack>();
        _playerState = GetComponent<PlayerStateController>();
    }

    // Start method
    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // FixedUpdate is called once per physics frame
    private void FixedUpdate()
    {
        // Horizontal movement
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        Vector2 horizontalMovement = new(moveValue.x, 0);
        _rigidbody.AddForce(horizontalMovement * _horizontalForce);
        
        if (moveValue.x < 0 && !_playerState.OnAir)
        {
            _playerState.LookRight = false;
            _playerState.Walking = true;
        }
        else if (moveValue.x > 0 && !_playerState.OnAir)
        {
            _playerState.LookRight = true;
            _playerState.Walking = true;
        }
        else
        {
            _playerState.Walking = false;
        }
     
        // Jump
        if (_jumpAction.triggered &&
            _playerState.Grounded)
        {
            Vector2 jumpMovement = new(0, _jumpForce);
            _rigidbody.AddForce(jumpMovement);
            _spaceTime = 0;
            _playerState.Jumping = true;
        }

        if (_jumpAction.IsPressed())
        {
            _spaceTime += Time.fixedDeltaTime;
            if ((_spaceTime > _flyDelay) &&
                _playerState.OnAir &&
                !_playerState.EmptyTank)
            {
                _jetpack.Fly();
                Vector2 flyMovement = new(0, _flyForce);
                _rigidbody.AddForce(flyMovement);
                _playerState.Flying = true;
            }
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
