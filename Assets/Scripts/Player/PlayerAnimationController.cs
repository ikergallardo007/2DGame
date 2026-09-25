using UnityEngine;

[RequireComponent(
    typeof(Animator),
    typeof(PlayerStateController),
    typeof(SpriteRenderer)
)]
public class PlayerAnimationController : MonoBehaviour
{
    private static readonly int JumpingHash = Animator.StringToHash("Jumping");
    private static readonly int FlyingHash = Animator.StringToHash("Flying");
    private static readonly int WalkingHash = Animator.StringToHash("Walking");
    private static readonly int LandingHash = Animator.StringToHash("Landing");
    private static readonly int ExcitedHash = Animator.StringToHash("Excite");
    private static readonly int DamagedHash = Animator.StringToHash("Damaged");
    private static readonly int RightAuraHash = Animator.StringToHash("Right");
    private static readonly int DigimonHash = Animator.StringToHash("Digimon");
    #region Constants
    #endregion

    #region Properties

    #endregion

    #region Fields
    [SerializeField] private GameObject _aura;
    private Animator _anim;
    private Animator _auraAnim;
    private PlayerStateController _playerState;
    private SpriteRenderer _spriteRenderer;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerState = GetComponent<PlayerStateController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _auraAnim = _aura.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_playerState.DigimonIndex == 1)
            _spriteRenderer.flipX = !_playerState.LookRight;
        else
            _spriteRenderer.flipX = _playerState.LookRight;
        _anim.SetBool(WalkingHash, _playerState.Walking);
        _anim.SetInteger(DigimonHash, _playerState.DigimonIndex);
        if (_playerState.Jumping)
        {
            PlayJumpAnimation();
            _playerState.Jumping = false;
        }
        _anim.SetBool(FlyingHash, _playerState.Flying);
        if (_playerState.Landing)
        {
            PlayLandAnimation();
            _playerState.Landing = false;
        }
        if (_playerState.Excited)
        {
            PlayExcitedAnimation();
            _playerState.Excited = false;
        }
        if (_playerState.Damaged)
        {
            PlayDamagedAnimation();
            _playerState.Damaged = false;
        }
        if(_aura.activeSelf != _playerState.Charging)
        {
            _aura.SetActive(_playerState.Charging);
        }

        _auraAnim.enabled = _playerState.Charging;

        if (_playerState.Charging)
        {
            _auraAnim.SetBool(RightAuraHash, _playerState.LookRight);
            _auraAnim.SetInteger(DigimonHash, _playerState.DigimonIndex);
        }
    }

    #endregion

    #region Public Methods


    #endregion

    #region Private Methods
    private void PlayJumpAnimation()
    {
        _anim.SetTrigger(JumpingHash);
    }

    private void PlayLandAnimation()
    {
        _anim.SetTrigger(LandingHash);
    }
    private void PlayExcitedAnimation()
    {
        _anim.SetTrigger(ExcitedHash);
    }
    private void PlayDamagedAnimation()
    {
        _anim.SetTrigger(DamagedHash);
    }

    #endregion
}
