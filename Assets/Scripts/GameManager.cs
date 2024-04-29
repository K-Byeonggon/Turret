using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public int score = 0;
    public Text scoreText;

    public Transform enemy;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
