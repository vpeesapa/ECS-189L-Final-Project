using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 20.0f;
    [SerializeField] private float MovementSpeed = 2.5f;
    [SerializeField] private int InitialDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {        
        float deltaMovement = (Mathf.Sin(Time.time * this.MovementSpeed) * Time.deltaTime * this.MaxDistance) * this.InitialDirection;
        Vector3 transformedPosition = this.transform.position;
        transformedPosition.x += deltaMovement;
        this.transform.position = transformedPosition;

        if(deltaMovement > 0.0f)
        {
            this.transform.localScale = new Vector2(this.InitialDirection, 1);
        }

        else
        {
            this.transform.localScale = new Vector2(-this.InitialDirection, 1);
        }
    }
}
