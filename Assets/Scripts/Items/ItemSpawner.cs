using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] private float _minSpawnTime = 0.5f;
    [SerializeField] private float _maxSpawnTime = 4f;
    [SerializeField] private List<ItemBase> _spawList;
    private float _nextSpawnTime;
    private float _cronoTime = 0;
    #endregion

    #region Unity Callbacks

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ResetTime();
    }

    // Update is called once per frame
    private void Update()
    {
        _cronoTime += Time.deltaTime;
        if(_cronoTime > _nextSpawnTime)
        {
            SpawItem();
            ResetTime();
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void ResetTime()
    {
        _cronoTime = 0;
        _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
    private void SpawItem()
    {
        // Random object from a list
        int index = Random.Range(0, _spawList.Count);

        // Random Horizontal Position
        float xPos = Random.Range(-8.5f, 8.5f);
        Vector2 itemPosition = new Vector2(xPos, transform.position.y);

        // Instantiation
        ItemBase newItem = Instantiate(_spawList[index], itemPosition, Quaternion.identity);

        // Add Rotation Force
        float torqueForce = Random.Range(-25f, 25f);
        newItem.GetComponent<Rigidbody2D>().AddTorque(torqueForce);
    }
    #endregion
}
