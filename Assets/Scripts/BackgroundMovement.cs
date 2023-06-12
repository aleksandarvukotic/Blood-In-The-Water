using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float backgroundSpeed;

    private void Update()
    {
        transform.Translate(Vector3.left * backgroundSpeed * Time.deltaTime);
    }
}
