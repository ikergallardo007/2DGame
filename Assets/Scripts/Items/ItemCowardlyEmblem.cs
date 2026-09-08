using UnityEngine;

public class ItemCowardlyEmblem : ItemBase
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
    protected override void ApplyEffect(GameObject player)
    {
        Jetpack playerJetpack = player.GetComponent<Jetpack>();

        if (playerJetpack == null)
            return;

        playerJetpack.Energy = 0;
    }
    #endregion

    #region Private Methods

    #endregion
}
