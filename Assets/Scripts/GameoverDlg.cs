using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameoverDlg : MonoBehaviour
{
    [SerializeField] private TMP_Text BestScoreTxt;
    [SerializeField] private TMP_Text CurScoreTxt;

    private Vector2 HideVector = new Vector2(0, -1050.0f);
    private Vector2 ShowVector = new Vector2(0, 0);

    private bool m_isShow = false;
    void Start()
    {
        transform.localPosition = HideVector;
    }
    public void Init()
    {
        Show(false);
    }

    public void Show(bool isShow)
    {
        if(isShow)SetResult();
        m_isShow = isShow;
    }

    public void Update()
    {
        Vector2 DirVector = m_isShow ? ShowVector : HideVector;
        float moveSpeed = m_isShow ? 4 : 6;
        transform.localPosition = Vector2.Lerp(transform.localPosition, DirVector, Time.deltaTime * moveSpeed);
    }

    public void SetResult()
    {
        if (ScoreManager.Instance.CurScore > ScoreManager.Instance.LoadBestScore()) ScoreManager.Instance.SetBestScore(ScoreManager.Instance.CurScore);
        BestScoreTxt.text = string.Format("최고 점수 : {0}",ScoreManager.Instance.LoadBestScore());
        CurScoreTxt.text = string.Format("현재 점수 : {0}",ScoreManager.Instance.CurScore);
    }
}
