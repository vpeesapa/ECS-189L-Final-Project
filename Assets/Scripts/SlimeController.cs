using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 20.0f;
    [SerializeField] private float MovementSpeed = 2.5f;
    [SerializeField] private int InitialDirection = 1;
    private Vector2 InitialPosition;

    void Start()
    {
        this.InitialPosition = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void Update()
    {        
        Vector2 previousPosition = this.transform.position;
        Vector2 position = this.InitialPosition;
        float movementDelta = (Mathf.Sin(Time.time * this.MovementSpeed) + 1) * this.InitialDirection * this.MaxDistance / 2;
        position.x += movementDelta;
        this.transform.position = position;

        var spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = (position.x - previousPosition.x < 0.0f);
    }
}