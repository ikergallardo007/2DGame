using UnityEngine;

public class ItemPoisonDigiMushroom : ItemBase
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
        PlayerStateController playerState = player.GetComponent<PlayerStateController>();

        if (playerState == null)
            return;

        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        if (playerRB == null)
            return;

        playerState.Damaged = true;
        playerRB.linearVelocityX = 0;
        playerRB.linearVelocityY = 0;
    }
    #endregion
}
