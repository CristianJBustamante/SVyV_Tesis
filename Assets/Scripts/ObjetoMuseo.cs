using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMuseo : MonoBehaviour
{
    public int index;
    public string titleText;
    public string descriptionText;

    public GameObject trofeo;

    public int level;




    // Start is called before the first frame update
    void Start()
    {
        // if (PlayerPrefs.GetInt("NivelesCompletados") >= index) trofeo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargarTrofeo()
    {
        trofeo.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.buttonInteract.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.infoPanel.SetActive(false);
            UIManager.instance.buttonInteract.SetActive(false);
            UIManager.instance.audio.Stop();
            UIManager.instance.StopAllCoroutines();
            

        }
    }

}
