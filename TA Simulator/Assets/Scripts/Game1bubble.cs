using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1bubble : MonoBehaviour {

    public string[] texts;
	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = texts[Random.Range(0,texts.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
