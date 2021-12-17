using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text score;
    public Text lives;
    public Text time;

    public int scoreVar;
    public int liveVar;
    private float timer;
    public float timeLength = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeLength;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        time.text = timer.ToString();
        score.text = scoreVar.ToString();
        lives.text = liveVar.ToString();
        if(timer<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
