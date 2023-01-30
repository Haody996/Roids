using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BulletUI : MonoBehaviour
{
    Global globalObj;
    UnityEngine.UI.Text bulletText;
    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        bulletText = gameObject.GetComponent<UnityEngine.UI.Text>();
    }
    // Update is called once per frame
    void Update()
    {
        bulletText.text = "Bullets: " + globalObj.bulletsRemaining.ToString();
    }
}
