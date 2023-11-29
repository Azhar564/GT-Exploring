using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPooling : MonoBehaviour
{
    public Shape prefab;
    public int countRepeat = 10;
    public int countMax = 100;
    private ObjectPool<Shape> objectPool;
    // Start is called before the first frame update
    void Start()
    {
        objectPool = new ObjectPool<Shape>(
            () => Instantiate(prefab, transform.position, Quaternion.identity, transform),
            shape => shape.gameObject.SetActive(true),
            shape => shape.gameObject.SetActive(false),
            shape => Destroy(shape),
            true, countRepeat, countMax
        );

        InvokeRepeating(nameof(Initialize), 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Initialize()
    {
        for (int i = 0; i < countRepeat; i++)
        {
            objectPool.Get().gameObjectPooling = this;
        }
    }

    public void Release(Shape obj)
    {
        objectPool.Release(obj);
        obj.transform.position = transform.position;
    }
}
