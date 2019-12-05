using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField] private float SawSpeed = 1.0f;
    [SerializeField] private float MaxDistance = 25.0f;
    [SerializeField] private bool MoveVertically = false;
    [SerializeField] private bool MoveHorizontally = false;
    // 1 to start moving right/up first or -1 to start moving left/down first.
    [SerializeField] private int InitialDirection = -1;

    void Start()
    {

    }

    void Update()
    {
        var deltaMovement = (Mathf.Sin(Time.time * this.SawSpeed) * Time.deltaTime * this.MaxDistance) * this.InitialDirection;
        var transformedPosition = this.transform.position;

        if(MoveHorizontally && !MoveVertically)
        {
            // If the saw moves horizontally.
            transformedPosition.x += deltaMovement;
            this.transform.position = transformedPosition;
        }
        else if(MoveVertically && !MoveHorizontally)
        {
            // If the saw moves vertically.
            transformedPosition.y += deltaMovement;
            this.transform.position = transformedPosition;
        }
    }

}