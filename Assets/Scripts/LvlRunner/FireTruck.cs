using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruck : MonoBehaviour
{

    
    private float velocidad = 5.0f;
    [SerializeField] bool working;

    public int verticalDirection;
    public int horizontanDirection;


    
    void Start()
    {
        working = true;
        StartCoroutine(_SpendFuel());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    private void Movement() {

        //Movimiendo Jugador en x y z
        // transform.Translate(Vector3.forward * Time.deltaTime * velocidad * Input.GetAxis("Vertical"));
        // transform.Translate(Vector3.right * Time.deltaTime * velocidad * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * verticalDirection);
        transform.Translate(Vector3.right * Time.deltaTime * velocidad * horizontanDirection);

        //Limitador de pantalla
        if (transform.position.z >= -1.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.1f);
        }
        else if (transform.position.z <= -6.9f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.9f);
        }

        if (transform.position.x >= -3.4f)
        {
            transform.position = new Vector3(-3.4f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -14.6f)
        {
            transform.position = new Vector3(-14.6f, transform.position.y, transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other) {
        
        GameObject col = other.gameObject;
        switch(col.tag){
            case "Fuel":
                if(RuteManager.instance.fuel <= 90) RuteManager.instance.fuel = RuteManager.instance.fuel+20;
                else RuteManager.instance.fuel = 100;
                RuteManager.instance.RefreshBars();
                col.SetActive(false);
            break;
            case "Water":
                if (RuteManager.instance.water <= 90) RuteManager.instance.water = RuteManager.instance.water + 10;
                else RuteManager.instance.water = 100;
                RuteManager.instance.RefreshBars();
                col.SetActive(false);
                break;
            case "Obstacle":
                if(RuteManager.instance.water >= 10) RuteManager.instance.water = RuteManager.instance.water - 10;
                else RuteManager.instance.water = 0;
                RuteManager.instance.RefreshBars();
            break;
        }
    }

    IEnumerator _SpendFuel(){
        yield return new WaitForSeconds(0.4f);
        if(working && !RuteManager.instance.finishLevel){
            if(RuteManager.instance.fuel > 0){
                RuteManager.instance.fuel--;
                RuteManager.instance.RefreshBars();
            }
            else{
                RuteManager.instance.LoseLevel();
            }
        }
        StartCoroutine(_SpendFuel());
    }

    public void SetDirectionUP(bool buttonDown){
        if(RuteManager.instance.finishLevel) return;
        if(buttonDown){
            verticalDirection = verticalDirection - 1;
            LeanTween.rotate(this.gameObject,new Vector3(0,170,0),.3f);
        }
        else{
            verticalDirection = verticalDirection +1;
            LeanTween.rotate(this.gameObject,new Vector3(0,180,0),.3f);
        }
    }

    public void SetDirectionDown(bool buttonDown){
        if(RuteManager.instance.finishLevel) return;
        if(buttonDown){
            verticalDirection = verticalDirection + 1;
            LeanTween.rotate(this.gameObject,new Vector3(0,190,0),.3f);
        }
        else{
            verticalDirection = verticalDirection - 1;
            LeanTween.rotate(this.gameObject,new Vector3(0,180,0),.3f);
        }
    }

    
}
