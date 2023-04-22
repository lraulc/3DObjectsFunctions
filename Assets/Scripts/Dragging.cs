using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private float distance;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    [SerializeField] private Camera camera;


    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 touchPos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = camera.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Draggable"))
                {
                    toDrag = hit.transform;
                    distance = hit.transform.position.z - camera.transform.position.z;
                    v3 = new Vector3(touchPos.x, touchPos.y, distance);
                    v3 = camera.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;
                }
            }
        }

        if (dragging == true && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            v3 = camera.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if (dragging == true && touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            dragging = false;
        }
    }
}
