using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletScript: MonoBehaviour
{
    public Vector3 thrust;
    public Quaternion heading;
    // Use this for initialization
    void Start()
    {
        // travel straight in the X-axis
        thrust.x = -400.0f;
        heading = Quaternion.Euler(new Vector3(0, -90, 0));
        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;
        // set the direction it will travel in
        GetComponent<Rigidbody>().MoveRotation(heading);
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);

        GameObject alien = GameObject.FindGameObjectWithTag("Alien");
        Physics.IgnoreCollision(alien.GetComponent<Collider>(), GetComponent<Collider>(), true);
    }
    // Update is called once per frame
    void Update()
    { //Physics engine handles movement, empty for now.
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
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Alien"))
        {
            GameObject alien = GameObject.FindGameObjectWithTag("Alien");
            Physics.IgnoreCollision(alien.GetComponent<Collider>(), GetComponent<Collider>());
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Collided with " + collider.tag);
        }
    }
}
