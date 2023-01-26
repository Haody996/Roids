using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    // Use this for initialization
    void Start()
    {
        // Vector3 default initializes all components to 0.0f
        // forceVector.x = 1.0f;
        rotation = -90;
    }
    /* forced changes to rigid body physics parameters should be done through the FixedUpdate()
    method, not the Update() method
    */
    void FixedUpdate()
    {
        // force thruster
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Vector3 updatedPosition = gameObject.transform.position;
            updatedPosition.x += 0.3f;
            gameObject.transform.position = updatedPosition;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Vector3 updatedPosition = gameObject.transform.position;
            updatedPosition.x -= 0.3f;
            gameObject.transform.position = updatedPosition;
        }
        Vector3 position = gameObject.transform.position;
        Quaternion rotation = gameObject.transform.rotation;
        if (position.z != 0)
        {
            position.z = 0;
            gameObject.transform.position = position;
        }

        if (position.y != 0)
        {
            position.y = 0;
            gameObject.transform.position = position;
        }

        if (rotation.z != 0)
        {
            rotation.z = 0;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
    public GameObject bullet; // the GameObject to spawn
    public AudioClip bulletSound;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire! " + rotation);
            /* we don’t want to spawn a Bullet inside our ship, so some
            Simple trigonometry is done here to spawn the bullet
            at the tip of where the ship is pointed.
            */
            AudioSource.PlayClipAtPoint(bulletSound,gameObject.transform.position);
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(rotation * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(rotation * Mathf.PI / 180);
            // instantiate the Bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
            BulletScript b = obj.GetComponent<BulletScript>();
            // set the direction the Bullet will travel in
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            b.heading = rot;
        }
    }

    public void LoseALife()
    {
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.lives -= 1;
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
