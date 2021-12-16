using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]private GameObject prefab;

    private Queue<GameObject> objectsAvailable = new Queue<GameObject>();

    public static ObjectPool Instance { get; private set; } //use instance of the basic pool

    private void Awake()
    {
        Instance = this;

    }

    public GameObject GetFromPool()
    {
        if (objectsAvailable.Count == 0)
        {
            GrowPool();
        }
        var instance = objectsAvailable.Dequeue();
        instance.SetActive(true);
        return instance;
    }
    public void AddToPool(GameObject instance) //conditions are met to make object seemingly disappear, make the instance not active and add the object to the queue
    {
        instance.SetActive(false);
        objectsAvailable.Enqueue(instance);
    }

    private void GrowPool()//create the objects
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(prefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

 



}
