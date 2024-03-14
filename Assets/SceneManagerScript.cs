using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    

    public void restart()
    {
        SceneManager.LoadScene("Interaction");
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene("Menu");
    }

}
