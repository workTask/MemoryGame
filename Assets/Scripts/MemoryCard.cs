
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
	[SerializeField]
	private SceneController _controller;
	private int _id;

    
	public int id()
	{
		return _id;
	}
    
	public void SetCard(int id, Sprite image)
	{
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}
}
