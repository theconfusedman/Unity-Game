using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SceneLoad()
    {
        SceneManager.LoadScene(gameObject.name);
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
