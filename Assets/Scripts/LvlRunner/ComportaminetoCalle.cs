using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportaminetoCalle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * RuteManager.instance.velocidad * Time.deltaTime);
        if (transform.position.x <= -32.79f) {
            transform.position = new Vector3(25.59f, transform.position.y, transform.position.z);
        
        
        }
        
    }

    
}
