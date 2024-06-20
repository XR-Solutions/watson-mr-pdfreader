//using PdfSharp.Pdf;
//using SkiaSharp;
//using UnityEngine;
//using UnityEngine.UI;

//namespace Assets.Scripts
//{
//	public class PDFRenderer : MonoBehaviour
//	{
//		public string pdfFilePath;
//		public int pageNumber = 0;
//		public RawImage pdfImage;

//		void Start()
//		{
//			Texture2D pdfTexture = RenderPageToTexture(pdfFilePath, pageNumber);
//			if (pdfTexture != null)
//			{
//				pdfImage.texture = pdfTexture;
//				pdfImage.SetNativeSize();
//			}
//		}

//		Texture2D RenderPageToTexture(string pdfPath, int pageNum)
//		{
//			using (var document = PdfDocument.Load(pdfPath))
//			{
//				var page = document.Render(pageNum, 300, 300, true);
//				var bitmap = SKBitmap.FromImage(SKImage.FromBitmap(page));

//				Texture2D texture = new Texture2D(bitmap.Width, bitmap.Height, TextureFormat.RGBA32, false);
//				var data = bitmap.Bytes;
//				texture.LoadRawTextureData(data);
//				texture.Apply();

//				return texture;
//			}
//		}
//	}//using PdfSharp.Pdf;
//using SkiaSharp;
//using UnityEngine;
//using UnityEngine.UI;

//namespace Assets.Scripts
//{
//	public class PDFRenderer : MonoBehaviour
//	{
//		public string pdfFilePath;
//		public int pageNumber = 0;
//		public RawImage pdfImage;

//		void Start()
//		{
//			Texture2D pdfTexture = RenderPageToTexture(pdfFilePath, pageNumber);
//			if (pdfTexture != null)
//			{
//				pdfImage.texture = pdfTexture;
//				pdfImage.SetNativeSize();
//			}
//		}

//		Texture2D RenderPageToTexture(string pdfPath, int pageNum)
//		{
//			using (var document = PdfDocument.Load(pdfPath))
//			{
//				var page = document.Render(pageNum, 300, 300, true);
//				var bitmap = SKBitmap.FromImage(SKImage.FromBitmap(page));

//				Texture2D texture = new Texture2D(bitmap.Width, bitmap.Height, TextureFormat.RGBA32, false);
//				var data = bitmap.Bytes;
//				texture.LoadRawTextureData(data);
//				texture.Apply();

//				return texture;
//			}
//		}
//	}
