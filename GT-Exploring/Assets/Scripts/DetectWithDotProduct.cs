using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWithDotProduct : MonoBehaviour
{
    public Transform target;
    public float output;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        output = Vector2.Dot(transform.up, direction);
    }
}
