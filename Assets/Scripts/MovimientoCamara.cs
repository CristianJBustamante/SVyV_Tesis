using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 posicionRelativa;
    public bool derrota;
    public GameObject FuegoDerrota;

    public static MovimientoCamara instance;

    void Awake(){
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Use this for initialization
    void Start()
    {
        
        posicionRelativa = transform.position - personaje.transform.position;
        derrota = false;
        FuegoDerrota = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (derrota == false)
        {
            transform.position = personaje.transform.position + posicionRelativa;
        }
        else 
        {
            float step = 20 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, FuegoDerrota.transform.position + posicionRelativa, step);
            // LeanTween.move(this.gameObject, FuegoDerrota.transform.position + posicionRelativa, 2); 

        }
        

    }

    public void setFuegoDerrota(GameObject go) 
    {
        FuegoDerrota = go;
        derrota = true;
    }
}
