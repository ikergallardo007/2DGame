using UnityEngine;

public class DigievolutionController : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _agumonSprite;
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
    #endregion

    #region Public Methods
    public void ChangeToAgumon()
    {
        _spriteRenderer.sprite = _agumonSprite;
    }
    #endregion

    #region Private Methods

    #endregion
}
