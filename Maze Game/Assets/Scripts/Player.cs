using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float moveForce = 25f;
    public float jumpForce = 5f;
    public float maxSpeed = 5;
    private float movementX;
    
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private string IDLE_ANIMATION = "Idle";
    public bool isGrounded = true;
    
    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
        
        sr = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
        if ((myBody.constraints & RigidbodyConstraints2D.FreezePositionX) != RigidbodyConstraints2D.FreezePositionX)
        {
            PlayerMoveKeyboard();
            PlayerJump();
            AnimatePlayer();
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

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

    }

    void PlayerJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    void AnimatePlayer() 
    {   
        if(myBody.velocity.x > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            anim.SetBool(IDLE_ANIMATION, false);
            sr.flipX = false;
        }
        else if (myBody.velocity.x < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            anim.SetBool(IDLE_ANIMATION, false);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(IDLE_ANIMATION, true);
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
        }
        else if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
}


