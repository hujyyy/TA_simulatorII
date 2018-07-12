using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Game1Manager manager;
    private Text txt;
    private int time;
    public float totaltime;
   
	// Use this for initialization
	void Start () {
        time = 0;
        txt = GetComponent<Text>();
        txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (!manager.gameRunning||manager.gameover) return;
        if (totaltime <= 0) {
            txt.text = "";
            manager.gameRunning = false;
            manager.End();
            return;
        }
        totaltime -= Time.deltaTime;
        int min = (int)(totaltime / 60f);
        int sec = (int)(totaltime - min * 60f);
        if (sec >= 10) txt.text = (min).ToString() + ":" + (sec).ToString();
        else txt.text = (min).ToString() + ":0" + (sec).ToString();
	}
}
