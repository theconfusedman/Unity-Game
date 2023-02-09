using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene()
    {
        int currentLevelNumberPlusOne = int.Parse(SceneManager.GetActiveScene().name.Substring(5)) + 1;
        Debug.Log("Level " +  currentLevelNumberPlusOne);
        SceneManager.LoadScene("Level " +  currentLevelNumberPlusOne);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }
}
