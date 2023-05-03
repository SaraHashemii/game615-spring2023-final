using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] private UIManager healthBar;

    public void UpdateHealthBar(int current, int max)
    {
        healthBar.SetValues(current, max);

    }
}
