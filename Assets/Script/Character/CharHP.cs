using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharHP : MonoBehaviour
{
    public Image charHP;

    public void UpdateHP(float currentHP, float maxHP)
    {
        charHP.fillAmount = currentHP/maxHP;
    }
    
}
