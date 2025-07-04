using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{
    public GameoverDlg gameoverDlg;

    [SerializeField] TMP_Text ScoreTxt;
    public void Init()
    {
        gameoverDlg.Init();
    }
    void Update()
    {
        ScoreTxt.text = string.Format("SCORE : {0}", ScoreManager.Instance.CurScore);
    }
}
