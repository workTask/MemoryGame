using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

	private SpriteRenderer _spriteRenderer;
	private bool _isUpsideDown = false;

	[SerializeField] 
	private string _cardName;
	[SerializeField] 
	private Sprite _frontSideCardSprite;
	
	private Sprite _backSideCardSprite;
	
	private GameManager _gameManager;
	


	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_backSideCardSprite = _spriteRenderer.sprite;
		
		// Find gameManager
		_gameManager = FindObjectOfType<GameManager>();


	}

	public string cardName
	{
		get { return _cardName; }
		set { _cardName = value; }
	}

	private void OnMouseDown()
	{
		if (!_isUpsideDown)
		{
			//adds this card to it...
			_gameManager.AddCard(gameObject);
			ChangeSide();
		}
	}

	public void ChangeSide()
	
	{
		if (!_isUpsideDown)
		{
			_spriteRenderer.sprite = _frontSideCardSprite;
			_isUpsideDown = true;
		}
		else
		{
			_spriteRenderer.sprite = _backSideCardSprite;
			_isUpsideDown = false;
		}
	}
}
