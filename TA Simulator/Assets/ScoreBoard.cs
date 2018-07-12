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
    
    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        Player1_score = 0;
        Player2_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = Player1_score.ToString() + " : "+ Player2_score.ToString();
	}
}
