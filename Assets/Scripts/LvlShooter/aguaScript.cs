using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aguaScript : MonoBehaviour
{
    public float speed = 0.15f;
    public float ttl = 1f;
    public GameObject slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.FindGameObjectWithTag("Slider");
        this.transform.rotation = GameObject.FindGameObjectWithTag("Manguera").transform.rotation;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * speed * slider.GetComponent<Slider>().value, ForceMode.Impulse);

        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
