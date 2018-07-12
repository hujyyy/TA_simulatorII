using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour {
    private Text txt;
    [HideInInspector]
    public int Player1_score;
    [HideInInspector]
    public int Player2_score;
    public Game1Manager manager;
    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        Player1_score = 1;
        Player2_score = 0;
        txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (!manager.gameRunning) return;
        txt.text = Player1_score.ToString() + " : "+ Player2_score.ToString();
	}
}
