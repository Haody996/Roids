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
        aliensRemaining = 40;
        score = 0;
        timer = 0;
        lives = 3;
        spawnPeriod = 15.0f;
        numberSpawnedEachPeriod = 3;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
        for (int y = 10; y < 20; y += 2)
        {
            for (int x = -8; x < 8; x += 2)
            {
                Instantiate(alienToSpawn,
                new Vector3(x, y, 0),
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
                        new Vector3(20, 20, 0),
                        Quaternion.identity
                        ) as GameObject;
            MovingAlienScript a = obj.GetComponent<MovingAlienScript>();
            a.direction = -1;
        }

        if (lives < 1)
        {
            Application.LoadLevel("EndScene");
        }

        if (aliensRemaining == 0)
        {
            aliensRemaining = 40;
            for (int y = 10; y < 20; y += 2)
            {
                for (int x = -8; x < 8; x += 2)
                {
                    Instantiate(alienToSpawn,
                    new Vector3(x, y, 0),
                    Quaternion.identity);
                }

            }
        }
    }


}
