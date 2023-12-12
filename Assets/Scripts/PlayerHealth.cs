using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public enum HealState
    {
        Full,
        Waiting,
        Healing
    }

    float health;
    public int maxHealth;
    public float regenMultiplier;

    private bool healFlag;
    private float healTimer;
    HealState healState;

    GameManager gameManager;

    UIManager uiManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        DefaultState();
    }

    // Update is called once per frame
    void Update()
    {
        if (healState == HealState.Waiting)
        {
            healTimer -= Time.deltaTime;
            if (healTimer < 0)
            {
                healState = HealState.Healing;
            }
        }
        else if (healState == HealState.Healing)
        {
            RegenerateHealthTick();
        }
        else if (healState == HealState.Full && !healFlag)
        {
            DefaultState();
        }
        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

    public void DefaultState()
    {
        healState = HealState.Full;
        healTimer = 2.0f;
        health = maxHealth;
        healFlag = true;
    }

    public void RegenerateHealthTick()
    {
        health += Time.deltaTime * regenMultiplier;
        health = Mathf.Clamp(health, 0, maxHealth);
        uiManager.SetHealthText(health);
    }

    public void ReceiveDamage(int amount)
    {
        health -= amount;
        healFlag = false;
        healTimer = 2.0f;
        healState = HealState.Waiting;
        uiManager.SetHealthText(health);
    }
}
