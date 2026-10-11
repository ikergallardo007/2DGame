using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{

    #region Fields
    private InputAction _escapeAction;

    #endregion

    #region Unity Callbacks
    private void OnEnable()
    {
        _escapeAction = InputSystem.actions.FindAction("Escape");

        if (_escapeAction != null)
        {
            _escapeAction.performed += OnEscapePressed;
        }
        else
        {
            Debug.LogError("No se ha encontrado la acción Escape.");
        }
    }

    private void OnDisable()
    {
        if (_escapeAction != null)
        {
            _escapeAction.performed -= OnEscapePressed;
        }
    }
    #endregion

    #region Private Methods
    private void OnEscapePressed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
