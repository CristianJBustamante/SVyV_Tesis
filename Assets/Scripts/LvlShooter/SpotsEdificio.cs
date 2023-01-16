using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsEdificio : MonoBehaviour
{
    public int fuegosRestantes;
    public bool fuegoActivo;

    // Start is called before the first frame update
    void Start()
    {
        fuegosRestantes = 5;
        fuegoActivo = false;
        // StartCoroutine(EncenderFuego());

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // IEnumerator EncenderFuego()
    // {
    //     yield return new WaitForSeconds(1);
    //     if (fuegoActivo==false) {
    //         yield return new WaitForSeconds(Random.Range(2, 5));
    //         fuegosRestantes--;
    //         fuegoActivo = true;
    //         FireSpot[] spots = GetComponentsInChildren<FireSpot>();
    //         spots[Random.Range(0, 3)].StarFire(this.tag);
    //         Debug.Log("entra");
    //     }
        
    //     if (fuegosRestantes == 0) 
    //     {
    //         StopCoroutine(EncenderFuego());
    //     }
    // }
}
