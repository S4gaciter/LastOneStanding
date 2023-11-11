using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 100f;
    const float maxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Debug.Log("Enemy died, resetting health to " + maxHealth.ToString("F2"));
        health = maxHealth;
    }

    public void RecieveDamage(float d)
    {
        health -= d;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log(gameObject.name + " now has " + health.ToString("F2") + " health.");
    }
}
