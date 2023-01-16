using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject barra;
    public GameObject camara;

    int fuegosResueltos;



    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(BuscarRiesgo());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator BuscarRiesgo() 
    {
        GameObject[] go;

        while(true)
        {
            go = GameObject.FindGameObjectsWithTag("Fuego");
            float riesgoMaximo = 0;
            fuegosResueltos = 0;

            foreach (GameObject fuego in go) 
            {
                if (fuego.GetComponent<Fire>().risk > riesgoMaximo) 
                {
                    riesgoMaximo = fuego.GetComponent<Fire>().risk;

                    if(riesgoMaximo == 100)
                    {
                        camara.GetComponent<MovimientoCamara>().setFuegoDerrota(fuego);
                        StartCoroutine(PerderNivel());
                        StopCoroutine(BuscarRiesgo());
                    }
                }
            
            }

            barra.GetComponent<Image>().fillAmount = riesgoMaximo * 0.01f;
            yield return new WaitForSeconds(0.4f);

            foreach (GameObject fuego in go)
            {
                if (fuego.GetComponent<Fire>().risk <= 0 && fuego.GetComponent<Fire>().solved == true)
                {
                    fuegosResueltos++;
                    if (fuegosResueltos == go.Length)
                    {
                        StartCoroutine(GanarNivel());
                        StopCoroutine(BuscarRiesgo());
                    }
                }

            }

        }
    
    
    }

    IEnumerator GanarNivel() 
    {
        Debug.Log("Has ganado el Nivel!.");
        // Debug.Log(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetInt("NivelesCompletados", SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu Museo");
    }

    IEnumerator PerderNivel() 
    {
        yield return null;
    }


}
