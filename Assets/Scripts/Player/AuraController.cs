using UnityEngine;

public class AuraController : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private PlayerStateController _playerState;
    [SerializeField] private Animator _animator;
    private int _lastDigimonIndex = -1;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        UpdateDigimon();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateDigimon();
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void UpdateDigimon()
    {
        if (_playerState == null || _animator == null)
            return;

        if (_lastDigimonIndex == _playerState.DigimonIndex)
            return;

        _lastDigimonIndex = _playerState.DigimonIndex;
        _animator.SetInteger("Digimon", _lastDigimonIndex);
    }
    #endregion
}
