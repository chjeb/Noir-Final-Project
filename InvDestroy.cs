using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvDestroy : MonoBehaviour
{
    [SerializeField] private GameController _GC;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_GC.IsInvincible == false && collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}