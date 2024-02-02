using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using static LoginScript;

public class UserVerifierScript : MonoBehaviour
{
    public GameObject Form;
    private TextMeshProUGUI output;
    // Start is called before the first frame update
    void Start()
    {
        
        
        output = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
        output.text = "Loading...";
        Form = GameObject.Find("SceneItemsHolder");
        Form.active = false;
        
        if (PlayerPrefs.GetString("accessToken") != null && PlayerPrefs.GetString("accessToken") != "")
        {

            GetData(PlayerPrefs.GetString("accessToken"));
            Debug.Log("Login is Still Valid");

        }
        else
        {
            output.text = "Error: Login Again ";
            SceneManager.LoadScene("Login");

        }
    }


    public async void GetData(string token)
    {
        StartCoroutine(GetDataFromAPIs(token));

    }


    IEnumerator GetDataFromAPIs(string token)
    {
        string newrl = "http://arheewebapi.somee.com/Auth/Details";
        UnityWebRequest uwr = UnityWebRequest.Get(newrl + "?accessToken=" + UnityWebRequest.EscapeURL(token));
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            output.text = "Session Expired,\n Login Again ";
            PlayerPrefs.SetString("accessToken", "");
            PlayerPrefs.SetString("email", "");
            PlayerPrefs.SetString("age", "");
            PlayerPrefs.SetString("gender", "");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Login");

        }
        else
        {
            var jsonData = uwr.downloadHandler.text;
            UserData dict = JsonUtility.FromJson<UserData>(jsonData);

            PlayerPrefs.SetString("username", dict.username);
            PlayerPrefs.SetString("email", dict.email);
            PlayerPrefs.SetInt("age", dict.age);
            PlayerPrefs.SetString("gender", dict.gender);
            Form.active = true;
            output.text = "";
            TextMeshProUGUI user= GameObject.Find("username").GetComponent<TextMeshProUGUI>();
            user.text = PlayerPrefs.GetString("username")+" !";


            PlayerPrefs.Save();

            Debug.Log("Recieved Data From API Welcome " + PlayerPrefs.GetString("username") + " !");
            

        }


    }
}

