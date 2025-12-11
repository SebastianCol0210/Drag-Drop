using UnityEngine;
using DG.Tweening;

public class Dragger : MonoBehaviour
{
    public Draggable lastDragged => _lastDragged;

    
    private bool _isDragging = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition; 
    private Draggable _lastDragged;
    


    private void Awake()
    {
        Dragger[] draggers = FindObjectsOfType<Dragger>();
        if(draggers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
        if (_isDragging && (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        
        if (Input.GetMouseButton(0))
        {

            print("Mouse down");
            Vector3 mousePosition = Input.mousePosition;
            _screenPosition = new Vector2(mousePosition.x, mousePosition.y);
        }
        else if(Input.touchCount > 0)
        {
            print("Touch down");
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragging)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                print("Hit");
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    print("Draggable");
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _lastDragged.lastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
    }
    
    void Drag()
    {
        _lastDragged.transform.DOKill();
        print("Dragging");
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        print("Drop");
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragging = _lastDragged.IsDragging = isDragging;
        _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }
}

