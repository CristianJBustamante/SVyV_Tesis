using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMuseo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("ObjetoMuseo");

        foreach (GameObject objetoMuseo in go) 
        {
            if (objetoMuseo.GetComponent<ObjetoMuseo>().level <= PlayerPrefs.GetInt("NivelesCompletados")) 
            {
                objetoMuseo.GetComponent<ObjetoMuseo>().CargarTrofeo();
            }
        
        }

        if(PlayerPrefs.GetInt("NivelesCompletados") == 3) UIManager.instance.FinishPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
