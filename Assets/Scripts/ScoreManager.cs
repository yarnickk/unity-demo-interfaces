using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Singleton part
    public static ScoreManager instance;

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

    // ScoreManager part

    public TextMeshProUGUI inGameCircles;
    public TextMeshProUGUI inGameTriangles;
    public TextMeshProUGUI inGameSquares;
    public TextMeshProUGUI collectedCircles;
    public TextMeshProUGUI collectedTriangles;
    public TextMeshProUGUI collectedSquares;
    public TextMeshProUGUI gameOver;

    private int circleScore = 0;
    private int triangleScore = 0;
    private int squareScore = 0;
    private int circlesLeft = 0;
    private int trianglesLeft = 0;
    private int squaresLeft = 0;

    public bool GameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);        
    }

    public void Collected(ICollectable item)
    {
        switch (item.Type)
        {
            case Type.Circle:
                circleScore++;
                break;
            case Type.Triangle:
                triangleScore++;
                break;
            case Type.Square:
                squareScore++;
                break;
        }
        UpdateScore();
    }

    public void Spawned(ICollectable item)
    {
        switch(item.Type)
        {
            case Type.Circle: 
                circlesLeft++;
                break;
            case Type.Triangle:
                trianglesLeft++;
                break;
            case Type.Square:
                squaresLeft++;
                break;
        }
        UpdateScore();
    }

    private void UpdateScore()
    {
        inGameCircles.text = $"Circles: {circlesLeft}";
        inGameTriangles.text = $"Triangles: {trianglesLeft}";
        inGameSquares.text = $"Squares: {squaresLeft}";

        collectedCircles.text = $"Circles: {circleScore}";
        collectedTriangles.text = $"Triangles: {triangleScore}";
        collectedSquares.text = $"Squares: {squareScore}";



        if (circleScore < circlesLeft - 5 
            || triangleScore < trianglesLeft - 5 
            || squareScore < squaresLeft - 5)
        {
            gameOver.gameObject.SetActive(true);
            GameActive = false;
        }


    }
}
