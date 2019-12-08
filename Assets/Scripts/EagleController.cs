using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    [SerializeField] private GameObject LeftBound;
    [SerializeField] private GameObject RightBound;
    [SerializeField] private GameObject TopBound;
    [SerializeField] private GameObject BottomBound;
    [SerializeField] private float MovementSpeed = 10.0f;
    [SerializeField] private float RiseSpeed = 10.0f;

    void Start()
    {
        this.gameObject.transform.position = new Vector3(this.RightBound.transform.position.x, this.TopBound.transform.position.y, 0.0f);
    }

    void Update()
    {
        float timeDelta = Time.deltaTime;
        Vector3 pos = this.gameObject.transform.position;
        float movementDelta = this.MovementSpeed * timeDelta;

        if(pos.y > this.BottomBound.transform.position.y)
        {
            this.transform.position = new Vector3(pos.x - movementDelta, pos.y, 0.0f);
        } 

        else
        {
            this.transform.position = new Vector3(pos.x - movementDelta, this.BottomBound.transform.position.y, 0.0f);
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        } 

        if(pos.x < this.LeftBound.transform.position.x)
        {
            this.transform.position = new Vector3(pos.x - movementDelta, pos.y + movementDelta * this.RiseSpeed, 0.0f);
        }

        if(pos.y > this.TopBound.transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(this.RightBound.transform.position.x, this.TopBound.transform.position.y, 0.0f);
        }
    }
}
