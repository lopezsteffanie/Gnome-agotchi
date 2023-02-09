using System.Threading;
using System.Security.Cryptography;
using UnityEngine;

public class MiniGamePetController : MonoBehaviour
{
    public float speed, jumpSpeed;
    private Rigidbody2D r2d;
    private bool grounded;

    private void OnEnable()
    {
        GetComponent<PetController>().enabled = false;
        r2d = GetComponent<Rigidbody2D>();
        r2d.simulated = true;
    }

    private void OnDisable()
    {
        GetComponent<PetController>().enabled = true;
    }

    private void Update()
    {
        CheckHorizontalMovement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        r2d.AddForce(new Vector2(0, jumpSpeed * Time.deltaTime));
    }

    private void CheckHorizontalMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            r2d.AddForce(new Vector2(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
