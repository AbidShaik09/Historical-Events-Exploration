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

        SceneManager.LoadScene("Interaction", LoadSceneMode.Single);


    }
    public void IndependanceDay()
    {

        SceneManager.LoadScene("Interaction-Ind", LoadSceneMode.Single);


    }
    public void HumanBodyTracking3D()
    {

        SceneManager.LoadScene("HumanBodyTracking3D", LoadSceneMode.Single);


    }
    public void LoadScene( string sceneName)
    {
        SceneManager.LoadScene(sceneName    , LoadSceneMode.Single);

    }


}
