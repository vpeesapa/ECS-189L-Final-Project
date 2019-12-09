using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 20.0f;
    [SerializeField] private float MovementSpeed = 2.5f;
    [SerializeField] private int InitialDirection = 1;
    private Vector2 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        this.InitialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 position = this.InitialPosition;
        position.x += (Mathf.Sin(Time.time * this.MovementSpeed) + 1) * this.InitialDirection * this.MaxDistance / 2;
        this.transform.position = position;
    }
}