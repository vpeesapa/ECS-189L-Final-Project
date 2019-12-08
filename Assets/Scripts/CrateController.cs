using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField] private GameObject CrateSpawn;
    [SerializeField] private GameObject BottomLine;

    void Start()
    {
        
    }

    void Update()
    {
        if(this.transform.position.y < this.BottomLine.transform.position.y)
        {
            this.transform.position = this.CrateSpawn.transform.position;
        }
    }
}
