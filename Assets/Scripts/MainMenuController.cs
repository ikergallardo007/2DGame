using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] Button _startGamenButton;
    [SerializeField] Button _exitGamenButton;
    #endregion

    #region Unity Callbacks
    // Awake Method
    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _startGamenButton.onClick.AddListener(StartGame);
        _exitGamenButton.onClick.AddListener(ExitGame);
    }


    // Update is called once per frame
    private void Update()
    {
        
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    #endregion
}
