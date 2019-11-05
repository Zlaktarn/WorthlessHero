using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] float maxHealth = 0;
    [SerializeField] public float health;
    [SerializeField] public float dmgMultiplier;
    [SerializeField] BarScript healthBar;

    [SerializeField] public float attackDmg;

    public bool isDead = false;

    public float damageTaken;

    void Start()
    {
        health = maxHealth;

    }

    void Update()
    {
        healthBar.SetSize(health / maxHealth);

        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }
}
