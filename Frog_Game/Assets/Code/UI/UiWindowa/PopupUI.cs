using DG.Tweening;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupUI : UIWindow
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _tittleText;
    [SerializeField] private Button _buttonNo;
    [SerializeField] private Button _buttonYes;
    
    public Button ButtonNo => _buttonNo;
    public Button ButtonYes => _buttonYes;
    #region UiWindow
    [SerializeField]private RectTransform rectTransformPopUi;
    [SerializeField] private float initialHeight;
    private float _initialy;
    private float _finaly;

    
    public UnityEvent OnClicYes = new UnityEvent();
    public UnityEvent OnClicNo = new UnityEvent();
    public override void Initialize()
    {
       _initialy = rectTransformCanvasGroup.rect.height + (rectTransformPopUi.rect.height * 2) ;
       _finaly = rectTransformCanvas.position.y;
        
       Debug.Log(_initialy);
       Debug.Log(_finaly);
        
        rectTransformPopUi.DOMoveY(_initialy,0f);
        _buttonNo.onClick.AddListener(OnNoButtonClick);
        _buttonYes.onClick.AddListener(OnYesButtonClick);
    }
   public override void Show()
   {

        rectTransformPopUi.gameObject.SetActive(true);
        rectTransformPopUi.DOMoveY(_finaly,1.5f).OnComplete(() => {
        });
   }

   public override void Hide()
   {
       rectTransformPopUi.DOScale(Vector3.zero,1.5f).SetEase(EaseOut).OnComplete(() =>{

           rectTransformPopUi.gameObject.SetActive(false);
        });
    }
   #endregion

   private void OnDestroy()
   {
       _buttonYes.onClick.RemoveListener(OnYesButtonClick);
       _buttonNo.onClick.RemoveListener(OnNoButtonClick);
   }

   public void AddText(string text)
   {
       _tittleText.text = text;
       Debug.Log(_tittleText.text);
   }

   public void AddEvent()
   {
       OnClicYes.Invoke();
   }

   public void RemoveEvent()
   {
       OnClicNo.Invoke();
   }

   #region PopupUI

   private void OnYesButtonClick()
   {
       Debug.Log("Active yes");
   }
   
   private void OnNoButtonClick()
   {
       Debug.Log("Active no");
   }

   #endregion
}
