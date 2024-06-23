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
	[SerializeField] private TextMeshProUGUI text = null;
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
		Debug.Log("Loading pdf");
#if !UNITY_EDITOR && UNITY_WSA
		if (!string.IsNullOrEmpty(filePicker.currentFilePath))
		{
			LoadAsync(filePicker.currentFilePath);
		}
		else
		{
			text.text = "No file selected.";
		}
#endif
	}

	private async void LoadAsync(string path)
	{
#if !UNITY_EDITOR && UNITY_WSA
		text.text += "Starting LoadAsync\n";
		try
		{
			StorageFile sampleFile = await StorageFile.GetFileFromPathAsync(path);
			pdfDocument = await PdfDocument.LoadFromFileAsync(sampleFile);
			text.text += "PDF document loaded\n";
		}
		catch (Exception e)
		{
			text.text += "Error loading PDF document: " + e.Message + "\n";
		}
#endif
	}

	public async void ChangePageAsync(int pageNumber)
	{
#if !UNITY_EDITOR && UNITY_WSA
		if (pdfDocument == null)
		{
			text.text += "PDF document is not loaded.\n";
			return;
		}

		try
		{
			text.text += "Starting ChangePageAsync\n";
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

				text.text += "Page loaded and texture applied: " + pageNumber + "\n";
			}
		}
		catch (Exception e)
		{
			text.text += "Error changing page: " + e.Message + "\n";
		}
#endif
	}
}
