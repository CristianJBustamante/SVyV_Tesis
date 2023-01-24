using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom.Indicators;

public class ObjetoInteractivo : MonoBehaviour
{
    public bool resuelto;
    public int aResolver;
    public GameObject fuego;
    public GameObject posFuego;
    public bool onfire;






    // Start is called before the first frame update
    void Start()
    {
        resuelto = false;
        onfire = false;
        aResolver = 3;

        // if (this.gameObject.tag != "Fogata")
        // {
        //     StartCoroutine(EncenderFuego());

        // }
        // else
        // {
        //     GameObject go;
        //     Vector3 pos = new Vector3();
        //     pos = posFuego.transform.position;
        //     go = Instantiate(fuego, pos, Quaternion.identity);
        //     fuego = go;
        //     fuego.gameObject.GetComponent<Fire>().isFogata = true;
        //     StopCoroutine(EncenderFuego());
        //     onfire = true;

        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (aResolver == 0 && fuego.GetComponent<Fire>().solved == false)
        {
            Resolver();
        }
    }

    public void Resolver()
    {
        resuelto = true;
        if (onfire == true)
        {
            fuego.gameObject.GetComponent<Fire>().solved = true;
            QuestManager.instance.indicators.RemoveTarget(fuego.gameObject);
            //Debug.Log(fuego.GetComponent<FuegoScript>().resuelto);
        }
    }

    public IEnumerator EncenderFuego()
    {
        GameObject go;
        int waitTime=Random.Range(5,15);
        for(int i =0; i<= waitTime;){
            yield return new WaitForSeconds(1);
            if(QuestManager.instance != null){
                if(!QuestManager.instance.gameStopped) i++;
            } 
            else{
                i++;
            }
        }
        if (resuelto == false)
        {
            Vector3 pos = new Vector3();
            pos = posFuego.transform.position;
            go = Instantiate(fuego, pos, Quaternion.identity);
            fuego = go;
            onfire = true;
        }
        StopCoroutine(EncenderFuego());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.tag)
            {
                case "Fogata":
                    if (!resuelto){
                        UIManager.instance.ActiveDesactiveButton("buttonAct");
                        QuestManager.instance.CheckMessages(this.tag);
                    }
                    break;
                case "BidonCaido":
                    if (!resuelto){
                        UIManager.instance.ActiveDesactiveButton("buttonAct");
                        QuestManager.instance.CheckMessages(this.tag);
                    }
                    break;
                case "BasuraVidrio":
                    if (!resuelto){
                        UIManager.instance.ActiveDesactiveButton("buttonClean");
                        QuestManager.instance.CheckMessages(this.tag);
                    }
                    break;
                case "ObjetoInteractivo":
                    UIManager.instance.ActiveDesactiveButton("buttonInteract");
                    break;

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.tag)
            {
                case "Fogata":
                    if (!resuelto) UIManager.instance.ActiveDesactiveButton("buttonAct");
                    break;
                case "BidonCaido":
                    if (!resuelto) UIManager.instance.ActiveDesactiveButton("buttonAct");
                    break;
                case "BasuraVidrio":
                    if (!resuelto) UIManager.instance.ActiveDesactiveButton("buttonClean");
                    break;
                case "ObjetoInteractivo":
                    UIManager.instance.ActiveDesactiveButton("buttonInteract");
                    break;
            }
        }
    }

    public void StartFire()
    {
        if (!resuelto)
        {
            GameObject go;
            Vector3 pos = new Vector3();
            pos = posFuego.transform.position;
            go = Instantiate(fuego, pos, Quaternion.identity);
            fuego = go;
            QuestManager.instance.indicators.AddTarget(go.gameObject);
            onfire = true;
        }
    }


}
