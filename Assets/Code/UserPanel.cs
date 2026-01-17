using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _usernameText;
    [SerializeField] private Image _profilePic;

    public UserData userData;

    public void InitUserPanel(UserData userData)
    {
        this.userData = userData;

        this._usernameText.text = userData.username;
        this._profilePic.sprite = userData.profilePic;
    }
}
