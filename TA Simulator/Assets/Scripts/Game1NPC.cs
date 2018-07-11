﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1NPC : MonoBehaviour
{
    public Sprite[] sprites;

	private void Awake ()
	{
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
	}
}