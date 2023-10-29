using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    private void Start()
    {       
        UpdateHealth();
    }

    public void UpdateHealth()
    {  
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.white;
            }

            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    void ResetHealth()
    {
        playerHealth = maxHealth;
        UpdateHealth();
    }

    public void Die()
    {
        Respawn();
    }

    void Respawn()
    {
       Player.transform.position = respawnPoint.transform.position;
       ResetHealth();
    }
}