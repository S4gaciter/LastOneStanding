using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public float lifetime = 5.0f;
    public float explosionRadius;
    public float explosionDamage;

    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Detonate), lifetime);
    }

    void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);

        foreach(Collider collider in colliders)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.RecieveDamage(explosionDamage);
            }
        }

        RemoveExplosive();
    }

    void RemoveExplosive()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
