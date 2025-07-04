using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PlayerController player;
    public PlatformController platform;

    public void Init()
    {
        player.Init();
        platform.Init();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
