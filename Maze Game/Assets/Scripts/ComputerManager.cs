using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    private GameObject FindCanvas;
    private Canvas Canvas;
    private GameObject FindPlayer;
    private Rigidbody2D PlayerRB;

    // Start is called before the first frame update
    void Start()
    {
        FindCanvas = GameObject.Find("Canvas");
        Canvas = FindCanvas.GetComponent<Canvas>();
        FindPlayer = GameObject.Find("Player");
        PlayerRB = FindPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            OpenScreen();
        }
    }
    
    public void OpenScreen()
    {
        Canvas.enabled = true;
        FreezePlayer();
    }
    
    public void CloseScreen()
    {
        Canvas.enabled = false;
        UnfreezePlayer();
    }
    
    public void FreezePlayer()
    {
        PlayerRB.constraints = RigidbodyConstraints2D.FreezePosition;
    }
    
    public void UnfreezePlayer()
    {
        PlayerRB.constraints = RigidbodyConstraints2D.None;
        PlayerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerRB.velocity = Vector2.down * 0.0000000001f;
    }
}
