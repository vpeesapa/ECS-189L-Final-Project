using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Vector3 InitialPosition;
    [SerializeField] private float MaxDistance = 25.0f;
    [SerializeField] private float MovementSpeed = 10.0f;
    [SerializeField] private bool MoveVertically = false;
    [SerializeField] private bool MoveHorizontally = false;
    // 1 to start moving right/up first or -1 to start moving left/down first.
    [SerializeField] private int InitialDirection = 1;

    void Start()
    {
        this.transform.position = this.InitialPosition;
    }

    void Update()
    {
        float deltaMovement = (Mathf.Sin(Time.time * this.MovementSpeed) * Time.deltaTime * this.MaxDistance) * this.InitialDirection;
        Vector3 transformedPosition = this.transform.position;
        if(MoveHorizontally && !MoveVertically)
        {
            // If the platform moves horizontally.
            transformedPosition.x += deltaMovement;
            this.transform.position = transformedPosition;
        }
        else if(MoveVertically && !MoveHorizontally)
        {
            // If the platform moves vertically.
            transformedPosition.y += deltaMovement;
            this.transform.position = transformedPosition;
        }
    }
}
