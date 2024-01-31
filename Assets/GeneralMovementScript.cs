using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovementScript : MonoBehaviour
{
    

    public float speed = 1.0f; // Speed of the object movement
    public GameObject objectToMove; // The 3D object you want to move

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var buttonName = hit.transform.gameObject.name;

                Debug.Log(" Pressed:"+buttonName);
                switch (buttonName)
                    {
                        case "LeftButtonCube":
                            objectToMove.GetComponent<Rigidbody>().AddForce(-speed * Time.deltaTime, 0, 0);
                            break;
                        case "RightButtonCube":
                            objectToMove.GetComponent<Rigidbody>().AddForce(speed * Time.deltaTime, 0, 0);
                            break;
                        case "FrontButtonCube":
                            objectToMove.GetComponent<Rigidbody>().AddForce(0, 0, speed * Time.deltaTime);
                            break;
                        case "BackButtonCube":
                            objectToMove.GetComponent<Rigidbody>().AddForce(0, 0, -speed * Time.deltaTime);
                            break;
                        default:
                            break;
                    }
                
                
            }
        }
    }


}
