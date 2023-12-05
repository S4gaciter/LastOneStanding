using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float health;
    public int maxHealth;

    private float healTimer;
    private bool healing;

    GameManager gameManager;

    UIManager uiManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        healing = false;
        healTimer = 2.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!healing && health == maxHealth)
        {
            healTimer -= Time.deltaTime;
        }
        else if (healing && health != maxHealth)
        {
            health += Time.deltaTime;
            Mathf.Clamp(health, 0, maxHealth);
            uiManager.SetHealthText(health);
        }
        else if (healing && health == maxHealth)
        {
            healing = false;
            healTimer = 2.0f;
        }
        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

    public void ReceiveDamage(int amount)
    {
        health -= amount;
        healing = false;
        uiManager.SetHealthText(health);
    }
}
