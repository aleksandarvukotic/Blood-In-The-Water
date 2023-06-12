/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 100f;
    public float playerRotationSpeed = 40f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 playerMovement = new Vector2(moveHorizontal, moveVertical) * playerSpeed * Time.deltaTime;

        rb.velocity = playerMovement;

        if (playerMovement != Vector2.zero)
        {
            float angle = Mathf.Atan2(-playerMovement.x, playerMovement.y) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody2D rb;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move forward continuously
        if (isMoving)
        {
            rb.velocity = transform.up * playerSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        // Rotate left or right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        // Start moving or stop moving when the movement button is pressed or released
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }
    }
}