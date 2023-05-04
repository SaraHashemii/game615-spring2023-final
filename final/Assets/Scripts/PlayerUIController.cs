using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

   


    public void UpdateHealthBar(int current, int max)
    {
        uiManager.SetValuesToHealthBar(current, max);

    }


    public void UpdateScore(int score)
    {
        uiManager.SetValueToScore(score);

    }
}
