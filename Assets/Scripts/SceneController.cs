﻿
using UnityEngine;

public class SceneController : MonoBehaviour
{


    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    public MemoryCard originalCard;
    [SerializeField] private Sprite[] images;





    void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card; //Ссылка на контейнер для исходной карты или ее
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int id = Random.Range(0, images.Length);
                card.SetCard(id, images[id]);
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z); 
               
            }

        }
    }
}