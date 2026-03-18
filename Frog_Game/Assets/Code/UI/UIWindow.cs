using DG.Tweening;
using NaughtyAttributes;
using NUnit.Framework.Constraints;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [Header("UI Window")] [SerializeField] private string windowId;
    
    [Header("UI References")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private bool hideOnStart = true;
    private RectTransform rectTransformCanvasGroup => canvasGroup.GetComponent<RectTransform>();
    
    public string WindowId => windowId;
    
    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Initialize();
    }
    
    
    public void Initialize()
    { 
        canvas.gameObject.SetActive(!hideOnStart);
        rectTransformCanvasGroup.localScale = Vector3.zero;
    }
 
    [Button]
    public virtual void Show()
    {
        //canvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
        rectTransformCanvasGroup.DOScale(Vector3.one, 0.5f);
    }
    
    [Button]
    public virtual void Hide()
    {
        rectTransformCanvasGroup.DOScale(Vector3.zero, 0.5f).OnComplete (() =>
        {
            canvas.gameObject.SetActive(false);
        });
        
    }
}
