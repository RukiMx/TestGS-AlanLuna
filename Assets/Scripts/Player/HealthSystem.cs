using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData;

    private int _currentHealth;

    #region UNITY METHODS
    void Start()
    {
        _currentHealth = _characterData.MaxHealth;

        GetComponent<CharacterCollisionHandler>().OnObstacleHit = TakeDamage;
    }
    #endregion

    public void TakeDamage()
    {
        _currentHealth--;
        
        if(_currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        GameEvents.OnPlayerDead?.Invoke();
        GetComponentInChildren<Animator>().SetTrigger("Dead");
    }
}
