using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField]
    private GameObject Spike;
    [SerializeField]
    private float SpawnTime;
    private float SpawnTimer;
    private Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        this.SpawnTimer = 0;
        this.Position = gameObject.transform.position;
    }

    
    void Update()
    {
        this.SpawnTimer += Time.deltaTime;
        if (this.SpawnTimer > this.SpawnTime)
        {
            var SpikeI = Instantiate(Spike);
            SpikeI.transform.position = new Vector3(this.Position.x, this.Position.y, 0);
            this.SpawnTimer = 0.0f;
            Destroy(SpikeI, 3.0f);
        }
    }
}
