using UnityEngine;
using UnityEngine.UI;

public struct UserData
{
    public string username;
    public Sprite profilePic;

    public UserData(string username, Sprite profilePic)
    {
        this.username = username;
        this.profilePic = profilePic;
    }
}
