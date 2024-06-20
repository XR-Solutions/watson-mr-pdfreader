using UnityEngine;


#if !UNITY_EDITOR && UNITY_WSA_10_0
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
#endif

public class FilePicker : MonoBehaviour
{
	public string currentFilePath = string.Empty;
	// Start is called before the first frame update

	public void SelectFile()
	{
		Debug.Log("Selecting file");
#if !UNITY_EDITOR && UNITY_WSA_10_0
		Debug.Log("***********************************");
		Debug.Log("File Picker start.");
		Debug.Log("***********************************");

		UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
		{
			var filepicker = new FileOpenPicker();
			// filepicker.FileTypeFilter.Add("*");
			filepicker.FileTypeFilter.Add(".pdf");

			var file = await filepicker.PickSingleFileAsync();
			UnityEngine.WSA.Application.InvokeOnAppThread(() => 
			{
				Debug.Log("***********************************");
				string name = (file != null) ? file.Name : "No data";
				Debug.Log("Name: " + name);
				Debug.Log("***********************************");
				string path = (file != null) ? file.Path : "No data";
				Debug.Log("Path: " + path);
				Debug.Log("***********************************");

				// ReadTextFile(path);
				currentFilePath = path;

			}, false);
		}, false);

		
		Debug.Log("***********************************");
		Debug.Log("File Picker end.");
		Debug.Log("***********************************");
#endif
	}
}