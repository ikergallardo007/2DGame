using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(
    typeof(Rigidbody2D), 
    typeof(Jetpack),
    typeof(PlayerStateController)
    )]
public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _horizontalForce = 20f;
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private float _flyForce = 15f;
    [SerializeField] private float _flyDelay = 0.2f;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    
    private float _spaceTime;
    
    private Rigidbody2D _rigidbody;
    private Jetpack _jetpack;
    private PlayerStateController _playerState;
    private PlayerInput _playerInput;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jetpack = GetComponent<Jetpack>();
        _playerState = GetComponent<PlayerStateController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        if (_playerInput == null || _playerInput.actions == null)
        {
            Debug.LogError("PlayerInput o Input Actions no configurado.", this);
            return;
        }

        var playerMap = _playerInput.actions.FindActionMap("Player", true);

        _moveAction = playerMap.FindAction("Move", true);
        _jumpAction = playerMap.FindAction("Jump", true);

        playerMap.Enable();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log(
                $"Move enabled: {_moveAction != null && _moveAction.enabled} | " +
                $"Jump enabled: {_jumpAction != null && _jumpAction.enabled}"
                );
        }
    }

    // FixedUpdate is called once per physics frame
    private void FixedUpdate()
    {
        if (_moveAction == null || _jumpAction == null ||
            !_moveAction.enabled || !_jumpAction.enabled)
        {
            return;
        }

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
        if (_jumpAction.WasPressedThisFrame() &&
            _playerState.Grounded)
        {
            Vector2 jumpMovement = new(0, _jumpForce);
            _rigidbody.AddForce(jumpMovement);
            _spaceTime = 0;
            _playerState.Jumping = true;
        }

        // Fly
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
        else
        {
            _spaceTime = 0;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
