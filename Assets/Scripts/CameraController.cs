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
    private Camera AttachedCamera;

    // Start is called before the first frame update
    void Start()
    {
        AttachedCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(this.Player.position.x, this.Player.position.y, this.Player.position.z - 1);

        float verticalSize = AttachedCamera.orthographicSize;
        float horizontalSize = AttachedCamera.aspect * verticalSize;

        newPosition.x = Mathf.Clamp(newPosition.x,
                                    this.LeftBound.transform.position.x + horizontalSize,
                                    this.RightBound.transform.position.x - horizontalSize);
        newPosition.y = Mathf.Clamp(newPosition.y,
                                    this.BottomBound.transform.position.y + verticalSize,
                                    this.TopBound.transform.position.y - verticalSize);

        this.gameObject.transform.position = newPosition;
    }
}
