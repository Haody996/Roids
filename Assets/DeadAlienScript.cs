using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeadAlienScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioClip ammoPickup;
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(ammoPickup,gameObject.transform.position);
            GameObject obj = GameObject.Find("GlobalObject");
            Global g = obj.GetComponent<Global>();
            g.bulletsRemaining += 5;
            g.deadAlienCount -= 1;

            Destroy(gameObject);
        }
    }
}
