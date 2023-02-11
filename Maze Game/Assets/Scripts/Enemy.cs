using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveDistance;
    public float speed = 3;
    private float startX;
    private bool backwards = false;
    private Rigidbody2D body;
    private GameObject Player;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        startX = body.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float currentX = body.position.x;
        float currentY = body.position.y;

        if (currentX - startX < moveDistance && !backwards)
        {
            float newPosition = currentX + (speed * Time.deltaTime);

            print("moving forward to " + newPosition);
            body.MovePosition(new Vector2(newPosition, currentY));

        } else if (!backwards)
        {

            print("going backwards now");
            backwards = true;

        } else if (currentX - startX > 0)
        {

            float newPosition = currentX - (speed * Time.deltaTime);
            print("moving backward");
            body.MovePosition(new Vector2(newPosition, currentY));

        } else
        {

            print("going forward");
            backwards = false;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
