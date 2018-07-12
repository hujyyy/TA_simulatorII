using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Ball : MonoBehaviour
{
    private Rigidbody2D rig2D;

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rig2D.velocity = new Vector2(Mathf.Min(7, rig2D.velocity.x), Mathf.Min(7, rig2D.velocity.y));
    }
}