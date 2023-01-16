using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public static FireController instance;
    public int firesToWin;
    public int spotsActivesAtSameTime;
    [SerializeField] List<FireSpot> windows;

    public int firesActives;


    void Awake()
    {
        if(instance)
            Destroy(this.gameObject);
        else
            instance = this;

        GameObject[] spots = GameObject.FindGameObjectsWithTag("SpotFuego");
        for (int i = 0; i < spots.Length; i++)
        {
            windows.Add(spots[i].GetComponent<FireSpot>());
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StarFire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StarFire()
    {
        while (firesToWin > 0)
        {
            yield return new WaitForSeconds(2f);
            if (firesActives < spotsActivesAtSameTime)
            {
                yield return new WaitForSeconds(Random.Range(2, 5));
                firesToWin--;
                firesActives++;
                GetAWindowWithoutFire().StarFire();
                Debug.Log("entra");
            }
        }
        while(true){
            yield return new WaitForSeconds(1f);
            if (firesToWin == 0 && firesActives == 0)
            {
                GameManagerShooter.instance.winGame();
                break;
            }
        }

        StopCoroutine(StarFire());
    }

    FireSpot GetAWindowWithoutFire()
    {
        FireSpot result = null;
        do
        {
            int selectedWindow = Random.Range(0, windows.Count);
            for (var i = 0; i < windows.Count; i++)
            {
                if (i == selectedWindow)
                {
                    result = windows[i];
                }
            }
        } while (result.onfire == true);
        return result;
    }
}

