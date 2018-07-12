using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
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

    public float chairOutYPosition;
    public GameObject[] tables;
    public GameObject[] chairs;

    private float delay = 0.2f;

    public bool gameRunning;

    public void Start()
    {
        StartCoroutine("Start_IE");
        player1.GetComponent<PolygonCollider2D>().enabled = false;
        player2.GetComponent<PolygonCollider2D>().enabled = false;

    }

    private IEnumerator Start_IE()
    {
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
        yield return new WaitForSeconds(delay);
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
}