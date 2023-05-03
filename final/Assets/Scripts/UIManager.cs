using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int minValue;
    private int maxValue;

    [SerializeField] private Image fillImg;



    public void SetValues(int min, int max)
    {
        minValue = min;
        maxValue = max;
      
        FillHealthBar();
    }

    private void FillHealthBar()
    {
        
        float fill = (float)minValue / (float)maxValue;
        fillImg.fillAmount = fill;
    }
}
