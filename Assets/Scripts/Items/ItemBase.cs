using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IRecolectable
{
    #region Properties
    public enum ItemTypes
    {
        None,
        Digivice,
        CourageEmblem,
        CourageCircuit,
        CourageDigivice,
        DigiMushroom,
        DigiMeat,
        WaterBall,
        CowardlyEmblem
    }
    #endregion

    #region Fields
    [SerializeField] private GameObject _particles;
    #endregion

    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        ApplyEffect(collision.gameObject);

        Recolected();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer"))
            Recolected();
    }
    #endregion

    #region Public Methods
    protected abstract void ApplyEffect(GameObject player);

    public void Recolected()
    {
        Destroy(gameObject);
        CreateParticles();
    }
    #endregion

    #region Private Methods
    private void CreateParticles()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
    #endregion
}
