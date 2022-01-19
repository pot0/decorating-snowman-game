using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ITEMdrag : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    //public bool isDrag;
    snowman snow;
    private void OnMouseDown() {
        _dragOffset = transform.position - GetMousePos();
    }

    private void Awake() {
        snow = FindObjectOfType<snowman>();
        _cam = Camera.main;
    }

    private void OnMouseDrag() {
        transform.position = GetMousePos() + _dragOffset;    
    }

    Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float leftBorder = -8.5f + transform.localScale.x /2f;
        float rightBorder = 10.4f - transform.localScale.x /2f;

        if (mousePos.x < leftBorder) {mousePos.x = leftBorder;}
        if (mousePos.x > rightBorder) {mousePos.x = rightBorder;}
        
        float upBorder = 4.07f + transform.localScale.y /2f;;
        float downBorder = -2.5f -transform.localScale.y /2f;; 
        
        if (mousePos.y < downBorder) {mousePos.y = downBorder;}
        if (mousePos.y > upBorder) {mousePos.y = upBorder;}
        return mousePos;
    }

/*    private void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float leftBorder = -13.6f + transform.localScale.x /2f;
        float rightBorder = 10.4f - transform.localScale.x /2f;

        if (mousePos.x < leftBorder) {mousePos.x = leftBorder;}
        if (mousePos.x > rightBorder) {mousePos.x = rightBorder;}
        
        float upBorder = 7.07f;
        float downBorder = -2.5f; 
        
        if (mousePos.y < downBorder) {mousePos.y = downBorder;}
        if (mousePos.y > upBorder) {mousePos.y = upBorder;}
        
        mousePos.z = 0;

        transform.position = Vector3.Lerp(transform.position, mousePos, 0.01f); 
    }*/
}