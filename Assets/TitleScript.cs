using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
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

    public void StartGame()
    {
        Application.LoadLevel("GameplayScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
