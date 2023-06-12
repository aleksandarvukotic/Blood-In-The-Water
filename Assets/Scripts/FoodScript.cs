using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] float foodSpeed;
    float foodOffsetX = -2f;

    void Update()
    {
        transform.Translate(Vector2.down * foodSpeed * Time.deltaTime);

        if (transform.position.x <= foodOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
