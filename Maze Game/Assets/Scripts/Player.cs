using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveForce = 12f;
    public float jumpForce = 5f;
    private float movementX;
    
    private Rigidbody2D myBody;
    
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
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))// && isGrounded)
        {
            //isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
