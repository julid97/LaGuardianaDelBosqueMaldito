using System;
using UnityEngine;
using UnityEngine.UI;
public class UiHealthManager : MonoBehaviour
{
    private int health;

    private int maxHealth;

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    public PlayerHealth playerhealth;


    private void Update()
    {   

        health = playerhealth.health;

        maxHealth = playerhealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
