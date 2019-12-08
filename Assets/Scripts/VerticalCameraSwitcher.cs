using UnityEngine;

public class VerticalCameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject Border;
    [SerializeField] private GameObject Player;
    private Camera SecondaryCamera;
    private Camera PrimaryCamera;

    void Start()
    {
        this.SecondaryCamera = GetComponent<Camera>();
        this.PrimaryCamera = Camera.main;
    }

    void Update()
    {
        if (this.Player.transform.position.y > Border.transform.position.y)
        {
            this.SecondaryCamera.enabled = true;
            this.PrimaryCamera.enabled = false;
        }
        else
        {
            this.PrimaryCamera.enabled = true;
            this.SecondaryCamera.enabled = false;
        }
    }
}
