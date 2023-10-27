using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	public PlayerInput playerController;
    public float jumpForce = 10.0f;
    public float speed = 10.0f;

    private Rigidbody2D rb2D;
    private Vector2 directionInput;
    private bool grounded;
    private bool requestJump;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(playerController.direction.x, playerController.jump);
    }

    public void Move(float horizontal, bool jump)
    {
        directionInput = new Vector2(horizontal, 0.0f);
        if (jump && grounded)
        {
            requestJump = true;
        }
    }

    public void SetGrounded(bool set)
    {
        grounded = set;
    }

    private void FixedUpdate()
    {
	    rb2D.velocity = new Vector2(directionInput.x * speed * Time.fixedDeltaTime, rb2D.velocity.y);

        if (requestJump)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            requestJump = false;
        }
    }
}
