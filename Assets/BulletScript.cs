using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BulletScript: MonoBehaviour
{
    public Vector3 thrust;
    public Quaternion heading;
    // Use this for initialization
    public GameObject deadBullet;
    void Start()
    {
        // travel straight in the X-axis
        thrust.y = 400.0f;
        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;
        // set the direction it will travel in
        GetComponent<Rigidbody>().MoveRotation(heading);
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }
    // Update is called once per frame
    void Update()
    { //Physics engine handles movement, empty for now.
        if (gameObject.transform.position.y > 30)
        {
            Destroy(gameObject);
            Instantiate(deadBullet,new Vector3(20, 30, 0),Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it?s the colliding
        // object we?re most interested in.
        Collider collider = collision.collider;
        if (collider.CompareTag("Asteroid"))
        {
            Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
            // let the other object handle its own death throes
            roid.Die();
            // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Alien"))
        {
            AlienScript alien = collider.gameObject.GetComponent<AlienScript>();
            // let the other object handle its own death throes
            alien.Die();
            // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else if (collider.CompareTag("MovingAlien"))
        {
            // UnityEngine.Debug.Log("Collided with " + collider.tag);
            MovingAlienScript a = collider.gameObject.GetComponent<MovingAlienScript>();
            // let the other object handle its own death throes
            a.Die();
            // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else if (collider.CompareTag("AlienBullet"))
        {
            Destroy(gameObject);
        }
        else
        {
            // if we collided with something else, print to console
            // what the other thing was
            // Debug.Log("Collided with " + collider.tag);
        }
    }
}
