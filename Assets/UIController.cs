using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text[] textfields;
    public Slider HP;



    private void Update()
    {
        HP.value = PlayerStats.Instance.playerHealth/PlayerStats.Instance.playerMaxHealth;

        textfields[1].text = PlayerStats.Instance.enemiesKilled.ToString();

    }
}
