using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform playerOrigin;
    public Transform barrelOrigin;
    public LayerMask enemyLayer;

    [SerializeField] GunStats stats;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(playerOrigin.position, playerOrigin.forward, out RaycastHit hit, stats.range, enemyLayer))
        {
            if (hit.transform.gameObject.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                enemy.RecieveDamage(stats.damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(barrelOrigin.position, playerOrigin.forward * stats.range);
    }
}
