using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(new Vector3(180f, 0f, 0f) * Time.deltaTime * RuteManager.instance.velocidad);

    }
}
