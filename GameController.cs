using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int spikeDamage;
    [SerializeField] private int killDamage;
    [SerializeField] private int healthItemValue;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private InvincibilityBar _invincibilityBar;
    [SerializeField] private GameObject invincibilityCanvas;
    public bool IsInvincible;
    public float InvincibleDuration = 3f;


    public void Start()
    {
        IsInvincible = false;
        invincibilityCanvas.SetActive(IsInvincible);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("invincibilityItem"))
        {
            if (IsInvincible == false)
            {
                StartCoroutine("GetInvincible");
            }
        }

        if (collision.CompareTag("Obstacle") && IsInvincible == false)
        { 
            Damage();
        }

        if (collision.CompareTag("DeathZone"))
        {
            Kill();
        }

        else if (collision.CompareTag("healthItem"))
        {
            AddHealth();
        }
    }

    public void Damage()
    {   
        {
            _healthController.playerHealth = _healthController.playerHealth - spikeDamage;
            _healthController.UpdateHealth();

            if (_healthController.playerHealth <= 0)
            {
                _healthController.Die();
            }
        }
    }

    private void AddHealth()
    {
        if (_healthController.playerHealth < 5)
        {
            _healthController.playerHealth = _healthController.playerHealth + healthItemValue;
            _healthController.UpdateHealth();
        }
    }

    private void Kill()
    {
        _healthController.playerHealth = _healthController.playerHealth - killDamage;
        _healthController.UpdateHealth();

        if (_healthController.playerHealth <= 0)
        {
            _healthController.Die();
        }
    }

    IEnumerator GetInvincible()
    {
        IsInvincible = true;
        invincibilityCanvas.SetActive(IsInvincible);
        _invincibilityBar.AnimateBar();

        yield return new WaitForSeconds(InvincibleDuration);

        IsInvincible = false;
        invincibilityCanvas.SetActive(IsInvincible);
    }
}