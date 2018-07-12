using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    public Game1Ball ball;
    public Game1Player player1;
    public Game1Player player2;
    public GameObject npc;
    public Vector2 npcInPosition;
    public Vector2 npcOutPosition;
    public float npcMoveSpeed;
    public GameObject speechBubble;
    public Sprite speechBubbleBallSprite;
    public Vector3 speechBubbleBallSize;

    private float delay = 0.2f;

    public bool gameRunning;

    public void Start()
    {
        StartCoroutine("Start_IE");
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
        gameRunning = true;
    }
}