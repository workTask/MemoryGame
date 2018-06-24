using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    private ScoreManager _scoreManager;
    
    
    void Start() {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        _scoreText.text = "Score " + _scoreManager.score;
    }

    
}
