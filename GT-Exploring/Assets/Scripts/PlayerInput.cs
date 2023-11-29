using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 direction;
    public bool jump;
    public bool interact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    direction = new Vector2(Input.GetAxisRaw("Kesamping"), Input.GetAxisRaw("Keatas"));
	    jump = Input.GetKeyDown(KeyCode.J);
        interact = Input.GetKeyDown(KeyCode.E);
    }
}
