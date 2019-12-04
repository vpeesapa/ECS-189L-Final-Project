using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject LeftBound;
    [SerializeField] private GameObject RightBound;
    [SerializeField] private GameObject TopBound;
    [SerializeField] private GameObject BottomBound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(this.Player.position.x, this.Player.position.y, this.Player.position.z - 1);

        float orthoSize = Camera.main.orthographicSize;
        if(newPosition.x - orthoSize <= this.LeftBound.transform.position.x)
        {
            newPosition.x = this.LeftBound.transform.position.x + orthoSize;
        }

        if(newPosition.x + orthoSize >= this.RightBound.transform.position.x)
        {
            newPosition.x = this.RightBound.transform.position.x - orthoSize;
        }

        if(newPosition.y + orthoSize >= this.TopBound.transform.position.y)
        {
            newPosition.y = this.TopBound.transform.position.y - orthoSize;
        }

        if(newPosition.y - orthoSize <= this.BottomBound.transform.position.y)
        {
            newPosition.y = this.BottomBound.transform.position.y + orthoSize;
        }

        this.gameObject.transform.position = newPosition;
    }
}
