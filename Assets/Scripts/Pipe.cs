using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : PoolObject
{
    [HideInInspector]
    public float speed = 2f;


    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    public override void StoreToPool()
    {
        base.StoreToPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndPipe"))
        {
            StoreToPool();
        }
    }
}
