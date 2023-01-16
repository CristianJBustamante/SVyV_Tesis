using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    public float risk;
    public Vector3 encendiendo;
    public Vector3 apagando;
    public bool solved;
    public bool isFogata;

    public GameObject flames;
    //ameObject resueltoObj;

    // Start is called before the first frame update
    void Start()
    {
        risk = 0;
        encendiendo = new Vector3(0.02f, 0.025f, 0.02f);
        apagando = new Vector3(-0.02f, -0.025f, -0.02f);
        // if(SceneManager.GetActiveScene().name == "FireQuest") 
        StartCoroutine(_FireOn());
        //ObjetoInteractivo resueltoObj = GetComponent<ObjetoInteractivo>();
        solved = false;
        isFogata = false;

    }

    // Update is called once per frame
    void Update()
    {

        //resuelto = resueltoObj.resuelto;
    }

    public IEnumerator _FireOn()
    {
        while (true)
        {

            yield return new WaitForSeconds(0.2f);
            risk++;
            this.gameObject.transform.localScale += encendiendo;

            if (risk >= 100 && solved == false)
            {
                StopCoroutine(_FireOn());
                if (QuestManager.instance != null)
                {
                    QuestManager.instance.LoseGame(this.gameObject);

                }
                break;
            }
            if (solved == true)
            {
                StartCoroutine(_FireOff());
                break;
            }


        }
    }

    public IEnumerator _FireOff()
    {
        flames.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            risk--;
            this.gameObject.transform.localScale += apagando;

            if (risk <= -25 && isFogata)
            {
                transform.GetComponentInParent<FireSpot>().onfire = false;
                transform.GetComponentInParent<FireSpot>().gameObject.GetComponentInParent<FireController>().firesActives--;
                break;
            }

            if (risk <= 0 && isFogata == false)
            {
                StopCoroutine(_FireOff());
                break;

            }
        }
        StopCoroutine(_FireOff());
        this.gameObject.SetActive(false);


    }


    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Agua"))
    //     {
    //         risk = risk - 3;
    //         this.gameObject.transform.localScale += apagando * 3;
    //         if (risk <= 0)
    //         {
    //             solved = true;
    //         }
    //     }
    // }


}

