using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject alienToSpawn;
    public GameObject movingAlienToSpawn;
    public float timer;
    public float spawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoords;
    public int score;
    public int lives;
    public int aliensRemaining;

    void Start()
    {
        aliensRemaining = 50;
        score = 0;
        timer = 0;
        lives = 3;
        spawnPeriod = 15.0f;
        numberSpawnedEachPeriod = 3;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
        for (int z = 10; z < 20; z += 2)
        {
            for (int x = -10; x < 10; x += 2)
            {
                Instantiate(alienToSpawn,
                new Vector3(x, 0, z),
                Quaternion.identity);
            }

        }

    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnPeriod)
        {
            timer = 0;
            GameObject obj = Instantiate(movingAlienToSpawn,
                        new Vector3(20, 0, 20),
                        Quaternion.identity
                        ) as GameObject;
            MovingAlienScript a = obj.GetComponent<MovingAlienScript>();
            a.direction = -1;
        }

        if (lives < 1)
        {
            Application.LoadLevel("EndScene");
        }

        if (aliensRemaining < 1)
        {
            aliensRemaining = 50;
            for (int x = -10; x < 12; x += 2)
            {
                Instantiate(alienToSpawn,
                new Vector3(x, 0, 12),
                Quaternion.identity);
            }
        }
    }


}
