using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NewRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public int minSize = 2;
    public GameObject chandrayan;
    private void Start()
    {
        ARRaycastManager raycastManager = GetComponent<ARRaycastManager>();
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
    }
    private void Update()
    {
        if (raycastManager.enabled && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 screenPoint = touch.position;
            
            placeObject(screenPoint);
        }

    }


    public void placeObject(Vector2 screenPoint)
    {

        if (raycastManager.Raycast(screenPoint, hits, TrackableType.PlaneWithinPolygon))
        {
            ARPlane plane = hits[0].trackable as ARPlane;
            Vector2 planeSize = plane.extents;

            if (planeSize.x >= minSize && planeSize.y >= minSize)
            {
                // The plane is large enough, you can now place your object
                Vector3 position = hits[0].pose.position;
                position.y += 1.5f; // Convert Y from mm to meters

                Instantiate(chandrayan, position, Quaternion.identity);

                // Disable the ARRaycastManager and ARPlaneManager
                raycastManager.enabled = false;
                planeManager.enabled = false;
            }
        }

    }
}
