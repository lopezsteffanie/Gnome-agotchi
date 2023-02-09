using System.Threading;
using System.Security.Cryptography;
using UnityEngine;

public class MiniGamePetController : MonoBehaviour
{
    public float speed, jumpSpeed;
    private Rigidbody2D r2d;
    public bool grounded;

    private void OnEnable()
    {
        // GetComponent<PetController>().enabled = false;
        GetComponent<NeedsController>().enabled = false;
        r2d = GetComponent<Rigidbody2D>();
        r2d.simulated = true;
        r2d.gravityScale = 5;
    }

    private void OnDisable()
    {
        GetComponent<PetController>().enabled = true;
        GetComponent<NeedsController>().enabled = true;
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
        grounded = false;
        r2d.AddForce(new Vector2(0, jumpSpeed * 10000 * Time.deltaTime));
    }

    private void CheckHorizontalMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            r2d.AddForce(new Vector2(speed * 10000 * Time.deltaTime * Input.GetAxis("Horizontal"), 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && collision.transform.position.y + 1.5f < transform.position.y) 
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
