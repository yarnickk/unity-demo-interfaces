using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour, ICollectable
{
    public Type Type => Type.Circle;

    public void Collect()
    {
        CollectibleManager.instance.Remove(this);
    }

    public void Move()
    {
        var pos = transform.position;
        pos.x += 0.2f;
        if (pos.x > 9) pos.x = -9;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectibleManager.instance.Remove(this);
            ScoreManager.instance.Collected(this);
            Destroy(gameObject);
        }
    }
}
