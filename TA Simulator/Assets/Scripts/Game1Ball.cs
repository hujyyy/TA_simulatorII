using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Game1Ball : MonoBehaviour
{
    public Game1Manager manager;
    private Rigidbody2D rig2D;
    public ScoreBoard scoreboard;
    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

        rig2D.velocity = new Vector2(Mathf.Min(7, rig2D.velocity.x), Mathf.Min(7, rig2D.velocity.y));
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (manager.gameover) gameObject.SetActive(false);
        manager.Play_goal();
        if (col.gameObject.tag == "gate2") {
            scoreboard.Player1_score += 1;
            manager.player2.GetComponent<Game1Player>().Bighead();
        }
        if (col.gameObject.tag == "gate1") {
            scoreboard.Player2_score += 1;
            manager.player1.GetComponent<Game1Player>().Bighead();
        }

        manager.ResetGame();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(12);
        if (GetComponent<Rigidbody2D>().velocity.x > 2 || GetComponent<Rigidbody2D>().velocity.y > 2) manager.Play_ball();
    }
}