using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    private CreditsManager credits;

    void Start()
    {
        credits = GameObject.Find("Player").GetComponent<CreditsManager>();
    }

    void OnDeath()
    {
        credits.AddCredits(50);
        Destroy(gameObject);
    }

    public void RecieveDamage(float d)
    {
        health -= d;

        credits.AddCredits(10);
        if (health <= 0)
        {
            OnDeath();
        }
        else
        {
            Debug.Log(gameObject.name + " now has " + health.ToString("F2") + " health.");
        }
    }
}
