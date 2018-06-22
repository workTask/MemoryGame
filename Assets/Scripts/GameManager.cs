using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private GameObject _firstCard = null;
    private GameObject _secondCard = null;
    private int _cardsLeft;
    private bool _canFlip = true;
    
    [SerializeField]
    private float _timeBetweenFlips = 0.75f; //I think that particullar value works best, but you can adjust it as you want

    [SerializeField] private String newSceneLevel;
    
    private ScoreManager _scoreManager; //
    [SerializeField]
    private GameObject _winMenu; //
    [SerializeField]
    private TimeCounter _timeCounter;//
    
    public bool canFlip
    {
        get{return _canFlip;}
        set{_canFlip = value;}
    }
    
    public int cardsLeft
    {
        get
        {
            return _cardsLeft;
        }
        set
        {
            _cardsLeft = value;
        }
    }
    public void AddCard(GameObject card) //This function will be called from CardController class
    {
        if (_firstCard == null) //Adds first card
        {
            _firstCard = card;
        }
        else //Adds second card and checks if both cards match
        {
            _secondCard = card;
            _canFlip = false;
            if (CheckIfMatch())
            {
                DecreaseCardCount();
                
                _scoreManager.AddScore(); //
                _scoreManager.AddScore(); //
                
                
                StartCoroutine(DeactivateCards());
            }
            else
            {
                StartCoroutine(FlipCards());
            }
        }
    }
    IEnumerator DeactivateCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips); //Wait so player can see flipped cards and not click to fast
        _firstCard.SetActive(false);
        _secondCard.SetActive(false);
        Reset();
    }
    IEnumerator FlipCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips); //Wait so player can see flipped cards and not click too fast
        _firstCard.GetComponent<CardController>().ChangeSide();
        _secondCard.GetComponent<CardController>().ChangeSide();
        Reset();
    }
    public void Reset()
    {
        _firstCard = null;
        _secondCard = null;
        _canFlip = true;
    }
    public void DecreaseCardCount()
    {
        _cardsLeft -= 2;
        if (_cardsLeft <= 0)
        {
            //TODO GameOver
            _winMenu.SetActive(true); //
            _timeCounter.countTime = false; //
            _scoreManager.CalculateEndScore(); //
            //load new level
            SceneManager.LoadScene(newSceneLevel);
            
        }
    }
    bool CheckIfMatch()
    {
        if (_firstCard.GetComponent<CardController>().cardName == _secondCard.GetComponent<CardController>().cardName)
        {
            return true;
        }
        
        return false;
    }
    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>(); //
        _timeCounter = FindObjectOfType<TimeCounter>(); //
    }

}

