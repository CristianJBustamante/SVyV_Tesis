using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpot : MonoBehaviour
{
    public Fire fire;
    public GameObject smoke;
    public bool onfire;
    // Start is called before the first frame update
    void Start()
    {
        onfire = false;
        fire.solved = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StarFire()
    {
        // GameObject go;
        // Vector3 pos = new Vector3();
        // pos = this.transform.position;
        // go = Instantiate(fuego, pos, Quaternion.identity);
        // fuego = go;
        // onfire = true;
        fire.risk = 0f;
        fire.gameObject.SetActive(true);
        fire.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        fire.gameObject.transform.GetChild(5).gameObject.SetActive(false);
        fire.gameObject.transform.localScale = Vector3.one;
        onfire = true;
        fire.solved = false;
        // StopCoroutine(fire._FireOff());
        // StartCoroutine(fire._FireOn());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Agua"))
        {
            fire.risk = fire.risk - 3;
            if (fire.risk <= 0 && fire.solved == false)
            {
                fire.solved = true;
                FireController.instance.firesActives--;

            }
        }
    }

}
