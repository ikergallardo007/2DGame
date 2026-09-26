using UnityEngine;

public class ItemCourageEmblem : ItemBase
{
    #region Properties

    #endregion

    #region Fields

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

    #endregion

    #region Private Methods
    protected override void ApplyEffect(GameObject player)
    {
        PlayerStateController state = player.GetComponent<PlayerStateController>();

        if (state == null)
            return;

        state.Excited = true;
        state.HasCourageEmblem = true;
    }
    #endregion
}
