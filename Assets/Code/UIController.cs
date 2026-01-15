using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private enum UIPanel
    {
        None,
        MainMenu,
        Gameplay,
    }

    [Header("Background Stuff")]
    [SerializeField] private Sprite _mainMenuSprite;
    [SerializeField] private Sprite _gameplaySprite;
    //[SerializeField] private SpriteRenderer _bgSpriteRenderer; // trocar pra Animator dps
    [SerializeField] private Animator _bgAnimator;
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
        this._bgAnimator.SetBool("Zoom", false);
        this._bgAnimator.Play("Zoomed Out");
        
        this.SetUIPanel(UIPanel.MainMenu);
    }

    public void OnPlayButtonPressed()
    {
        this._bgAnimator.SetBool("Zoom", true);

        this.StartCoroutine(WaitForBackgroundAnimation("Zoomed In"));

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

    private void SetUIPanel(UIPanel targetUIPanel)
    {
        this._mainMenuPanel.SetActive(targetUIPanel == UIPanel.MainMenu);
        this._gameplayPanel.SetActive(targetUIPanel == UIPanel.Gameplay);
    }

    private IEnumerator WaitForBackgroundAnimation(string targetAnimation)
    {
        this.SetUIPanel(UIPanel.None);

        while (!this._bgAnimator.GetCurrentAnimatorStateInfo(0).IsName(targetAnimation))
        {
            yield return null;
        }

        this.SetUIPanel(targetAnimation == "Zoomed In" ? UIPanel.Gameplay : UIPanel.MainMenu);
    }
}
