using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObjectPooling gameObjectPooling;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        transform.position = new Vector3(Random.Range(-5, 5), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObjectPooling.Release(this);
    }
}
