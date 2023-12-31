using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health;
    public int attack;

    public float attackDelay;
    bool attackCooldown;

    public LayerMask playerLayer;
    private Transform player;
    // Start is called before the first frame update
    private NavMeshAgent enemy;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        enemy = GetComponent<NavMeshAgent>();
        attackCooldown = false;
    }

    private void Update()
    {
        if (CalculateDistance(transform.position, player.position) >= 2f)
        {
            enemy.SetDestination(player.position);
        }
        else if (!attackCooldown)
        {
            Attack();
        }
    }

    void OnDeath()
    {
        EnemySpawnManager.Instance.enemiesActive--;
        CreditsManager.Instance.AddCredits(70);
        Destroy(gameObject);
    }

    float CalculateDistance(Vector3 a, Vector3 b)
    {
        float res = Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z));
        return res;
    }

    void Attack()
    {
        Debug.Log("Attempted to Attack");
        attackCooldown = true;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2f, playerLayer))
        {
            PlayerHealth health = hit.transform.GetComponent<PlayerHealth>();
            health.ReceiveDamage(attack);
        }
        Invoke(nameof(RefreshCooldown), attackDelay);
        enemy.SetDestination(player.transform.position);
    }

    void RefreshCooldown()
    {
        attackCooldown = false;
    }

    public void RecieveDamage(float d)
    {
        health -= d;

        CreditsManager.Instance.AddCredits(10);
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
