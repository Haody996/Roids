using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAlienScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int pointValue;
    public float speed;
    public int direction;
    void Start()
    {
        pointValue = 300;
        speed = 0.007f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updatedPosition = gameObject.transform.position;
        updatedPosition.x += direction * speed;
        gameObject.transform.position = updatedPosition;

        if (gameObject.transform.position.x > 20 || gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
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
        Destroy(gameObject);
    }

}
