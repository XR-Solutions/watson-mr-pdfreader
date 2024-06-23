//using Microsoft.MixedReality.WebView;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class WebViewBehaviour : MonoBehaviour, IPointerClickHandler
//{
//	[SerializeField]
//	private string url = "http://google.com"; // Set your URL here

//	private WebView webViewComponent;

//	private void Start()
//	{
//		webViewComponent = gameObject.GetComponent<WebView>();

//		if (!string.IsNullOrEmpty(url))
//		{
//			Debug.Log("Loading URL: " + url);
//			webViewComponent.Load(new System.Uri(url));
//		}
//	}

//	public void OnPointerClick(PointerEventData eventData)
//	{
//		Debug.Log("Pointer click");
//		HandlePointerEvent(eventData.position, WebViewMouseEventData.EventType.MouseDown);
//	}

//	private void HandlePointerEvent(Vector2 screenPosition, WebViewMouseEventData.EventType eventType)
//	{
//		if (webViewComponent is IWithMouseEvents mouseEventsWebView)
//		{
//			WebViewMouseEventData mouseEvent = new WebViewMouseEventData
//			{
//				X = (int)screenPosition.x,
//				Y = (int)screenPosition.y,
//				Type = eventType,
//				Button = WebViewMouseEventData.MouseButton.ButtonLeft,
//				TertiaryAxisDeviceType = WebViewMouseEventData.TertiaryAxisDevice.PointingDevice
//			};

//			Debug.Log($"Mouse event position: {mouseEvent.X},{mouseEvent.Y}");

//			// Propagate the event to the WebView plugin
//			mouseEventsWebView.MouseEvent(mouseEvent);
//		}
//	}
//}
