using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 25.0f;
    [SerializeField] private float MovementSpeed = 10.0f;
    // 1 to start moving right first or -1 to start moving left first
    [SerializeField] private int InitialDirection = 1;

    void Start()
    {
        
    }

    void Update()
    {
        float deltaMovement = (Mathf.Sin(Time.time * this.MovementSpeed) * Time.deltaTime * this.MaxDistance) * this.InitialDirection;
        Vector3 transformedPosition = this.transform.position;
        transformedPosition.x += deltaMovement;
        this.transform.position = transformedPosition;
    }
}
