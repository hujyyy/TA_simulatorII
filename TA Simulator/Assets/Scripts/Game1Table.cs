using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Table : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public bool move;
    public bool moveback;
    public Vector2 endPosition;
    public float endScale;
    public float endRotation;
    public float moveSpeed;
    public float scaleSpeed;
    public float rotateSpeed;
    private Vector2 startPosition;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition, Time.deltaTime * moveSpeed);
            //transform.localScale = Vector2.MoveTowards(transform.localScale, endScale, Time.deltaTime * speed);
            spriteRenderer.size = new Vector2(Mathf.MoveTowards(spriteRenderer.size.x, endScale, Time.deltaTime * scaleSpeed), spriteRenderer.size.y);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.MoveTowardsAngle(transform.eulerAngles.z, endRotation, Time.deltaTime * rotateSpeed));
        }

        if (moveback) {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, Time.deltaTime * moveSpeed);
            spriteRenderer.size = new Vector2(Mathf.MoveTowards(spriteRenderer.size.x, 0.2f, Time.deltaTime * scaleSpeed), spriteRenderer.size.y);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0, Time.deltaTime * rotateSpeed));

        }
	}
}
