using UnityEngine;

public class ItemMine : ItemBase
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private float _pushForce = 100f;
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
        Vector2 push = new(0, -_pushForce);
        playerRB.AddForce(push);
    }
    #endregion
}
