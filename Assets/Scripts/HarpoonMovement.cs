using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
