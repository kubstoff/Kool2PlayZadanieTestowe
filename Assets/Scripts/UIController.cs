using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text[] textfields;
    public Sprite[] textures;
    public Image selectedWeapon;
    public GameObject deathScreen;
    public Slider hp;

    private bool doOnce = true;


    private void Update()
    {
        hp.value = PlayerStats.Instance.playerHealth / PlayerStats.Instance.playerMaxHealth;

        textfields[1].text = PlayerStats.Instance.enemiesKilled.ToString();

        selectedWeapon.sprite = textures[PlayerStats.Instance.currentWeaponID];

        if (!PlayerStats.Instance.isAlive && doOnce)
        {
            doOnce = false;
            deathScreen.SetActive(true);
        }
    }
}