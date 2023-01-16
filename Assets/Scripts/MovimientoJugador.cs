using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    // Start is called before the first frame update

    private float xAxis, zAxis;
    public float velocidad;
    public float velocidadRotacion;
    private bool saltando;
    private Animator animacion;

    private bool interact;
    private bool okResponce;

    private float x, y;
    private float xR, zR;
    public Joystick joystickMovimiento;

    void Start()
    {
        animacion = GetComponent<Animator>();
        velocidadRotacion = 500f;


    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        Vector3 traslate = new Vector3(zAxis, 0, 0);
        Vector3 rotate = new Vector3(0, xAxis, 0);
        this.transform.Translate(-traslate * velocidad * Time.deltaTime);
        this.transform.Rotate(rotate * velocidadRotacion * 20 * Time.deltaTime);

        animacion.SetFloat("VelX", xAxis);
        animacion.SetFloat("VelY", zAxis);

        if (Input.GetKeyDown(KeyCode.Space) && saltando == false)
        {
            this.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
            saltando = true;
        }

        // CON JOYSTICK
        // Movimiento

        x = joystickMovimiento.Horizontal;
        y = joystickMovimiento.Vertical;

        transform.Translate(x * Time.deltaTime * velocidad, 0, 0, Space.World);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad, Space.World);

        // Rotación

        xR = joystickMovimiento.Horizontal;
        zR = joystickMovimiento.Vertical;

        Vector3 direccion = new Vector3(xR, 0, zR);
        Vector3 oldEulerAngles = this.gameObject.transform.rotation.eulerAngles;

        if (xR != 0 || zR != 0)
        {

            Quaternion aRotar = Quaternion.LookRotation(direccion, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, aRotar, velocidadRotacion * Time.deltaTime);
            animacion.SetFloat("VelX", x);
            animacion.SetFloat("VelY", y);
        }


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
            if (interact && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                SetInteract(false);
                Vector3 posicionRoca = new Vector3();
                posicionRoca = other.transform.position;
                other.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                other.GetComponent<ObjetoInteractivo>().Resolver();
                UIManager.instance.ActiveDesactiveButton("buttonAct");
                other.GetComponent<ObjetoInteractivo>().resuelto = true;
                QuestManager.instance.CheckWinCondition();
            }

        }

        if (other.gameObject.CompareTag("BasuraVidrio"))
        {
            if (interact && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                SetInteract(false);
                GameObject go = other.transform.GetChild(0).gameObject;
                Destroy(go);
                other.GetComponent<ObjetoInteractivo>().aResolver--;
            }
            if (other.GetComponent<ObjetoInteractivo>().aResolver == 0)
            {
                SetInteract(false);
                other.GetComponent<ObjetoInteractivo>().Resolver();
                UIManager.instance.ActiveDesactiveButton("buttonClean");
                other.GetComponent<ObjetoInteractivo>().resuelto = true;
                other.gameObject.SetActive(false);
                QuestManager.instance.CheckWinCondition();
            }


        }

        if (other.gameObject.CompareTag("BidonCaido"))
        {
            if (interact && other.GetComponent<ObjetoInteractivo>().resuelto == false)
            {
                SetInteract(false);
                GameObject go = other.transform.GetChild(1).gameObject;

                go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y, go.transform.eulerAngles.z + 90);

                go.transform.position = go.transform.position + new Vector3(0, 0.4f, 0);

                other.GetComponent<ObjetoInteractivo>().Resolver();
                UIManager.instance.ActiveDesactiveButton("buttonAct");
                other.GetComponent<ObjetoInteractivo>().resuelto = true;
                QuestManager.instance.CheckWinCondition();

            }
        }

        if (other.gameObject.CompareTag("ObjetoMuseo"))
        {
            if (interact)
            {
                ObjetoMuseo objMuseo = other.GetComponent<ObjetoMuseo>();
                SetInteract(false);
                UIManager.instance.ActiveDesactiveButton("buttonInteract");
                UIManager.instance.DisplayInfoPanel(objMuseo.titleText, objMuseo.descriptionText, objMuseo.level);
                // SceneManager.LoadScene(other.GetComponent<ObjetoMuseo>().index);
            }

            if (okResponce)
            {
                SceneManager.LoadScene(other.GetComponent<ObjetoMuseo>().index);
            }
        }
    }

    public void SetInteract(bool activation){
        interact = activation;
    }
    public void SetOk(bool activation){
        okResponce = activation;
    }
}

