using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    // Singleton part
    public static CollectibleManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    // CollectibleManager part 
    
    List<ICollectable> collectables = new List<ICollectable>();

    public void Start()
    {
        StartCoroutine(moveCollectables());
    }

    public void Add(ICollectable item)
    {
        collectables.Add(item);
    }

    public void Remove(ICollectable item)
    {
        if (collectables.Contains(item))
        {
            collectables.Remove(item);
        }
    }

    IEnumerator moveCollectables()
    {
        while(ScoreManager.instance.GameActive)
        {
            yield return new WaitForSeconds(0.5f);
            foreach (ICollectable item in collectables)
            {
                item.Move();
            }
        }


        // this happens at gameover
        foreach (ICollectable item in collectables)
        {
            Destroy((item as MonoBehaviour).gameObject);
        }
    }
}
