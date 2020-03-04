using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWebView : MonoBehaviour
{
  [SerializeField] private WebViewObject webViewObject;
  	private const float varticalMarginOffset = 9f;
    private RectTransform contentsPanel;
    [SerializeField] private Transform webViewPanel;
    public string webViewURL;

    private void Start()
    {
      contentsPanel = GetComponent<RectTransform>();
    }

  public void OpenWebView () {
        webViewPanel.gameObject.SetActive(true);
  webViewObject =
    (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
  webViewObject.Init((msg)=>{
         // Dev.Log(string.Format("CallFromJS[{0}]", msg));
    //if (msg == "close")
          //CloseAll();
      });
  int webViewWidth = (int)((
    Screen.height - (Screen.height / varticalMarginOffset) * 2.2f)
    * (contentsPanel.sizeDelta.x / contentsPanel.sizeDelta.y));
  webViewObject.SetMargins(
    (int)((float)(Screen.width - webViewWidth) / 2),
    (int)(Screen.height / (varticalMarginOffset-2)),
    (int)((float)(Screen.width - webViewWidth) / 2),
    (int)((Screen.height / (varticalMarginOffset-2)) * 1.2f)
  );
  webViewObject.LoadURL( webViewURL );
}
}
