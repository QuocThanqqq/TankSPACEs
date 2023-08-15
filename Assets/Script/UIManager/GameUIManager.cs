using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public UIViewLoadings ViewLoadings;
    public UIViewIngame ViewInGame;
    public UIViewGameFinish ViewGameFinish;
}
