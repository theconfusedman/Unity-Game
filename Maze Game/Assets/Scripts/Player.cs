using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveForce = 12f;
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
        myBody.AddForce(new Vector2(movementX * moveForce * Time.deltaTime, 0f), ForceMode2D.Impulse);
    }
    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
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
