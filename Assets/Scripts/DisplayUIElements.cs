using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUIElements : MonoBehaviour
{
    public GameObject creditsMenu;
    private int counter;

    public void HideShowCredits()
    {
        counter++;
        if (counter % 2 == 0)
        {
            creditsMenu.SetActive(false);
        }
        else
        {
            creditsMenu.SetActive(true);
        }
    }

}
