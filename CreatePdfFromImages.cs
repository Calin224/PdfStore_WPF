//
//
// private byte[] CreatePdfFromImages(string[] imagePaths)
// {
//     try
//     {
//         using (PdfDocument pdfDocument = new PdfDocument())
//         {
//             foreach (var imagePath in imagePaths)
//             {
//                 PdfPage page = pdfDocument.AddPage();
//                 using (XGraphics gfx = XGraphics.FromPdfPage(page))
//                 {
//                     using (XImage img = XImage.FromFile(imagePath))
//                     {
//                         double widthRatio = page.Width / img.PixelWidth;
//                         double heightRatio = page.Height / img.PixelHeight;
//                         double scaleFactor = Math.Min(widthRatio, heightRatio);
//
//                         double imgWidth = img.PixelWidth * scaleFactor;
//                         double imgHeight = img.PixelHeight * scaleFactor;
//
//                         gfx.DrawImage(img, 0, 0, imgWidth, imgHeight);
//                     }
//                 }
//             }
//
//             using (MemoryStream stream = new MemoryStream())
//             {
//                 pdfDocument.Save(stream);
//                 return stream.ToArray();
//             }
//         }
//     }
//     catch (Exception ex)
//     {
//         MessageBox.Show($"Error creating PDF: {ex.Message}");
//         return null;
//     }
// }
