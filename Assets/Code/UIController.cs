using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Sprite _mainMenuSprite;
    [SerializeField] private Sprite _gameplaySprite;
    [SerializeField] private SpriteRenderer _bgSpriteRenderer; // trocar pra Animator dps

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameplayPanel;

    private void Start()
    {
        this._bgSpriteRenderer.sprite = this._mainMenuSprite;

        this._mainMenuPanel.SetActive(true);
        this._gameplayPanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        this._bgSpriteRenderer.sprite = this._gameplaySprite;

        this._mainMenuPanel.SetActive(false);
        this._gameplayPanel.SetActive(true);
    }

    public void OnTurboButtonPressed()
    {
        Debug.Log("MODO TURBO!!!");
    }
}
