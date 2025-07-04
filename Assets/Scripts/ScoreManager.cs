using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager
{
    private static ScoreManager _Instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new ScoreManager();
            }
            return _Instance;
        }
    }
    public int CurScore = 0;
    public int LoadBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }
    public void SetBestScore(int score)
    {
        if (LoadBestScore() < score) PlayerPrefs.SetInt("BestScore", score);
    }
}
