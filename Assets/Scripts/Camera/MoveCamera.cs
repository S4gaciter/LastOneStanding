using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform playerPos;

    private void Update()
    {
        transform.position = playerPos.position;
    }

}
