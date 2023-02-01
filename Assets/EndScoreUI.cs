using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScoreUI : MonoBehaviour
{
    // Use this for initialization
    Text scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Final Score: " + Global.finalScore;
        // + globalObj.score.ToString();
    }
}
