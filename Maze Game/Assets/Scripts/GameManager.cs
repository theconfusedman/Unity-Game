using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveRoom()
    {
        //GameObject.Find("Room1").transform.position = new Vector2 (30f, 20f);
        GameObject.Find("Room1").transform.Rotate(0f, 0f, 90f);
    }
}
