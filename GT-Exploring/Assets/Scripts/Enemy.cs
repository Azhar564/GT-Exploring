using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol, // jalan dari 1 titik ke titik lainnya
        Chase
    }

    [Header("General")]
    public EnemyState enemyState;
    public GameObject target;
    public float speed;

    [Header("Patrol")]
    public Transform pointA;
    public Transform pointB;
    public Transform currentTargetPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentTargetPoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;

            case EnemyState.Chase:
                Chase();
                break;
        }
    }

    private void Patrol()
    {
        Detection();

        if (Vector2.Distance(transform.position, currentTargetPoint.position) < 0.1f)
        {
            if (currentTargetPoint == pointA)
            {
                currentTargetPoint = pointB;
            }
            else if (currentTargetPoint == pointB)
            {
                currentTargetPoint = pointA;
            }
        }
    }

    private void Chase()
    {
        Detection();
    }

    private void Detection()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTargetPoint.position, speed * Time.deltaTime);

        Vector2 direction = (target.transform.position - transform.position).normalized;
        Vector2 forward = transform.right;
        if (Vector2.Dot(forward, direction) > 0.5f)
        {
            if (Vector2.Distance(target.transform.position, transform.position) < 2f)
            {
                enemyState = EnemyState.Chase;
                Debug.DrawLine(transform.position, transform.right * direction.normalized * 2, Color.white);
            }
            else
            {
                enemyState = EnemyState.Patrol;
            }
        }
        Debug.DrawLine(transform.position, transform.right * direction.normalized * 2, Color.red);
    }

    private void OnDrawGizmos()
    {
    }
}

