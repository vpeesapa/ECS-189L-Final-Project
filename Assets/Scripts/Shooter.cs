using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float ShootDelay = 1.0f;
    [SerializeField] private float DestroyTime = 1.0f;
    [SerializeField] private GameObject Object;
    [SerializeField] private Vector2 Force = Vector2.zero;
    private float TimeToShoot;

    void Start()
    {
        this.TimeToShoot = Time.time + ShootDelay;
    }

    void Update()
    {        
        if (Time.time > TimeToShoot)
        {
            var projectile = Instantiate(Object, gameObject.transform.position, Quaternion.identity);
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Force);
            Destroy(projectile, DestroyTime);
            this.TimeToShoot = Time.time + ShootDelay;
        }
    }
}
