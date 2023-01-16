using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJoystick : MonoBehaviour
{
    // Start is called before the first frame update

    //private float xMove=0f;
    //private float zMove = 0f;

    public Joystick joystick;

    private float xAxis, zAxis;
    public float velocidad;
    private bool saltando;
    public GameObject roca;

    private bool pressed = false;

    void Start()
    {
        velocidad = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
        xAxis = joystick.Horizontal;
        zAxis = joystick.Vertical;
        Vector3 movement = new Vector3(xAxis, 0, zAxis);
        this.transform.Translate(movement * velocidad * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            saltando = false;
            // this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fogata"))
        {
            if (pressed == true && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                Vector3 posicionRoca = new Vector3();
                posicionRoca = other.transform.position;
                Instantiate(roca, posicionRoca, Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(1, 0, 0), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(-1, 0, 0), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(0, 0, 1), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(0, 0, -1), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(1, 0, 1), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(-1, 0, -1), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(1, 0, -1), Quaternion.identity);
                Instantiate(roca, posicionRoca + new Vector3(-1, 0, 1), Quaternion.identity);

                other.GetComponent<ObjetoInteractivo>().Resolver();
                pressed = false;
            }

        }

        if (other.gameObject.CompareTag("BasuraVidrio"))
        {
            if (pressed == true && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                GameObject go = other.transform.GetChild(0).gameObject;
                Destroy(go);
                other.GetComponent<ObjetoInteractivo>().aResolver--;
                pressed = false;
            }
            if (pressed == true && other.GetComponent<ObjetoInteractivo>().aResolver == 0)
            {
                other.GetComponent<ObjetoInteractivo>().Resolver();
                Destroy(other);
                pressed = false;
            }


        }

        if (other.gameObject.CompareTag("Bidones"))
        {
            if (pressed == true && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                GameObject go = other.transform.GetChild(1).gameObject;

                go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x + 90, go.transform.eulerAngles.y, go.transform.eulerAngles.z);

                go.transform.position = go.transform.position + new Vector3(0, 0.4f, 0);

                other.GetComponent<ObjetoInteractivo>().Resolver();
                pressed = false;

            }
        }

        if (other.gameObject.CompareTag("ObjetoMuseo"))
        {
            if (pressed == true)
            {
                SceneManager.LoadScene(other.GetComponent<ObjetoMuseo>().index);
                pressed = false;

            }
        }




    }

    public void Saltar() 
    {
        if (saltando == false)
        {
            this.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
            saltando = true;
        }
    }

    public void Interactuar()
    {
        pressed = true;
    }
}
