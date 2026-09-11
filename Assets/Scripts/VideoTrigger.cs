using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _videoImage;
    private bool _hasPlayed = false;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {

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

        _hasPlayed = true;
        PlayerStateController state = collision.GetComponent<PlayerStateController>();
        state.HasDigivice = false;
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

        // Reproducir el video
        _videoPlayer.Play();

        // Esperar a que termine
        _videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer player)
    {
        // Dejar de escuchar el evento
        _videoPlayer.loopPointReached -= OnVideoFinished;

        // Ocultar el video
        _videoImage.SetActive(false);

        // Reanudar el juego
        Time.timeScale = 1.0f;
    }
    #endregion
}
