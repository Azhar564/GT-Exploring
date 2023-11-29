using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LayerMask layerPlayer;
    public PlayerInput playerInput;
    public GameObject door;

    private bool canInteract;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (playerInput.interact)
            {
                door.SetActive(!door.activeSelf);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (layerPlayer == (layerPlayer | (1 << other.gameObject.layer)))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (layerPlayer == (layerPlayer | (1 << other.gameObject.layer)))
        {
            canInteract = false;
        }
    }
}
