using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDestroy : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_healthController.playerHealth < 5 && collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
