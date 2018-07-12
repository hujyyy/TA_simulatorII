using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    private AudioSource audioSource;

    public Game1Ball ball;
    public GameObject player1;
    public GameObject player2;
    public GameObject npc;
    public Vector2 npcInPosition;
    public Vector2 npcOutPosition;
    public float npcMoveSpeed;
    public GameObject speechBubble;
    public Sprite speechBubbleBallSprite;
    public Vector3 speechBubbleBallSize;

    public Sprite speechBubbleNormalSprite;
    public Vector3 speechBubbleBallNormalSize;
    public Vector3 speechBubbleBallNormalPosition;

    public float chairOutYPosition;
    private float chairStartYPosition;
    public GameObject[] tables;

    public bool gameover;
    public SpriteRenderer bg;
    public ScoreBoard scoreboard;
    public GameObject left_bubble;
    public GameObject right_bubble;

    public AudioClip ball_audio;
    public AudioClip head_audio;
    public AudioClip goal_audio;
    public void ResetGame()
    {
        StopCoroutine("ResetBall");
        StartCoroutine(ResetBall(true));
    }

    public GameObject[] chairs;

    private float delay = 0.2f;

    public bool gameRunning;

    public void Play_ball() {
        audioSource.PlayOneShot(ball_audio);
    }
    public void Play_head() {
        audioSource.PlayOneShot(head_audio);
    }
    public void Play_goal() {
        audioSource.PlayOneShot(goal_audio);
    }





    public void Start()
    {
        gameover = false;
        chairStartYPosition = chairs[0].transform.position.y;
        StartCoroutine("Start_IE");
        player1.GetComponent<PolygonCollider2D>().enabled = false;
        player2.GetComponent<PolygonCollider2D>().enabled = false;
        speechBubble.GetComponent<CircleCollider2D>().sharedMaterial.bounciness = 1.0f;
        bg.color = new Color(1, 1, 1, 0);

        left_bubble.SetActive(false);
        right_bubble.SetActive(false);

        audioSource = GetComponent<AudioSource>();

    }
    public void Update (){
        if (!gameover) return;
        left_bubble.SetActive(false);
        right_bubble.SetActive(false);
        if (scoreboard.Player1_score > scoreboard.Player2_score)
        {
            if (player1.transform.position.x < 0)
            {
                right_bubble.transform.position = player1.GetComponent<Game1Player>().head.transform.position;
                right_bubble.SetActive(true);
            }
            else
            {
                left_bubble.transform.position = player1.GetComponent<Game1Player>().head.transform.position;
                left_bubble.SetActive(true);
            }
        }
        else
        {
            if (player2.transform.position.x < 0)
            {
                right_bubble.transform.position = player2.GetComponent<Game1Player>().head.transform.position;
                right_bubble.SetActive(true);
            }
            else
            {
                left_bubble.transform.position = player2.GetComponent<Game1Player>().head.transform.position;
                left_bubble.SetActive(true);
            }
        }






    }
    public void End() {
        gameover = true;
        StartCoroutine("End_IE");
        foreach (var table in tables) foreach (var col in table.GetComponents<BoxCollider2D>()) col.enabled = false;

        player1.GetComponent<Rigidbody2D>().gravityScale = 3;
        //player1.GetComponent<PolygonCollider2D>().sharedMaterial.bounciness = 0.3f;
        player2.GetComponent<Rigidbody2D>().gravityScale = 3;
        //player1.GetComponent<PolygonCollider2D>().sharedMaterial.bounciness = 0.3f;

        speechBubble.GetComponent<Rigidbody2D>().gravityScale = 3;
        speechBubble.GetComponent<CircleCollider2D>().sharedMaterial= null;


    }


    public IEnumerator End_IE()
    {
        gameRunning = false;
        foreach (var table in tables)
        {
            table.GetComponent<Game1Table>().move = false;
            table.GetComponent<Game1Table>().moveback = true;
        }
        while (chairs[0].transform.position.y < chairStartYPosition)
        {
            yield return new WaitForEndOfFrame();
            foreach (var chair in chairs)
            {
                chair.transform.position = Vector2.MoveTowards(chair.transform.position, new Vector2(chair.transform.position.x, chairStartYPosition), Time.deltaTime * npcMoveSpeed);
            }
        }
        while (bg.color.a > 0)
        {
            yield return new WaitForEndOfFrame();
            bg.color -= new Color(0, 0, 0, 1 * Time.deltaTime);
        }


    }

    private IEnumerator Start_IE()
    {
        yield return ResetBall(false);
        yield return new WaitForSeconds(delay);
        while (bg.color.a < 1)
        {
            yield return new WaitForEndOfFrame();
            bg.color += new Color(0, 0, 0, 1 * Time.deltaTime);
        }
        foreach (var table in tables)
        {
            table.GetComponent<Game1Table>().move = true;
        }
        while (chairs[0].transform.position.y > chairOutYPosition)
        {
            yield return new WaitForEndOfFrame();
            foreach (var chair in chairs)
            {
                chair.transform.position = Vector2.MoveTowards(chair.transform.position, new Vector2(chair.transform.position.x, chairOutYPosition), Time.deltaTime * npcMoveSpeed);
            }
        }
        yield return new WaitForSeconds(delay);
        player1.GetComponent<PolygonCollider2D>().enabled = true;
        player2.GetComponent<PolygonCollider2D>().enabled = true;
        gameRunning = true;
    }

    private IEnumerator ResetBall(bool startGame)
    {
        gameRunning = false;
        speechBubble.SetActive(false);
        speechBubble.transform.position = speechBubbleBallNormalPosition;
        speechBubble.transform.localScale = speechBubbleBallNormalSize;
        speechBubble.GetComponent<SpriteRenderer>().sprite = speechBubbleNormalSprite;
        speechBubble.transform.eulerAngles = Vector3.zero;

        npc.GetComponent<Game1NPC>().NewSprite();

        while (Vector2.Distance(npcInPosition, npc.transform.position) > .05f)
        {
            yield return new WaitForEndOfFrame();
            npc.transform.position = Vector2.MoveTowards(npc.transform.position, npcInPosition, npcMoveSpeed * Time.deltaTime);
        }
        yield return new WaitForSeconds(delay);
        speechBubble.SetActive(true);
        yield return new WaitForSeconds(delay);
        speechBubble.GetComponent<SpriteRenderer>().sprite = speechBubbleBallSprite;
        yield return new WaitForSeconds(delay);
        while (speechBubble.transform.localScale.x > speechBubbleBallSize.x)
        {
            yield return new WaitForEndOfFrame();
            speechBubble.transform.localScale = Vector3.MoveTowards(speechBubble.transform.localScale, speechBubbleBallSize, Time.deltaTime);
        }
        yield return new WaitForSeconds(delay);
        while (Vector2.Distance(npcOutPosition, npc.transform.position) > .05f)
        {
            yield return new WaitForEndOfFrame();
            npc.transform.position = Vector2.MoveTowards(npc.transform.position, npcOutPosition, npcMoveSpeed * Time.deltaTime);
        }

        if (startGame)
            gameRunning = true;
    }
}