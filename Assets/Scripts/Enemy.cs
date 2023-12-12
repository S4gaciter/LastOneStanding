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
    private CreditsManager credits;
    private NavMeshAgent enemy;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        credits = GameObject.Find("Player").GetComponent<CreditsManager>();
        enemy = GetComponent<NavMeshAgent>();
        attackCooldown = false;
    }

    private void Update()
    {
        if (CalculateDistance(transform.position, player.position) >= 2f || enemy.destination == null)
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
        credits.AddCredits(70);
        Destroy(gameObject);
    }

    float CalculateDistance(Vector3 a, Vector3 b)
    {
        float res = Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z));
        Debug.Log(res);
        return res;
    }

    void Attack()
    {
        Debug.Log("Attempted to Attack");
        attackCooldown = true;
        if (Physics.SphereCast(transform.position, 2.0f, transform.forward, out RaycastHit hit, 1.0f, playerLayer.value))
        {
            PlayerHealth health = GameObject.Find("Player").GetComponent<PlayerHealth>();
            health.ReceiveDamage(attack);
        }
        Invoke(nameof(RefreshCooldown), attackDelay);
    }

    void RefreshCooldown()
    {
        attackCooldown = false;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 2.0f);
    }
}
