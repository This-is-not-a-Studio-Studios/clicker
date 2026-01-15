using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _usernameText;

    public void InitUserPanel(string username)
    {
        this._usernameText.text = username;
    }
}
