using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{

    private CanvasGroup BackgroundCanvasGroup;
    private Rigidbody2D PlayerRB;
    private Text InfoText;
    
    bool ComputerTriggered = false;
    
    private void Awake() 
    {
        BackgroundCanvasGroup = GameObject.Find("Background").GetComponent<CanvasGroup>();
        PlayerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        InfoText = GameObject.Find("KeyInfoText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ComputerTriggered)
        {
            OpenScreen();
            InfoText.enabled = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ComputerTriggered = true;
            InfoText.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) 
    {
        ComputerTriggered = false;
        InfoText.enabled = false;
    }
    
    public void OpenScreen()
    {
        BackgroundCanvasGroup.alpha = 1;
        FreezePlayer();
    }
    
    public void CloseScreen()
    {
        BackgroundCanvasGroup.alpha = 0;
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
        PlayerRB.velocity = Vector2.down * 0.0000000000000000000001f;
    }
}
