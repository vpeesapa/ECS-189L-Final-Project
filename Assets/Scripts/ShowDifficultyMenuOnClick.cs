using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDifficultyMenuOnClick : MonoBehaviour
{
    [SerializeField] GameObject DifficultyMenu;
    // Update is called once per frame
    public void ShowDifficultyMenu()
    {
        this.transform.parent.gameObject.SetActive(false);
        this.DifficultyMenu.SetActive(true);

    }
}
