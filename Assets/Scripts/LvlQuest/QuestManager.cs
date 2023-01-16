using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Indicators;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{

    public static QuestManager instance;
    public int firesResolve;
    public int firesStarted;
    public List<ObjetoInteractivo> firePoints;
    public bool gameOver;
    public OffScreenIndicators indicators;

    private void Awake(){
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLevel());
    }

    // Update is called once per frame
    
    IEnumerator StartLevel(){
        yield return new WaitForSeconds(Random.Range(5,15));
        firePoints[firesStarted].StartFire();
        firesStarted++;
        if(firesStarted < firePoints.Count){
            StartCoroutine(StartLevel());
        }
    }

    public void CheckWinCondition(){
        firesResolve++;
        if(firesResolve == firePoints.Count){
            WinGame();
        }
    }

    public void WinGame(){
        if(!gameOver)Debug.Log("You control de fire!. YOU WIN!");
        PlayerPrefs.SetInt("NivelesCompletados", 2);
        gameOver = true;
        UIManager.instance.ActivateFinalMessage(true);
    }
    public void LoseGame(GameObject cause){
        gameOver=true;
        Debug.Log("We are in flames!. YOU LOSE!");
        UIManager.instance.ActivateFinalMessage(false);
        if( MovimientoCamara.instance.FuegoDerrota == null) MovimientoCamara.instance.setFuegoDerrota(cause);
    }

}
