using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandrayanRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas,LostCanvas,WinCanvas;
    public Rigidbody Chandrayan;
    public Vector3 rot = new Vector3(0.0f, 5f, 0.0f);
    public float forceupvalue = 0.1f;
    public Vector3 clockrot = new Vector3(0.0f, 0.1f, 0.0f);
    public ParticleSystem[] particleSystems;
    void Start()
    {
        LostCanvas.enabled = false;
        WinCanvas.enabled = false;
        Chandrayan = GetComponent<Rigidbody>();
        particleSystems=Chandrayan.GetComponentsInChildren<ParticleSystem>();
        Chandrayan.AddTorque(rot);
        
        Chandrayan.angularVelocity = rot;
        Chandrayan.AddForce(0, -3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void AddForceUp()
    {
        if (particleSystems[0].startLifetime<0.6)
        foreach (ParticleSystem p in particleSystems)
        {
            p.startLifetime+=0.01f;
        }
        Chandrayan.AddForce(0, forceupvalue, 0);
    }
    public void AddForceDown()
    {
        if (Chandrayan.velocity.y > 0 && particleSystems[0].startLifetime>0.1)
        {
            foreach (ParticleSystem p in particleSystems)
            {
                p.startLifetime -= 0.01f;
            }
        }
        
        Chandrayan.AddForce(0, -forceupvalue, 0);

    }
    public void AddForceClockwise() {
        Chandrayan.angularVelocity += clockrot;
    }
    public void AddForceAntiClockwise()
    {
        Chandrayan.angularVelocity -= clockrot;

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "moon" tag
        if (collision.gameObject.CompareTag("Moon"))
        {
            // Get the relative velocity of the collision

            float yVelocity = Math.Abs(Chandrayan.velocity.y * 5000);
            float AVelocity = Math.Abs(Chandrayan.angularVelocity.y * 1000);
            canvas.enabled = false;
            if (yVelocity > 100 || AVelocity > 300 || (yVelocity>50 && AVelocity>100)) {
                Debug.Log("Mission Failed");
                LostCanvas.enabled = true;
                
            }
            else 
            {
                Debug.Log("Mission Passed");
                WinCanvas.enabled = true;
                
            }
            foreach (ParticleSystem p in particleSystems)
            {
                p.Stop();
            }

            
            

            // Log or do something with the speed information
            Debug.Log("Collision speed with moon: " + yVelocity+"  "+AVelocity + " units per second");
        }
    }
}
