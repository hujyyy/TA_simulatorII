using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Table : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public bool move;
    public Vector2 endPosition;
    public float endScale;
    public float endRotation;
    public float moveSpeed;
    public float scaleSpeed;
    public float rotateSpeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
	}
}
