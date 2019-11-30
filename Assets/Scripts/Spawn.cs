using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Drop;
    // Start is called before the first frame update
    void Start()
    {
        var coin = Instantiate(Drop);
        coin.transform.position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
