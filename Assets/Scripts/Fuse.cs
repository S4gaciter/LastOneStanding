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
        if (Physics.SphereCast(transform.position, explosionRadius, Vector3.forward, out RaycastHit hit, 0, enemyLayer))
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.forward, 0, enemyLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.gameObject.GetComponent<Enemy>() != null)
                {
                    Debug.Log(hits[i].transform.gameObject.name + " took " + explosionDamage + " from an explosive.");
                    Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    enemy.RecieveDamage(explosionDamage);
                }
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
