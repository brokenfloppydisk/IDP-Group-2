using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    private LineRenderer lineRenderer;
    private Canvas canvas;
    private bool isBeingDragged = false;

    

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update() {
        if (isBeingDragged) {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out movePos);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePos));
        } else {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero); 
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // unused
    }

    public void OnDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;
    }
}