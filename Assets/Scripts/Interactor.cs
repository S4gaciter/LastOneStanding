using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float distance;
    public Transform origin;
    public LayerMask interactible;
    public KeyCode interactionKey;

    private Ray ray;

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        CheckForInteractibles();
    }

    void CheckForInteractibles()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, distance, interactible))
        {
            Debug.Log(hit.collider.gameObject.name + " was hit!");
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
