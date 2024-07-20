using DG.Tweening;
using UnityEngine;

public class TweeningScript : MonoBehaviour
{
    public RectTransform scoreText;
    public GameObject gameOverPanel;
    public GameObject gameOverPlayBtn;
    public GameObject gameOverQuitBtn;

    private void Start()
    {
        scoreText.DOMoveY(-300f, 2f).SetRelative(true).SetEase(Ease.InOutBack);
    }
    public void OpenPanel()
    {
        gameOverPanel.transform.DOMoveY(310f, 3f).OnComplete(() =>
        {
            //Tamamlandýktan sonra olacaklar.
            gameOverPlayBtn.transform.DOMoveX(233f, 3f);
            gameOverQuitBtn.transform.DOMoveX(233f, 3f);
        });
    }
}
