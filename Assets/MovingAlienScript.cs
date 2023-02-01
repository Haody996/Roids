using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAlienScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int pointValue;
    public float speed;
    public int direction;
    // public AudioClip ufo;
    void Start()
    {
        pointValue = 300;
        speed = 0.02f;
        // AudioSource.PlayClipAtPoint(ufo, gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updatedPosition = gameObject.transform.position;
        updatedPosition.x += direction * speed;
        gameObject.transform.position = updatedPosition;

        if (gameObject.transform.position.x > 30 || gameObject.transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }

    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public GameObject deadAlien;
    public void Die()
    {
        Instantiate(deadAlien, gameObject.transform.position, Quaternion.identity);
        
        AudioSource.PlayClipAtPoint(deathKnell,gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        GetComponent<AudioSource>().Stop();
        Destroy(gameObject);
    }

}
