using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthValue;

    public int lives = 5;

    public void ChangeHealth(int Damage)
    {  
        lives -= Damage;
        healthValue.text = lives.ToString();
        
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("El player murió");

        gameObject.SetActive(false);
    }
}
