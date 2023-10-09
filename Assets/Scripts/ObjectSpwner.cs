using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpwner : MonoBehaviour
{
    public GameObject circle;
    public GameObject triangle;
    public GameObject square;
    public GameObject hexagon;

    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawning());
    }

    IEnumerator spawning()
    {
        while(ScoreManager.instance.GameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            int randNum = Random.Range(0, 4);

            ICollectable collectable;
            switch (randNum)
            {
                case 0:
                    var _c = Instantiate(circle);
                    _c.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.0f, 4.0f), 0);
                    collectable = _c.GetComponent<CircleScript>();
                    break;
                case 1:
                    var _t = Instantiate(triangle);
                    _t.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.0f, 4.0f), 0);
                    collectable = _t.GetComponent<TriangleScript>();
                    break;
                case 2:
                    var _h = Instantiate(hexagon);
                    _h.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.0f, 4.0f), 0);
                    collectable = _h.GetComponent<HexagonScript>();
                    ColorManager.instance.Add(collectable as IChangableColor);
                    break;
                default:
                    var _s = Instantiate(square);
                    _s.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.0f, 4.0f), 0);
                    collectable = _s.GetComponent<SquareScript>();
                    
                    break;
            }
            CollectibleManager.instance.Add(collectable);
            ScoreManager.instance.Spawned(collectable);
        }
        
    }
}
