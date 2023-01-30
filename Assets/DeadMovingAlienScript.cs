using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMovingAlienScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioClip lifePickup;
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(lifePickup, gameObject.transform.position);
            GameObject obj = GameObject.Find("GlobalObject");
            Global g = obj.GetComponent<Global>();
            g.lives += 1;

            Destroy(gameObject);
        }
    }
}
