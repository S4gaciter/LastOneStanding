using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    float distance = 3.0f;
    public Transform origin;
    public LayerMask interactible;
    public KeyCode interactionKey;
    public Text uiText;

    private Ray ray;

    // Update is called once per frame
    void Update()
    {
        uiText.enabled = false;
        ray.origin = transform.position;
        ray.direction = transform.forward;
        CheckForInteractibles();
    }

    void CheckForInteractibles()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, distance, interactible))
        {
            if (hit.transform.gameObject.GetComponent<Interactible>() != null)
            {
                Interactible data = hit.transform.gameObject.GetComponent<Interactible>();

                uiText.text = data.interactionText;
                uiText.enabled = true;
                if (Input.GetKeyDown(interactionKey))
                {
                    data.ReceiveInteraction();
                }
            }
            else { Debug.Log("Interactor hit interactible, but interactible did not have Interactible component"); }
        }
        else
        {
            uiText.enabled = false;
        }
    }
}
