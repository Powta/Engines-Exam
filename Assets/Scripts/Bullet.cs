using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer;
    private float timeLength=5.0f;
    private Rigidbody myRb;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLength;
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        myRb.velocity = new Vector3(0, -5.0f, 0);
        if(timer<=0)
        {
            timer = timeLength;
            //Destroy(gameObject);
            ObjectPool.Instance.AddToPool(gameObject);
        }

    }

}
