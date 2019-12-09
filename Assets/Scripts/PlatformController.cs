using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 25.0f;
    [SerializeField] private float MovementSpeed = 10.0f;
    [SerializeField] private bool MoveVertically = false;
    [SerializeField] private bool MoveHorizontally = false;
    // 1 to start moving right/up first or -1 to start moving left/down first.
    [SerializeField] private int InitialDirection = 1;
    private Vector3 InitialPosition;

    void Start()
    {
        this.InitialPosition = this.transform.position;
    }

    void Update()
    {
        Vector3 position = this.InitialPosition;
        if(MoveHorizontally && !MoveVertically)
        {
            // If the platform moves horizontally.
            position.x += (Mathf.Sin(Time.time * this.MovementSpeed) + 1) * this.InitialDirection * this.MaxDistance / 2;
        }
        else if(MoveVertically && !MoveHorizontally)
        {
            // If the platform moves vertically.
            position.y += (Mathf.Sin(Time.time * this.MovementSpeed) + 1) * this.InitialDirection * this.MaxDistance / 2;
        }
        this.transform.position = position;
    }
}
