using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVikram : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Chandrayan;
    public GameObject ButtonsHolder;
    void Start()
    {
        ButtonsHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonsHolder.active)
        {

            ButtonsHolder.transform.position = Chandrayan.transform.position;
            //ButtonsHolder.transform.rotation = Chandrayan.transform.rotation;

        }
    }
}
