using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Game1Manager manager;
    private Text txt;
    private int time;
    public float totaltime = 120;
	// Use this for initialization
	void Start () {
        time = 0;
        txt = GetComponent<Text>();
        txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (!manager.gameRunning) return;
        totaltime -= Time.deltaTime;
        int min = (int)(totaltime / 60f);
        int sec = (int)(totaltime - min * 60f);
        txt.text = (min).ToString() + ":" + (sec).ToString();
        Debug.Log(sec); 
	}
}
