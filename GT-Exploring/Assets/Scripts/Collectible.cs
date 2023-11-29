using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
	public LayerMask layerPlayer;
	
	private GameManager gameManager;
	
	// Start is called before the first frame update
    void Start()
    {
	    gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (layerPlayer == (layerPlayer | (1 << other.gameObject.layer)))
		{
			gameManager.AddCoin(1);
			gameObject.SetActive(false);
		}
	}
}
