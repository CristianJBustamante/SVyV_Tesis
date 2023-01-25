using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * RuteManager.instance.velocidad * Time.deltaTime);


        if (transform.position.x <= -39.78f) {
            Destroy(gameObject);
        }


    }
}
