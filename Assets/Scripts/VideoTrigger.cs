using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTrigger : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private CapsuleCollider2D _playerCollider;
    [SerializeField] private Vector2 _colliderOffset;
    [SerializeField] private Vector2 _colliderSize;
    [SerializeField] private CapsuleDirection2D _colliderDirection;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _videoImage;
    [SerializeField] private PlayerStateController _playerState;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private VideoClip _clip;
    [SerializeField] private RenderTexture _renderTexture;
    [SerializeField] private Jetpack _jetpack;
    private RawImage _rawImage;
    private bool _hasPlayed = false;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {
        _rawImage = _videoImage.GetComponent<RawImage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hasPlayed)
            return;

        if (!collision.CompareTag("Player"))
            return;

        PlayerStateController state = collision.GetComponent<PlayerStateController>();

        switch (state.DigimonIndex)
        {
            case 0:
                {
                    Debug.Log("Koromon Digievolution");
                    state.HasDigivice = false;
                    _jetpack.UpdateMaxEnergy(100f);
                    _jetpack.UpdateEnergyRegeneration(0.6f);
                    break;
                }
            case 1:
                {
                    Debug.Log("Agumon Digievolution");
                    state.HasCourageEmblem = false;
                    _jetpack.UpdateMaxEnergy(130f);
                    _jetpack.UpdateEnergyRegeneration(0.7f);
                    break;
                }
            case 2:
                {
                    state.HasCourageCircuit = false;
                    _jetpack.UpdateMaxEnergy(180f);
                    _jetpack.UpdateEnergyRegeneration(0.85f);
                    break;
                }
            case 3:
                {
                    state.HasCourageDigivice = false;
                    _jetpack.UpdateMaxEnergy(250f);
                    _jetpack.UpdateEnergyRegeneration(1f);
                    break;
                }
            case 4:
                {
                    state.HasDigivice = false;
                    state.HasCourageEmblem = false;
                    state.HasCourageCircuit = false;
                    state.HasCourageDigivice = false;
                    break;
                }
        }
        _videoPlayer.clip = _clip;
        _videoPlayer.targetTexture = _renderTexture;
        _rawImage.texture = _renderTexture;
        _hasPlayed = true;
        PlayVideo();
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void PlayVideo()
    {
        // Activar el video
        _videoImage.SetActive(true);

        // Pausar el juego
        Time.timeScale = 0f;

        // Pausar música del juego
        _audioSource.Pause();

        // Reproducir el video
        _videoPlayer.Play();

        // Esperar a que termine
        _videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer player)
    {
        // Dejar de escuchar el evento
        _videoPlayer.loopPointReached -= OnVideoFinished;

        // Digievolucionar
        _playerState.DigimonIndex += 1;

        // Actualizar tamaño del collider
        UpdatePlayerCollider();

        // Ocultar el video
        _videoImage.SetActive(false);

        // Reanudar música del juego
        _audioSource.UnPause();

        // Reanudar el juego
        Time.timeScale = 1.0f;

        // En el final del juego.
        if (_playerState.DigimonIndex > 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void UpdatePlayerCollider()
    {
        _playerCollider.size = _colliderSize;
        _playerCollider.offset = _colliderOffset;
        _playerCollider.direction = _colliderDirection;
    }
    #endregion
}
