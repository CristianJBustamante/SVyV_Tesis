using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;

    public static Menu instance;

    private void Awake(){
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Pause()
	{
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }


    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMuseo()
    {



    }

    public void ExitMenu() { 
    

    
    
    
    }

    public void goBacktoMuseum(){
        SceneManager.LoadScene("Menu Museo");
    }

}
