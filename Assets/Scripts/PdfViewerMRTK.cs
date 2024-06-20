//using UnityEngine.UI;

//namespace Assets.Scripts
//{
//	internal class PdfViewerMRTK
//	{
//		public string pdfFilePath;
//		public int pageNumber = 0;
//		public RawImage pdfImage;
//		public Button nextPageButton;
//		public Button previousPageButton;
//		private PDFRenderer pdfRenderer;

//		void Start()
//		{
//			pdfRenderer = new PDFRenderer();
//			pdfRenderer.pdfFilePath = pdfFilePath;
//			pdfRenderer.pdfImage = pdfImage;

//			RenderPage();

//			nextPageButton.onClick.AddListener(() =>
//			{
//				pageNumber++;
//				RenderPage();
//			});

//			previousPageButton.onClick.AddListener(() =>
//			{
//				pageNumber--;
//				RenderPage();
//			});
//		}

//		void RenderPage()
//		{
//			pdfRenderer.pageNumber = pageNumber;
//			pdfRenderer.Start();
//		}
//	}
//}
