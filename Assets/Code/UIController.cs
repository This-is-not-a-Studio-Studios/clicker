using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Background Stuff")]
    [SerializeField] private Sprite _mainMenuSprite;
    [SerializeField] private Sprite _gameplaySprite;
    [SerializeField] private SpriteRenderer _bgSpriteRenderer; // trocar pra Animator dps
    [Header("UI Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameplayPanel;
    [Header("Computer")]
    [SerializeField] private GameObject _userPrefab;
    [SerializeField] private GameObject _separatorPrefab;
    [SerializeField] private Transform _pcUserListPanel;

    private void Start()
    {
        // menu setup
        this._bgSpriteRenderer.sprite = this._mainMenuSprite;

        this._mainMenuPanel.SetActive(true);
        this._gameplayPanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        this._bgSpriteRenderer.sprite = this._gameplaySprite;
        
        this._mainMenuPanel.SetActive(false);
        this._gameplayPanel.SetActive(true);

        for (int i = 0; i < GameManager.Instance.userList.Length;  i++)
        {
            string username = GameManager.Instance.userList[i];

            GameObject newUser = GameObject.Instantiate(this._userPrefab, this._pcUserListPanel);
            newUser.GetComponent<UserPanel>().InitUserPanel(username);

            if (i >= GameManager.Instance.userList.Length - 1) break;

            GameObject.Instantiate(this._separatorPrefab, _pcUserListPanel);
        }
    }

    public void OnTurboButtonPressed()
    {
        Debug.Log("MODO TURBO!!!");
    }
}
