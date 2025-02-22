using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class pooling : MonoBehaviour
{
    public static pooling sharedPrefab;
    public List<GameObject> poolObjects;
    public int poolCount = 5;
    public GameObject objectToPool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        poolObjects = new List<GameObject>();
        for (int i = 0; i < poolCount; i++)
        {
            GameObject gameObject = Instantiate(objectToPool);
            gameObject.SetActive(false);
            poolObjects.Add(gameObject);
        }
    }
    private void Awake()
    {
        sharedPrefab = this;
    }
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolCount; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {

    }
}