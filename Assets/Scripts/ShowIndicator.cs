using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject Indicator;
    private GameObject IndicatorIns;
    // Start is called before the first frame update
    void Start()
    {
        this.IndicatorIns = Instantiate(Indicator);
        this.IndicatorIns.transform.position = this.gameObject.transform.position + new Vector3(0, 2.5f, 0);
        this.IndicatorIns.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.IndicatorIns.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.IndicatorIns.SetActive(false);
    }
}
