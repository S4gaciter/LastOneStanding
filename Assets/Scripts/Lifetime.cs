using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifetime);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
