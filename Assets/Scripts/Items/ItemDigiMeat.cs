using UnityEngine;

public class ItemDigiMeat : ItemBase
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
        Jetpack playerJetpack = player.GetComponent<Jetpack>();

        if (playerJetpack == null)
            return;

        // No pierde energía durante 2 segundos.
        playerJetpack.Invulnerability(2);
    }
    #endregion
}
