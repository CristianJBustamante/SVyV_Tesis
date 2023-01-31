using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Resume()
    {

        Time.timeScale = 1f;

    }

    public void Pause()
	{
        Time.timeScale = 0f;
    
    
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

}
