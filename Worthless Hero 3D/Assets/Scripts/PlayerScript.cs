using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float attackDmg;
    public float xp;
    public float xpToLevel;
    public int level;
    public bool levelUp = false;


    [SerializeField] public int strength;
    [SerializeField] public int constitution;
    [SerializeField] public int intelligence;

    [SerializeField] BarScript healthBar;
    //[SerializeField] BarScript xpBar;

    public float damageDealt;

    //Inventory inventory;

    public bool GameOver = false;

    void Start()
    {
        health = 10 * constitution;
        maxHealth = health;
        attackDmg = strength;

        level = 1;
        xpToLevel = 4;
    }

    void Update()
    {
        //xpBar.SetSize(xp / xpToLevel);

        //if(xp >= xpToLevel)
        //{
        //    levelUp = true;
        //}

        if(levelUp)
        {
            level++;
            xp = xp - xpToLevel;
            xpToLevel = xpToLevel * 2;
            levelUp = false;
        }


        healthBar.SetSize(health / maxHealth);

        if (health <= 0)
        {
            GameOver = true;
            health = 0;
        }
    }

    public void HealingPotion()
    {
        //inventory = GetComponent<Inventory>();

        //if (inventory.HealthPotions > 0 && maxHealth > health)
        //{
        //    health += 5;
        //    inventory.HealthPotions -= 1;
        //    if (health > maxHealth)
        //        health = maxHealth;
        //}
    }
}
