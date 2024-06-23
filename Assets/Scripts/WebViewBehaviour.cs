//using Microsoft.MixedReality.WebView;
//using System;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class WebViewBehaviour : MonoBehaviour, IPointerDownHandler
//{
//	private IWebView _webView;

//	private void Start()
//	{
//		GetComponentInChildren<WebView>().GetWebViewWhenReady(webView =>
//		{
//			_webView = webView;
//		});
//	}

//	public void OnPointerDown(MixedRealityPointerEventData eventData)
//	{
//		IWithMouseEvents mouseEventsWebView = _webView as IWithMouseEvents;

//		var hitCoord = ConvertToWebViewSpace(eventData.Pointer.Position.x, eventData.Pointer.Position.y);

//		WebViewMouseEventData mouseEvent = new()
//		{
//			X = hitCoord.x,
//			Y = hitCoord.y,
//			Type = WebViewMouseEventData.EventType.MouseDown,
//			Button = WebViewMouseEventData.MouseButton.ButtonLeft,
//			TertiaryAxisDeviceType = WebViewMouseEventData.TertiaryAxisDevice.PointingDevice
//		};

//		mouseEventsWebView.MouseEvent(mouseEvent);
//	}

//	private Vector2Int ConvertToWebViewSpace(float xPos, float yPos)
//	{
//		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), new Vector2(xPos, yPos), Camera.main, out Vector2 localPoint);

//		return Vector2Int.RoundToInt(localPoint);
//	}


//}
