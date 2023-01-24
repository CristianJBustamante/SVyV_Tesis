using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject buttonClean;
    public GameObject buttonAct;
    public GameObject buttonInteract;
    public GameObject buttonTalk;

    public GameObject winMessage;
    public GameObject loseMessage;

    //INFO PANEL
    public GameObject titleText;
    public GameObject descriptionText;
    public GameObject infoPanel;
    TMPro.TMP_Text infoTitleText;
    TMPro.TMP_Text infoDescriptionText;
    public char[] charArray;
    public GameObject buttonOk;
    public GameObject buttonBlock;

    public AudioSource audio;

    // FINISH GAME PANEL
    public GameObject FinishPanel;
    public GameObject buttonInstagram;
    public GameObject buttonWeb;
    public GameObject buttonLocation;



    public static UIManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    // Start is called before the first frame update

    void Start(){
        if(titleText != null) infoTitleText = titleText.GetComponent<TMPro.TMP_Text>();
        if(descriptionText != null) infoDescriptionText = descriptionText.GetComponent<TMPro.TMP_Text>();
        
    }

    public void ActiveDesactiveButton(string button)
    {
        switch (button)
        {
            case "buttonClean":
                if (buttonClean.activeSelf) buttonClean.SetActive(false);
                else buttonClean.SetActive(true);
                break;
            case "buttonAct":
                if (buttonAct.activeSelf) buttonAct.SetActive(false);
                else buttonAct.SetActive(true);
                break;
            case "buttonInteract":
                if (buttonInteract.activeSelf) buttonInteract.SetActive(false);
                else buttonInteract.SetActive(true);
                break;
        }
    }

    public void ActivateFinalMessage(bool win){
        if(win){
            winMessage.SetActive(true);
        }
        else{
            loseMessage.SetActive(true);
        }
    }

    public void DisplayInfoPanel(string text, string text2, int level){
        infoPanel.SetActive(true);
        infoTitleText.text = "";
        infoDescriptionText.text = "";
        charArray = text.ToCharArray();
        if(PlayerPrefs.GetInt("NivelesCompletados") >= level-1 || level == 1){
            buttonOk.SetActive(true);
            buttonBlock.SetActive(false);
            StartCoroutine(WriteTextTitle(text2));
        }else{
            buttonBlock.SetActive(true);
            buttonOk.SetActive(false);
            StartCoroutine(WriteTextTitle("Complete the previous level first."));
        }

    }

    IEnumerator WriteTextTitle(string text)
    {
        audio.Play();
        foreach (char ch in charArray)
        {
            infoTitleText.text = infoTitleText.text + ch;
            yield return new WaitForSeconds(0.05f);
        }
        audio.Stop();
        charArray = text.ToCharArray();
        StartCoroutine(WriteTextDesciption());
    }

    IEnumerator WriteTextDesciption()
    {
        audio.Play();
        foreach (char ch in charArray)
        {
            infoDescriptionText.text = infoDescriptionText.text + ch;
            yield return new WaitForSeconds(0.05f);
        }
        audio.Stop();
        if(SceneManager.GetActiveScene().name == "FIreQuest") StartCoroutine(EnableOKButton(2));
    }

    public void DisplayInfoQuest(string title, string description){
        infoPanel.SetActive(true);
        infoTitleText.text = title;
        infoDescriptionText.text = "";
        charArray = description.ToCharArray();
        StartCoroutine(WriteTextDesciption());
    }



    IEnumerator EnableOKButton(int time){
        yield return new WaitForSeconds(time);
        buttonOk.SetActive(true);
    }

    public void DisableInfoPanel(){
        buttonOk.SetActive(false);
        infoPanel.SetActive(false);
        QuestManager.instance.ContinueGame();
    }

    public void GoToURL(string url){
        Application.OpenURL(url);
    }

    public void CloseWindow(){
        FinishPanel.SetActive(false);
    }

    






}
