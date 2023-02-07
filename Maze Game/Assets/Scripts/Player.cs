using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveForce = 12f;
    public float maxSpeed = 30;
    public float jumpForce = 5f;
    private float movementX;
    
    private Rigidbody2D myBody;
    public bool isGrounded = true;
    
    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //!GameObject.Find("Canvas").GetComponent<Canvas>().enabled
    }

    // Update is called once per frame
    void Update()
    {
        if ((myBody.constraints & RigidbodyConstraints2D.FreezePositionX) != RigidbodyConstraints2D.FreezePositionX)
        {
            PlayerMoveKeyboard();
        }
        PlayerJump();
    }
    
    void PlayerMoveKeyboard() 
    {
        movementX = Input.GetAxisRaw("Horizontal");

        //if (movementX < 0)
        //{
        //    print("negative");
        //    myBody.AddForce(new Vector2(-moveForce, 0));
        //}
        //else if (movementX > 0)
        //{
        //    print("positive");
        //    myBody.AddForce(new Vector2(moveForce, 0));
        //    //myBody.velocity.Set(moveForce, myBody.velocity.y);
        //}

        if ((myBody.velocity.x < maxSpeed && myBody.velocity.x > -maxSpeed) && movementX != 0)
        {
            print("accelerating");
            //myBody.velocity.Set(movementX * moveForce * Time.deltaTime, myBody.velocity.y);
            myBody.AddForce(new Vector2(movementX * moveForce * Time.deltaTime, 0f), ForceMode2D.Impulse);
        }
        else if (myBody.velocity.x < 0)
        {
            print("max negative");
            myBody.velocity.Set(-maxSpeed, myBody.velocity.y);
        }
        else if (myBody.velocity.x > 0)
        {
            print("max positive");
            myBody.velocity.Set(maxSpeed, myBody.velocity.y);
        }

        //if (movementX == 1)
        //{
        //    print("positive");
        //    myBody.AddForce(new Vector2(moveForce * Time.deltaTime, 0));
        //    myBody.velocity.Set(maxSpeed, myBody.velocity.y);
        //} else if (movementX == -1)
        //{
        //    print("negative");
        //    myBody.AddForce(new Vector2(-moveForce * Time.deltaTime, 0));
        //    myBody.velocity.Set(-maxSpeed, myBody.velocity.y);
        //} else
        //{
        //    print("0");
        //    myBody.velocity.Set(0, myBody.velocity.y);
        //}

    }
    
    void PlayerJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // respawn the player when they collide with a respawn box
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            //TODO: Decide if respawning should send back to computer area, a set location, or reset all progress.
            // This is placeholder code
            transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        } else if(collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

}
