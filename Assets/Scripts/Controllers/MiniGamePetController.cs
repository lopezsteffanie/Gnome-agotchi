using System.Threading;
using System.Security.Cryptography;
using UnityEngine;

public class MiniGamePetController : MonoBehaviour
{
    public float speed, jumpSpeed;
    private Rigidbody2D r2d;

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
        CheckMovement();
    }

    private void CheckMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            r2d.AddForce(new Vector2(speed * Time.deltaTime * Input.GetAxis("Horizontal"),0));
        }
    }
}
