using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] powerUps;

    private float posGenerationObstacleZ = 10f;
    private float posGenerationObstacleX;
    private float powerUpZ;
    private float powerUpX;
    public int velocity;

    private float timerObstacle = 1.5f;
    private float timerPowerUp = 5f;
    private float startTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateObstacles", startTime, timerObstacle);
        InvokeRepeating("GeneratePoweUp", startTime, timerPowerUp);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void GenerateObstacles() {
        int randomLane = Random.Range(0, 3);
        int indexObstacles = Random.Range(0, obstacles.Length);
        Debug.Log(randomLane);
        Vector3 posGeneration;
        switch (randomLane)
        {
            case 0:
                posGeneration =new Vector3 (24.1f, 0.18f, -1.17f);
                break;
            case 1:
                posGeneration = new Vector3(24.1f, 0.18f, -3.99f);
                break;
            default:
                posGeneration = new Vector3(24.1f, 0.18f, -6.61f);
                break;
        }

        switch (indexObstacles)
        {
            case 0:
                posGeneration = new Vector3(posGeneration.x, 0.41f, posGeneration.z);
                break;
            case 1:
                posGeneration = new Vector3(posGeneration.x, 1.096f, posGeneration.z);
                break;
            default:
                break;
        }

        Instantiate(obstacles[indexObstacles], posGeneration, obstacles[indexObstacles].gameObject.transform.rotation);
    
    }


    void GeneratePoweUp()
    {
        int randomLanePowerUp = Random.Range(0, 2);
        int indexPowerUp = Random.Range(0, powerUps.Length);
        Vector3 posGeneration;
        switch (randomLanePowerUp)
        {
            case 0:
                posGeneration = new Vector3(24.1f, 0.85f, -0.75f);
                break;
            case 1:
                posGeneration = new Vector3(24.1f, 0.85f, -3.51f);
                break;
            default:
                posGeneration = new Vector3(24.1f, 0.85f, -6.22f);
                break;
        }

        Instantiate(powerUps[indexPowerUp], posGeneration, powerUps[indexPowerUp].gameObject.transform.rotation);

    }

}
