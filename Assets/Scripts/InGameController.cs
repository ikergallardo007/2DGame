using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{

    #region Fields
    private InputAction _escapeAction;

    #endregion

    #region Unity Callbacks
    // Start method
    private void Start()
    {
        _escapeAction = InputSystem.actions.FindAction("Escape");
    }

    // Update is called once per frame
    private void Update()
    {
        if(_escapeAction.triggered)
        {
            print("Escape!");
            SceneManager.LoadScene("MainMenu");
        }
    }
    #endregion

}
