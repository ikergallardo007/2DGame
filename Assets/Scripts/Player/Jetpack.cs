using System;
using UnityEngine;

[RequireComponent(
    typeof(Transform),
    typeof(Rigidbody2D),
    typeof(PlayerStateController)
 )]
public class Jetpack : MonoBehaviour
{
    #region Properties
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    public float MaxEnergy
    {
        get
        {
            return _maxEnergy;
        }
        set
        {
            _maxEnergy = value;
        }
    }
    public enum Direction
    {
        Left,
        Right
    }
    #endregion

    #region Fields
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy = 100f;
    [SerializeField] private float _energyFlyingRatio = 0.1f;
    [SerializeField] private float _energyRegenerationRatio = 0.5f;
    [SerializeField] private float _energyRegenerationDelay = 0.5f;
    private float _energyRegenerationTime;

    private Transform _transform;
    private Rigidbody2D _rb2d;
    private PlayerStateController _playerState;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rb2d = GetComponent<Rigidbody2D>();
        _playerState = GetComponent<PlayerStateController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Energy = _maxEnergy;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_playerState.Landing)
        {
            _energyRegenerationTime = 0;
        }
        if (_playerState.Grounded)
        {
            _energyRegenerationTime += Time.deltaTime;
            if ((_energyRegenerationTime > _energyRegenerationDelay) && 
                (Energy < _maxEnergy))
            {
                _playerState.Charging = true;
                Regenerate();
            }
            else
            {
                _playerState.Charging = false;
            }
        }
    }

    #endregion

    #region Public Methods
    public void Regenerate()
    {
        Energy += _energyRegenerationRatio;
    }

    public void Regenerate(float energy)
    {
        Energy += energy;
    }

    public void Invulnerability(float seconds)
    {
        _playerState.SetInvulnerability(seconds);
    }
    #endregion

    #region Private Methods
    public void Fly()
    {
        if (!_playerState.EmptyTank && !_playerState.Invulnerable)
        {
            Energy -= _energyFlyingRatio;
        }
    }
    public void UpdateMaxEnergy(float newEnergy)
    {
        Debug.Log("Updating max energy...");
        _maxEnergy = newEnergy;
    }

    #endregion
}
