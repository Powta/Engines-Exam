using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Components
    private Rigidbody myRb;

    //movement input
    private float dirX, dirZ;

    //Movement Variables
    public float jumpForce;
    public float moveSpeed;
    public float gravity;
    public float fallMultiplier;
    private int numOfJumps = 0;
    public bool isFalling = true;

    //action
    public static event System.Action<string> enemyKilled;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        if (myRb.velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }

    //Player Input
    private void PlayerInput()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump"))//jump
        {
            if (numOfJumps > 0)
            {
                Jump();
            }
        }
    }

    //Player Horizontal Movement
    private void Movement()
    {
        myRb.velocity = new Vector3(dirX, myRb.velocity.y, dirZ);
        if (myRb.velocity.y < 0)
        {
            myRb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime; //incorporated fall multiplier to gravity
        }
    }

    //Jump
    private void Jump()
    {
        myRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

        numOfJumps--;//decrease number of jumps
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            numOfJumps = 1;
            myRb.velocity = new Vector3(myRb.velocity.x,0, myRb.velocity.z);
        }
        if(collision.gameObject.tag=="Enemy")
        {
            if(isFalling)
            {
                Destroy(collision.gameObject);
                Debug.Log("Enemy has been killed");
                enemyKilled?.Invoke("Enemy has been killed!");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    }

}


