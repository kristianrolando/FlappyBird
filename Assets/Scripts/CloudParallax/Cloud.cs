using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : PoolObject
{
    [HideInInspector] public float speed = 2.2f;

    private void Update()
    {
        //speed = GameManager.Instance.speedPipe - (GameManager.Instance.speedPipe * 0.1f);
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
