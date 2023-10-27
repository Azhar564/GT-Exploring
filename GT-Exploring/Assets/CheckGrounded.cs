using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public Movement movement;
	public LayerMask layerGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if layer is in LayerGround field
        if (layerGround == (layerGround | (1 << other.gameObject.layer)))
        {
            movement.SetGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
	{
        if (layerGround == (layerGround | (1 << other.gameObject.layer)))
        {
            movement.SetGrounded(false);
        }
    }
}
