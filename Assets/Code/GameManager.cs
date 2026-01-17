using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    [SerializeField] private Sprite _phPhoto;

    protected override void Awake()
    {
        base.Awake();

        Screen.SetResolution(1920, 1080, true);
    }

    private void Start()
    {
        userList[0] = new UserData("Kyn", this._phPhoto);
        userList[1] = new UserData("Toph", this._phPhoto);
        userList[2] = new UserData("Vinnie", this._phPhoto);
    }

    // ph stuff
    public UserData[] userList = new UserData[3];
}
