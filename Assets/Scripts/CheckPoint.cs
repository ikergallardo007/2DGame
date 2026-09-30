using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private Collider2D _wallCollider;
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

            if (player == null)
                return;

            switch (player.DigimonIndex)
            {
                case 0:
                    {
                        if (player.HasDigivice)
                            _wallCollider.enabled = false;
                        break;
                    }
                case 1:
                    {
                        if (player.HasCourageEmblem)
                            _wallCollider.enabled = false;
                        break;
                    }
                case 2:
                    {
                        if (player.HasCourageCircuit)
                            _wallCollider.enabled = false;
                        break;
                    }
                case 3:
                    {
                        if (player.HasCourageDigivice)
                            _wallCollider.enabled = false;
                        break;
                    }
                case 4:
                    {
                        if (player.HasDigivice && player.HasCourageEmblem
                            && player.HasCourageCircuit && player.HasCourageDigivice)
                            _wallCollider.enabled = false;
                        break;
                    }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _wallCollider.enabled = true;
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
