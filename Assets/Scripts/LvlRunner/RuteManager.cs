using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuteManager : MonoBehaviour
{

    public Image waterBar;
    public Image fuelBar;

    public float fuel = 150;

    public float water = 100;
    public float velocidad = 5.0f;

    public Text distanceText;

    public int distance = 2000;

    public bool finishLevel;

    public static RuteManager instance;

    private void Awake(){
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(distanceReduce());
    }

    // Update is called once per frame
    void Update()
    {
        // distance = (int)(distance - Time.deltaTime * velocidad * 10);

        distanceText.text = "Distancia: " + distance + "m";

        if (distance <= 0) {

            WinLevel();
            if(velocidad > 0) velocidad-= 0.01f;
            // Time.timeScale = 0f;
        }

        if (water <= 0 || fuel <= 0) {

            LoseLevel();
            if(velocidad > 0) velocidad-= 0.01f;
            // Time.timeScale = 0f;

        }
    }

    public void RefreshBars(){
        waterBar.fillAmount = water * 0.01f;
        fuelBar.fillAmount = fuel * 0.01f;
    }

    public void LoseLevel(){
        finishLevel = true;
        Menu.instance.losePanel.SetActive(true);
        Debug.Log("Level Lose!");
    }
    public void WinLevel(){
        finishLevel = true;
        Menu.instance.winPanel.SetActive(true);
        PlayerPrefs.SetInt("NivelesCompletados", 3);
        Debug.Log("Level Win!");
    }

    IEnumerator distanceReduce(){
        do{
            yield return new WaitForSeconds(0.05f);
            distance--;
        }while(distance > 0 && !RuteManager.instance.finishLevel);
    }
}
