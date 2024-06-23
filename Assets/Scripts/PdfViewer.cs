using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Collections;
using TMPro;
using System.Threading.Tasks;

#if !UNITY_EDITOR && UNITY_WSA
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Data.Pdf;
#endif

public class PdfViewer : MonoBehaviour
{
	[SerializeField] private GameObject PDFPlane = null;
	[SerializeField] private FilePicker filePicker = null;

#if !UNITY_EDITOR && UNITY_WSA
	PdfDocument pdfDocument;
#endif
	public void Start()
	{
		filePicker.SelectFile();
		LoadPdf();
	}

	public void LoadPdf()
	{
		Debug.Log($"Loading pdf path:'C:\\Users\\roman\\Music\\sporenmatrix-2.pdf'");

#if !UNITY_EDITOR && UNITY_WSA
		if (!string.IsNullOrEmpty("C:\\Users\\roman\\Music\\sporenmatrix-2.pdf"))
		{
			LoadAsync("C:\\Users\\roman\\Music\\sporenmatrix-2.pdf");
		}
		else
		{
			Debug.Log($"No file selected");
		}
#endif
	}

	private async void LoadAsync(string path)
	{
#if !UNITY_EDITOR && UNITY_WSA
		Debug.Log("Starting loadAsync");
		try
		{
			StorageFile sampleFile = await StorageFile.GetFileFromPathAsync(path);
			pdfDocument = await PdfDocument.LoadFromFileAsync(sampleFile);
			Debug.Log("Pdf loaded");
		}
		catch (Exception e)
		{
			Debug.Log(e);
			Debug.Log(e.Message);
		}
#endif
	}

	public async void ChangePageAsync(int pageNumber)
	{
#if !UNITY_EDITOR && UNITY_WSA
		if (pdfDocument == null)
		{
			Debug.Log("Pdf is not loaded");
			return;
		}

		try
		{
			Debug.Log("Starting ChangePageAsync");
			using (PdfPage pdfPage = pdfDocument.GetPage((uint)pageNumber))
			{
				InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
				await pdfPage.RenderToStreamAsync(stream);

				MemoryStream tempStream = new MemoryStream();
				await stream.AsStream().CopyToAsync(tempStream);

				byte[] imgBytes = tempStream.ToArray();

				Texture2D imgTex = new Texture2D(2048, 2048, TextureFormat.RGBA32, false);
				imgTex.LoadImage(imgBytes);
				imgTex.filterMode = FilterMode.Bilinear;
				imgTex.wrapMode = TextureWrapMode.Clamp;

				MeshRenderer meshRenderer = PDFPlane.GetComponent<MeshRenderer>();
				Material mat = meshRenderer.material;
				mat.SetTexture("_MainTex", imgTex);
				mat.mainTextureScale = new Vector2(1, 1);

				Debug.Log( "Page loaded and texture applied: " + pageNumber + "\n");
			}
		}
		catch (Exception e)
		{
			Debug.Log("Error changing page: " + e.Message + "\n");
		}
#endif
	}
}
