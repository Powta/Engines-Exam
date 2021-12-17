using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;
public class DLLScript : MonoBehaviour
{
    public float time;

    [DllImport("ExamDll")]
    static extern void setTime(float t);
    [DllImport("ExamDll")]
    static extern float getTime();
    public GameObject enemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        setTime(time);
        gameObject.GetComponent<Bullet>().timeLength = getTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
