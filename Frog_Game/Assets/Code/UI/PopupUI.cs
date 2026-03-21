using DG.Tweening;
using System;
using UnityEngine;

public class PopupUI : UIWindow
{
    [SerializeField]private RectTransform rectTransformPopUi;
    [SerializeField] private float initialHeight;
    private float _initialy;
    private float _finaly;
    public override void Initialize()
    {
       _initialy = rectTransformCanvasGroup.rect.height - rectTransformPopUi.rect.height ;
        _finaly = rectTransformCanvasGroup.anchoredPosition.y ;
        rectTransformPopUi.gameObject.SetActive(false);
        rectTransformPopUi.DOMoveY(_initialy,0);
    }
   public override void Show()
   {

        rectTransformPopUi.gameObject.SetActive(true);
        rectTransformPopUi.DOMoveY(_finaly,1.5f).OnComplete(() => {
        });
   }

   public override void Hide()
   {
       rectTransformPopUi.DOScale(_initialy,1.5f).SetEase(EaseOut).OnComplete(() =>{

           rectTransformPopUi.gameObject.SetActive(false);
        });
    }
}
