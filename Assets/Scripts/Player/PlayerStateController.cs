using UnityEngine;

[RequireComponent(
    typeof(Jetpack)
    )]
public class PlayerStateController : MonoBehaviour
{
    #region Properties
    public bool Flying 
    {
        get => _flying;
        set => _flying = value;
    }
    public bool OnAir
    {
        get => _onAir;
        set => _onAir = value;
    }
    public bool Grounded
    {
        get => _grounded;
        set => _grounded = value;
    }
    public bool Landing
    {
        get => _landing;
        set => _landing = value;
    }
    public bool Walking
    {
        get => _walking;
        set => _walking = value;
    }
    public bool Jumping
    {
        get => _jumping;
        set => _jumping = value;
    }
    public bool LookRight
    {
        get => _lookRight;
        set => _lookRight = value;
    }
    public bool EmptyTank
    {
        get => _emptyTank;
        set => _emptyTank = value;
    }

    public bool Excited
    {
        get => _excited;
        set => _excited = value;
    }

    public bool Invulnerable
    {
        get => _invulnerable;
        set => _invulnerable = value;
    }
    public bool Damaged
    {
        get => _damaged;
        set => _damaged = value;
    }
    public bool Charging
    {
        get => _charging;
        set => _charging = value;
    }

    public bool HasDigivice
    {
        get => _hasDigivice;
        set => _hasDigivice = value;
    }
    public bool HasCourageEmblem
    {
        get => _hasCourageEmblem;
        set => _hasCourageEmblem = value;
    }
    public bool HasCourageCircuit
    {
        get => _hasCourageCircuit;
        set => _hasCourageCircuit = value;
    }
    public bool HasCourageDigivice
    {
        get => _hasCourageDigivice;
        set => _hasCourageDigivice = value;
    }
    public int DigimonIndex
    {
        get => _digimonIndex;
        set => _digimonIndex = value;
    }

    #endregion

    #region Fields
    [SerializeField] private int _digimonIndex = 0;
    [SerializeField] private bool _flying = false;
    [SerializeField] private bool _onAir = false;
    [SerializeField] private bool _grounded = true;
    [SerializeField] private bool _landing = false;
    [SerializeField] private bool _walking = false;
    [SerializeField] private bool _jumping = false;
    [SerializeField] private bool _lookRight = false;
    [SerializeField] private bool _emptyTank = false;
    [SerializeField] private bool _excited = false;
    [SerializeField] private bool _invulnerable = false;
    [SerializeField] private bool _damaged = false;
    [SerializeField] private bool _charging = false;
    [SerializeField] private bool _hasDigivice = false;
    [SerializeField] private bool _hasCourageEmblem = false;
    [SerializeField] private bool _hasCourageCircuit = false;
    [SerializeField] private bool _hasCourageDigivice = false;
    private float _invulnerableTime = 0;
    private float _invulnerableTotal = -1f;
    private Jetpack _jetpack;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _jetpack = GetComponent<Jetpack>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Energia vacia.
        if(_jetpack.Energy > 0)
        {
            EmptyTank = false;
        }
        else
        {
            EmptyTank = true;
        }

        // Invulnerabilidad
        if (_invulnerableTime < _invulnerableTotal)
        {
            _invulnerableTime += Time.deltaTime;
            _invulnerable = true;
        }
        else
        {
            _invulnerable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer") ||
            collision.gameObject.CompareTag("Platform"))
        {
            Flying = false;
            OnAir = false;
            if (!Grounded)
               Landing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer") ||
            collision.gameObject.CompareTag("Platform"))
        {
            Grounded = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer") ||
            collision.gameObject.CompareTag ("Platform"))
        {
            OnAir = true;
            Grounded = false;
            _charging = false;
        }
    }
    #endregion

    #region Public Methods
    public void SetInvulnerability(float seconds)
    {
        _invulnerableTime = 0;
        _invulnerableTotal = seconds;
    }
    #endregion

    #region Private Methods

    #endregion
}
