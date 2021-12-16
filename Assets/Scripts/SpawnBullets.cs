using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float delayTimer;
    private float delayTime= 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        delayTimer = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer -= Time.deltaTime;
        if(delayTimer<=0)
        {
            //slowShoot();
            shoot();
            delayTimer = delayTime;
        }
    }

    private void shoot()
    {
        var bullet = ObjectPool.Instance.GetFromPool(); //get bullet from pool
        bullet.transform.position = transform.position;
    }

    private void slowShoot()
    {
        Instantiate(bulletPrefab, transform.position,Quaternion.identity);
    }
}
