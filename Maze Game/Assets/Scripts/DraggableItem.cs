using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public string nameOfRoom;
    public string roomSlot;
    [HideInInspector] public Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        
        nameOfRoom = gameObject.name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        
        // Moves room to specified point on map
        
        roomSlot = transform.parent.gameObject.name.Substring(9);
        GameObject.Find(nameOfRoom + " Level").transform.position = GameObject.Find("Position " + roomSlot).transform.position;
        Debug.Log(GameObject.Find(nameOfRoom + " Level"));
        Debug.Log(GameObject.Find("Position " + roomSlot));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
