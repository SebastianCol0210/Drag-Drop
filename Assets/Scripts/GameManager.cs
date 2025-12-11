using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;

    public GameObject _figure;


    void Start()
    {
        InvokeRepeating(nameof(Creator), .5f, 1.5f);
    }

    private void Creator()
    {
        //generate random number
        int randomNumber = UnityEngine.Random.Range(0, _sprites.Length);
        _figure.gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[randomNumber];
        if (randomNumber is >= 0 and <= 2)
        {
            _figure.gameObject.GetComponent<Draggable>().isWhite = true;
            _figure.gameObject.GetComponent<Draggable>().isGreen = false;
            _figure.gameObject.GetComponent<Draggable>().isBlack = false;
        }
        else if (randomNumber is >= 3 and <= 5)
        {
            _figure.gameObject.GetComponent<Draggable>().isGreen = true;
            _figure.gameObject.GetComponent<Draggable>().isWhite = false;
            _figure.gameObject.GetComponent<Draggable>().isBlack = false;
        }
        else if (randomNumber is >= 6 and <= 8)
        {
            _figure.gameObject.GetComponent<Draggable>().isBlack = true;
            _figure.gameObject.GetComponent<Draggable>().isWhite = false;
            _figure.gameObject.GetComponent<Draggable>().isGreen = false;
        }

        float randomNumber2 = UnityEngine.Random.Range(-5.5f, 5.5f);
        Instantiate(_figure, new Vector2(randomNumber2, 20), Quaternion.identity);
    }
    
    

}
