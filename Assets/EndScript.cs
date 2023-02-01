using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private GUIStyle buttonStyle;
 // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Restart()
    {
        Application.LoadLevel("GameplayScene");
    }

    public void Exit() {
        Application.Quit();
    }
}
