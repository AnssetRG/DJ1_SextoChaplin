using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnPlay;
    private string url = "http://23.23.146.103/proyectos/angrybirds/public/api/users";
    // Start is called before the first frame update
    void Start()
    {
        //btnPlay.onClick.AddListener(() => GoLevelSelect());
        StartCoroutine(GetData());
        StartCoroutine(SendData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GameVariables.api_url + "users"))
        {
            yield return webRequest.SendWebRequest();
            //Error de Internet o  Error de Servidor
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                print("GAAAA");
            }
            else
            {
                string text = webRequest.downloadHandler.text;
                ListPlayer players = JsonUtility.FromJson<ListPlayer>(text);
                foreach (Player item in players.data)
                {
                    print(item.ToString());
                }
            }
        }

    }

    IEnumerator SendData()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", "anuma@correo.com");
        form.AddField("first_name", "Anuma");
        form.AddField("last_name", "Elliol");
        using (UnityWebRequest webRequest = UnityWebRequest.Post(GameVariables.api_url + "register", form))
        {
            yield return webRequest.SendWebRequest();
            //Error de Internet o  Error de Servidor
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                print("GAAAA");
            }
            else
            {
                string text = webRequest.downloadHandler.text;
                ResponseSendData response = JsonUtility.FromJson<ResponseSendData>(text);
                if (response.msg == "GAAAA")
                {
                    print("Se fue en Yolo");
                }
                {
                    print(response.data.ToString());
                }


            }
        }

    }

    void GoLevelSelect()
    {
        StateManager.changeScene("LevelSelect");
    }
}
