using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomMovementManager : MonoBehaviour
{
    public GameObject virtualCam;
    
    public CinemachineVirtualCamera vcam;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            vcam.m_Lens.OrthographicSize = 10;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            vcam.m_Lens.OrthographicSize = 5;
        }
    }
}
