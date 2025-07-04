using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
                if (m_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    m_instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return m_instance;
        }
    }

    public GameUI gameUI;
    public HudUI hudUI;

    private bool m_isGameBegin = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init()
    {
        gameUI.Init();
        hudUI.Init();
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameBegin()) ScoreManager.Instance.CurScore += 1;
        if (Input.GetKeyDown(KeyCode.R) && !IsGameBegin()) RestartGame();
    }
    public void RestartGame()
    {
        ScoreManager.Instance.CurScore = 0;
        SetIsGameBegin(true);
        gameUI.Init();
        hudUI.Init();
    }

    public void SetIsGameBegin(bool isGameBegin)
    {
        m_isGameBegin = isGameBegin;
    }
    public bool IsGameBegin()
    {
        return m_isGameBegin;
    }
    public void EndGame()
    {
        hudUI.gameoverDlg.Show(true);
    }
}
