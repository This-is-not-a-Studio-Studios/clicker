using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();

        Screen.SetResolution(1920, 1080, true);
    }

    // ph stuff
    public string[] userList = { "Kyn", "Toph", "Vinnie" };
}
