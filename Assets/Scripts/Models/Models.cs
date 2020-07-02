using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class Player
{
    public int id;
    public string first_name;
    public string email;
    public override string ToString()
    {
        return "id: " + id.ToString() + " first_name: " + first_name;
    }
}

[System.Serializable]
public class ListPlayer
{
    public List<Player> data = new List<Player>();
    public override string ToString()
    {
        return data.Count.ToString();
    }
}

[System.Serializable]
public class BaseResponse{
    public string msg;
    public int error;
}

[System.Serializable]
public class ResponseSendData : BaseResponse{
    public Player data;
}