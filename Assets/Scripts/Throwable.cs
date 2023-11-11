using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float throwForce;
    public KeyCode throwKey = KeyCode.G;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey))
        {
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform);

        if (projectile.GetComponent<Rigidbody>() != null)
        {
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, throwForce), ForceMode.Impulse);
        }
    }
}
