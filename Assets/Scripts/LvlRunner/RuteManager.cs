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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshBars(){
        waterBar.fillAmount = water * 0.01f;
        fuelBar.fillAmount = fuel * 0.01f;
    }

    public void LoseLevel(){
        Debug.Log("Level Lose!");
    }
    public void WinLevel(){
        Debug.Log("Level Win!");
    }
}
