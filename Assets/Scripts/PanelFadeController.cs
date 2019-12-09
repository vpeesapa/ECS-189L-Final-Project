using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFadeController : MonoBehaviour
{
    [SerializeField] private Image UIPanelImage;
    [SerializeField] private Text UIText;

    private float FadeDelay = 20.0f;
    private float TimeSinceStarted = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var panelColor = this.UIPanelImage.color;
        var textColor = this.UIText.color;
        if(this.TimeSinceStarted >= FadeDelay)
        {
            // Need to fade the panel out after a certain delay.
            if(panelColor.a != 0.0f || textColor.a != 0.0f)
            {
                panelColor.a -= Time.deltaTime;
                textColor.a -= Time.deltaTime;
                this.UIPanelImage.color = panelColor;
                this.UIText.color = textColor;
                if(panelColor.a <= 0.1f && textColor.a <= 0.1f)
                {
                    this.UIPanelImage.gameObject.SetActive(false);
                    this.UIText.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            this.TimeSinceStarted += Time.deltaTime;
        }
    }
}
