using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private UIManager healthBar;


    public void UpdateHealthBar(int current, int max)
    {
        healthBar.SetValues(current, max);

    }
}
