using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerShooter : MonoBehaviour
{


    public static GameManagerShooter instance;

    public Image riskBar;
    public Image waterBar;
    int solvedFires;
    public float water;

    [SerializeField] Fire[] fires;

    private void Awake(){
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        water = 0;
        StartCoroutine(ReloadWater());
        StartCoroutine(FindRisk());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FindRisk()
    {

        while (true)
        {
            float maximumRisk = 0;
            solvedFires = 0;

            for (int i = 0; i < fires.Length; i++)
            {
                if (fires[i].risk > maximumRisk && fires[i].gameObject.activeSelf)
                {
                    maximumRisk = fires[i].risk;

                    if (maximumRisk == 100)
                    {
                        StartCoroutine(_LoseLevel());
                        StopCoroutine(FindRisk());
                    }
                }
            }

            riskBar.fillAmount = maximumRisk * 0.01f;
            yield return new WaitForSeconds(0.4f);            

        }

    }


    public void winGame(){
        StartCoroutine(_WinLevel());
        StopCoroutine(FindRisk());
    }
    public IEnumerator _WinLevel()
    {
        Debug.Log("Has ganado el Nivel!.");
        // Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if(PlayerPrefs.GetInt("NivelesCompletados") == 0) PlayerPrefs.SetInt("NivelesCompletados", 1);
        else PlayerPrefs.SetInt("NivelesCompletados", 3);
        yield return new WaitForSeconds(1);
        // SceneManager.LoadScene("Menu Museo");
        UIManager.instance.ActivateFinalMessage(true);
    }

    IEnumerator _LoseLevel()
    {
        yield return null;
        UIManager.instance.ActivateFinalMessage(false);
    }

    IEnumerator ReloadWater() {

        while (true) {
                if (water < 1000) {
                    water = water + 5;
                    waterBar.fillAmount = water * 0.001f;
                }
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}




