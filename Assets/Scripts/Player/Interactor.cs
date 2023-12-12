using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    float distance = 3.0f;
    public Transform origin;
    LayerMask interactible;
    public KeyCode interactionKey;
    UIManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void Start()
    {
        uiManager.HideInteractionText();
    }
    // Update is called once per frame
    void Update()
    {
        interactible = LayerMask.GetMask("Interactible");
        CheckForInteractibles();
    }

    void CheckForInteractibles()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, interactible))
        {
            if (hit.transform.gameObject.GetComponent<Interactible>() != null)
            {
                Interactible data = hit.transform.gameObject.GetComponent<Interactible>();

                uiManager.SetInteractionText(data.interactionText);
                uiManager.ShowInteractionText();
                if (Input.GetKeyDown(interactionKey))
                {
                    data.ReceiveInteraction();
                }
            }
            else { Debug.Log("Interactor hit interactible, but interactible did not have Interactible component"); }
        }
        else
        {
            uiManager.HideInteractionText();
        }
    }
}
