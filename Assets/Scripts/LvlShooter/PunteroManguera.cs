using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteroManguera : MonoBehaviour
{
    public Joystick joystick;

    private float xAxis, yAxis;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = joystick.Horizontal;
        yAxis = joystick.Vertical;
        Vector3 movement = new Vector3(xAxis, yAxis, 0);
        this.transform.Translate(movement * velocidad * Time.deltaTime);

        // Limites de Juego

        if (this.transform.position.x< 0) {
            this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x > 18)
        {
            this.transform.position = new Vector3(18, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.y < 1)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        }
        if (this.transform.position.y > 8)
        {
            this.transform.position = new Vector3(this.transform.position.x, 8, this.transform.position.z);
        }
    }
}
