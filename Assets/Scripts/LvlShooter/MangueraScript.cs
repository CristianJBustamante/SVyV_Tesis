using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangueraScript : MonoBehaviour
{
   
    public float velocidad;
    public Transform puntero;
    public GameObject aguaDisparo;
    public GameObject cañonDisparo;
    public GameObject gameManager;
    public GameObject slider;

    public bool isFiring;
    public bool stopFiring;

    public bool sliderBool = false;


    // Start is called before the first frame update
    void Start()
    {
        velocidad = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.LookRotation(puntero.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target, velocidad * Time.deltaTime);

        if (slider.GetComponent<Slider>().value >= 35) {
            if (sliderBool == false)
            {
                isFiring = true;
                stopFiring = false;
                sliderBool = true;
            }
        }

        if (slider.GetComponent<Slider>().value < 35)
        {
            if (sliderBool == true)
            {
                sliderBool = false;
                soltar();
                
            }
        }

        if (isFiring) {
            noDispararAgua();
            if (gameManager.GetComponent<GameManagerShooter>().water >= 10) {
                Instantiate(aguaDisparo, cañonDisparo.transform.position, Quaternion.identity);
            }
            if (gameManager.GetComponent<GameManagerShooter>().water >= 0) {
                gameManager.GetComponent<GameManagerShooter>().water = gameManager.GetComponent<GameManagerShooter>().water - (slider.GetComponent<Slider>().value * 0.1f);
            }
            
        }
    }

    public void disparar() {
        stopFiring = false;
        dispararAgua();
    }

    public void soltar() {
        isFiring = false;
        stopFiring = true;

    }

    void dispararAgua()
    {
        isFiring = true;
    }

    void noDispararAgua()
    {
        isFiring = false;
        if (stopFiring == false) 
        {
            Invoke("dispararAgua", 0.1f);
        }
    }




}