using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private Rigidbody2D _checkPointRigidBody;
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
        if (collision.CompareTag("Player"))
        {
            PlayerStateController player = collision.GetComponent<PlayerStateController>();
            if (player != null && player.HasDigivice)
            {
                Debug.Log("El jugador ha llegado con el Digivice!");

                _checkPointRigidBody.simulated = false;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _checkPointRigidBody.simulated = true;
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
