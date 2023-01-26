using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using Random = System.Random;

public class AlienScript : MonoBehaviour
{
    public int pointValue;
    public float fireTimer;
    public float turnTimer;
    public float downTimer;
    public float downPeriod;
    public float firePeriod;
    public float turnPeriod;
    public float speed;
    public int direction;
    public GameObject alienBullet;
    public float delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = 0.001f;
        pointValue = 20;
        direction = 1;
        fireTimer = 0;
        turnTimer = 0;
        downTimer = 0;
        var rand = new Random();
        firePeriod = rand.Next(5,100);
        turnPeriod = 7.0f;
        downPeriod = 2 * turnPeriod;
        speed = 0.003f;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }
    // Update is called once per frame
    void Update()
    {

        fireTimer += Time.deltaTime;
        turnTimer += Time.deltaTime;
        downTimer += Time.deltaTime;
        if (fireTimer > firePeriod)
        {
            fireTimer = 0;
            UnityEngine.Debug.Log("Alien Fire! ");
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(90 * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(90 * Mathf.PI / 180);

            GameObject obj = Instantiate(alienBullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
            AlienBulletScript b = obj.GetComponent<AlienBulletScript>();
            // set the direction the Bullet will travel in
            Quaternion rot = Quaternion.Euler(new Vector3(0, -90, 0));
            b.heading = rot;
        }

        if (turnTimer > turnPeriod)
        {
            Vector3 updatedDownPosition = gameObject.transform.position;
            updatedDownPosition.z -= 2;
            gameObject.transform.position = updatedDownPosition;
            turnTimer = 0;
            direction *= -1;
            delta += 0.001f;
            speed += delta;
            turnPeriod -= 0.3f;

        }

        if (gameObject.transform.position.z < 0)
        {
            UnityEngine.Application.LoadLevel("EndScene");
        }

        Vector3 updatedPosition = gameObject.transform.position;
        updatedPosition.x += direction*speed;
        gameObject.transform.position = updatedPosition;

    }

    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathKnell,
        gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        g.aliensRemaining -= 1;
        Destroy(gameObject);
    }

        public void MoveLeft()
    {
        Vector3 updatedPosition = gameObject.transform.position;
        updatedPosition.x -= 0.1f;
        gameObject.transform.position = updatedPosition;
    }
    public void MoveRight()
    {
        Vector3 updatedPosition = gameObject.transform.position;
        updatedPosition.x += 0.1f;
        gameObject.transform.position = updatedPosition;
    }

    public void Turn() {
        Vector3 updatedDownPosition = gameObject.transform.position;
        updatedDownPosition.z -= 1;
        gameObject.transform.position = updatedDownPosition;
        direction *= -1;
        delta += 0.001f;
        speed += delta;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Player"))
        {
            Ship player = collider.gameObject.GetComponent<Ship>();
            player.LoseALife();
            // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Asteroid"))
        {
            Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
            // let the other object handle its own death throes
            roid.Die();
            // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Bullet"))
        {

        }
        else
        {
            UnityEngine.Debug.Log("Collided with " + collider.tag);
        }
    }
}
