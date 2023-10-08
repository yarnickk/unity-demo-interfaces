using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleScript : MonoBehaviour, ICollectable
{
    public Type Type => Type.Triangle;

    public void Collect()
    {
        CollectibleManager.instance.Remove(this);
    }

    public void Move()
    {
        var pos = transform.position;
        pos.y -= 0.3f;
        if (pos.y < -4) pos.y = 4;
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
