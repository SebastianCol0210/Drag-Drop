using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;

    public Vector3 lastPosition;

    public bool isGreen;
    public bool isBlack;
    public bool isWhite;
    
    private Collider2D _collider;

    private Dragger _dragger;
    private ScoreUpdater _scoreUpdater;

    private float _movementTime = 15f;

    private System.Nullable<Vector3> _movementDestination;

    private float randomNumber;

    private int score;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragger = FindObjectOfType<Dragger>();
        _scoreUpdater = FindObjectOfType<ScoreUpdater>();
        randomNumber = UnityEngine.Random.Range(6f, 12f);
    }

    private void Update()
    {
        transform.DOMoveY(-40f, randomNumber, false).SetEase(Ease.Linear);

        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;
                return;
            }
            
            if(transform.position == _movementDestination.Value)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Draggable collidedDraggable = other.GetComponent<Draggable>();

        transform.DOKill();

        if (collidedDraggable != null && _dragger.lastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) *
                           colliderDistance2D.distance;
            transform.position -= diff;
        }

        if (other.CompareTag("TrashBlack") && isBlack)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Correct black");
            _scoreUpdater.score++;
        }
        else if (other.CompareTag("TrashWhite") && isWhite)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Correct white");
            _scoreUpdater.score++;
        }else if (other.CompareTag("TrashGreen") && isGreen)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Correct green");
            _scoreUpdater.score++;
        }
        else if(other.CompareTag("TrashBlack") && isWhite)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong white");
            _scoreUpdater.score--;
        }
        else if (other.CompareTag("TrashWhite") && isBlack)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong black");
            _scoreUpdater.score--;
        }
        else if (other.CompareTag("TrashGreen") && isBlack)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong black");
            _scoreUpdater.score--;
        }
        else if (other.CompareTag("TrashGreen") && isWhite)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong white");
            _scoreUpdater.score--;
        }else if (other.CompareTag("TrashBlack") && isGreen)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong green");
            _scoreUpdater.score--;
        }else if (other.CompareTag("TrashWhite") && isGreen)
        {
            _movementDestination = other.transform.position;
            Destroy(gameObject);
            print("Wrong green");
            _scoreUpdater.score--;
        }
    }
    
}
