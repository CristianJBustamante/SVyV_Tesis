using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displayer : MonoBehaviour
{

    public GameObject text;
    bool triggered = false;

    public List<string> textToWrite;

    public char[] charArray;

    TMPro.TMP_Text tmpText;

    public GameObject panel;

    public AudioSource audio;

    void Start()
    {
        if(PlayerPrefs.GetInt("NivelesCompletados") == 0) charArray = textToWrite[0].ToCharArray();
        if(PlayerPrefs.GetInt("NivelesCompletados") > 0) charArray = textToWrite[1].ToCharArray();
        if(PlayerPrefs.GetInt("NivelesCompletados") == 3) charArray = textToWrite[2].ToCharArray();

        tmpText = text.GetComponent<TMPro.TMP_Text>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {

            StartCoroutine(WriteText());
            triggered = !triggered;
        }
    }

    IEnumerator WriteText()
    {
        panel.SetActive(true);
        audio.Play();
        foreach (char ch in charArray)
        {
            tmpText.text = tmpText.text + ch;
            yield return new WaitForSeconds(0.05f);
        }
        audio.Stop();
        StartCoroutine(_HidePanel());
    }

    IEnumerator _HidePanel(){
        yield return new WaitForSeconds(5);
        panel.SetActive(false);
    }


}
