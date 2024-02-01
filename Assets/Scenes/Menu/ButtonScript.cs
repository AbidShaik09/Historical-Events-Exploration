using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void logOut()
    {

        PlayerPrefs.SetString("accessToken", "");
        PlayerPrefs.SetString("username", "");
        PlayerPrefs.SetString("gender", "");
        PlayerPrefs.SetString("email", "");
        PlayerPrefs.SetString("age", "");
        

        SceneManager.LoadScene("Login");

    }

    public void Profile()
    {

        SceneManager.LoadScene("Profile");


    }
    public void Chandrayan3()
    {

        SceneManager.LoadScene(2, LoadSceneMode.Single);


    }
    public void IndependanceDay()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Single);


    }

}
