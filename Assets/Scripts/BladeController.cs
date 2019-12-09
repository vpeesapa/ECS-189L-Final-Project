using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    [SerializeField] private float SawSpeed = 1.0f;
    [SerializeField] private float MaxDistance = 25.0f;
    [SerializeField] private bool MoveVertically = false;
    [SerializeField] private bool MoveHorizontally = false;
    [SerializeField] private float RotationsPerMinute = 10.0f;
    [SerializeField] private bool RotateClockwise = false;
    [SerializeField] private bool RotateAntiClockwise = false;
    // 1 to start moving right/up first or -1 to start moving left/down first.
    [SerializeField] private int InitialDirection = -1;

    private Vector3 InitialPosition;

    void Awake()
    {
        this.InitialPosition = this.transform.position;
    }

    void Update()
    {
        // Rotation of the blade.
        if(RotateClockwise && !RotateAntiClockwise)
        {
            // Rotates the blade in the clockwise direction.
            transform.Rotate(-1 * Vector3.forward * RotationsPerMinute);
        }
        else if(RotateAntiClockwise && !RotateClockwise)
        {
            // Rotates the blade in the anti-clockwise direction.
            transform.Rotate(Vector3.forward * RotationsPerMinute);
        }

        // Linear Translation of the blade.
        Vector3 position = this.InitialPosition;
        var offset = (Mathf.Sin(Time.time * this.SawSpeed) + 1) * this.InitialDirection * this.MaxDistance / 2;
        if(MoveHorizontally && !MoveVertically)
        {
            // If the blade moves horizontally.
            position.x += offset;
        }
        else if(MoveVertically && !MoveHorizontally)
        {
            // If the blade moves vertically.
            position.y += offset;
        }
        this.transform.position = position;
    }

}