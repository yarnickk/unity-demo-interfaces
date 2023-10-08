using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour, ICollectable
{
    public Type Type => Type.Square;

    public void Collect()
    {
        CollectibleManager.instance.Remove(this);
    }

    public void Move()
    {
        int dir = Random.Range(0, 3);
        switch(dir)
        {
            case 0:
                {
                    var pos = transform.position;
                    pos.x += 0.1f;
                    if (pos.x > 9) pos.x = 9;
                    transform.position = pos;
                    break;
                }
            case 1:
                {
                    var pos = transform.position;
                    pos.x -= 0.1f;
                    if (pos.x < -9) pos.x = -9;
                    transform.position = pos;
                    break;
                }
            case 2:
                {
                    var pos = transform.position;
                    pos.y += 0.1f;
                    if (pos.y > 4) pos.y = 4;
                    transform.position = pos;
                    break;
                }
            case 3:
                {
                    var pos = transform.position;
                    pos.y -= 0.1f;
                    if (pos.y < -4) pos.y = -4;
                    transform.position = pos;
                    break;
                }
        }
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
