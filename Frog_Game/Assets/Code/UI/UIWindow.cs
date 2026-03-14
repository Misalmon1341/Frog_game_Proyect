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
    }
 
    [Button]
    public virtual void Show()
    {
        canvas.gameObject.SetActive(true);
    }
    
    [Button]
    public virtual void Hide()
    {
        canvas.gameObject.SetActive(false);
    }
}
