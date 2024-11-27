using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using StudyStash.Data;
using StudyStash.Entities;
using Path = System.IO.Path;

namespace StudyStash;
public partial class MainWindow : Window
{
    private readonly DataContext _context = new DataContext();
    
    public MainWindow()
    {
        InitializeComponent();
        LoadPdfList();
        // MainFrame.Navigate(new PdfsByCategory());
        // MainFrame.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
    }

    private async void UploadPdf_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog()
        {
            Filter = "PDF Files (*.pdf)|*.pdf",
            Title = "Select Pdf Files",
        };

        if (openFileDialog.ShowDialog() == true)
        {
            // Console.WriteLine(openFileDialog.FileName);
            string fullpath = openFileDialog.FileName;
            string filename = Path.GetFileName(openFileDialog.FileName);
            byte[] filedata = File.ReadAllBytes(openFileDialog.FileName);

            string category = Microsoft.VisualBasic.Interaction.InputBox("Enter category", "Enter category", "Default");

            var pdfDocument = new Pdf()
            {
                FileName = filename,
                FileData = filedata,
                FilePath = fullpath,
                DateAdded = DateTime.Now,
                Category = category
            };

            _context.Pdfs.Add(pdfDocument);
            await _context.SaveChangesAsync();

            MessageBox.Show("File uploaded");
            LoadPdfList();
        }
    }

    private byte[] CreatePdfFromImages(string[] imagePaths)
    {
        try
        {
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                foreach (var imagePath in imagePaths)
                {
                    PdfPage page = pdfDocument.AddPage();
                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                    {
                        using (XImage img = XImage.FromFile(imagePath))
                        {
                            double widthRatio = page.Width / img.PixelWidth;
                            double heightRatio = page.Height / img.PixelHeight;
                            double scaleFactor = Math.Min(widthRatio, heightRatio);

                            double imgWidth = img.PixelWidth * scaleFactor;
                            double imgHeight = img.PixelHeight * scaleFactor;
                            
                            gfx.DrawImage(img, 0, 0, imgWidth, imgHeight);
                        }
                    }
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    return stream.ToArray();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating PDF: {ex.Message}");
            return null;
        }
    }


    private async void AddImages_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog()
        {
            Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
            Title = "Select Images",
            Multiselect = true
        };

        if (openFileDialog.ShowDialog() == true)
        {
            string[] selectedFiles = openFileDialog.FileNames;

            if (selectedFiles.Length > 0)
            {
                string pdfFileName =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the PDF", "PDF name", "MyImages.pdf");

                string category = Microsoft.VisualBasic.Interaction.InputBox("Enter category", "Enter category", "Default");

                byte[] pdfData = CreatePdfFromImages(selectedFiles);

                if (pdfData != null)
                {
                    var pdf = new Pdf()
                    {
                        FileName = pdfFileName,
                        FileData = pdfData,
                        FilePath = pdfFileName,
                        DateAdded = DateTime.Now,
                        Category = category
                    };

                    _context.Pdfs.Add(pdf);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Images converted to PDF and uploaded successfully!");
                    LoadPdfList();
                }
            }
            else
            {
                MessageBox.Show("Failed to create PDF from images.");
            }
        }
    }

    private void LoadPdfList()
    {
        var pdfs = _context.Pdfs.ToList();
        PdfListView.ItemsSource = pdfs;

        var categories = _context.Pdfs.Select(p => p.Category).Distinct().ToList();
        CategoryComboBox.ItemsSource = categories;
        // CategoryComboBox.Items.Insert(0, "All");
        CategoryComboBox.SelectedIndex = 0;
    }

    private async void FilterByCategory_Click(object sender, RoutedEventArgs e)
    {
        var comboBoxSelect = CategoryComboBox.SelectionBoxItem?.ToString();

        if (!string.IsNullOrEmpty(comboBoxSelect))
        {
            var pdfs = await _context.Pdfs.Where(p => p.Category == comboBoxSelect).ToListAsync();
            PdfListView.ItemsSource = pdfs;
        }
    }

    private async void DeletePdf_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button DeleteButton)
        {
            if (DeleteButton.Tag is int pdfId)
            {
                var res = MessageBox.Show("Are you sure you want to delete the pdf?", "Confirm Delete",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (res == MessageBoxResult.Yes)
                {
                    var pdf = await _context.Pdfs.FirstOrDefaultAsync(p => p.Id == pdfId);

                    if (pdf != null)
                    {
                        _context.Remove(pdf);
                        await _context.SaveChangesAsync();
                        MessageBox.Show("Pdf deleted!");

                        LoadPdfList();
                    }
                }
            }
        }
    }


    private async void OpenPdf_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        if (button.Tag is not int pdfId) return;

        var pdf = _context.Pdfs.FirstOrDefault(p => p.Id == pdfId);

        if (pdf == null) MessageBox.Show("Pdf not found!");

        string tempFilePath = Path.Combine(Path.GetTempPath(), pdf.FileName);

        try
        {
            File.WriteAllBytes(tempFilePath, pdf.FileData);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = tempFilePath,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening PDF: {ex.Message}");
        }
    }

    private void ViewAllItems_Click(object sender, RoutedEventArgs e)
    {
        var pdfs = _context.Pdfs.ToList();
        PdfListView.ItemsSource = pdfs;
    }
}