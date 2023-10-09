using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // Singleton part
    public static ColorManager instance;

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

    // ColorManager part

    List<IChangableColor> items = new List<IChangableColor>();
    Color currentColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeColor());
    }

    public void Add(IChangableColor item)
    {
        items.Add(item);
    }

    public void Remove(IChangableColor item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    IEnumerator changeColor()
    {
        while (ScoreManager.instance.GameActive)
        {
            yield return new WaitForSeconds(5.0f);

            SwapColors();

            foreach (IChangableColor item in items)
            {
                item.SetColor(currentColor);
            }
        }

        items.Clear();
    }

    void SwapColors()
    {
        if (currentColor == Color.green)
        {
            currentColor = Color.red;
        }
        else
        {
            currentColor = Color.green;
        }
    }
}
