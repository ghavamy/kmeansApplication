using UnityEngine;
using UnityEngine.UI;
using SmartDLL;
using Accord.Math;
using Accord.MachineLearning;
using Accord.Math.Distances;
using Accord.Imaging.Converters;
using Accord.DataSets;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

public class ImageExplorer : MonoBehaviour
{
    public SmartFileExplorer explorer = new SmartFileExplorer();
    public RawImage image;

    private bool readImage;
    private WWW www;

    public void OpenExplorer()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open a png file";
        string defExt = "png";
        string filter = "png files (*.png)|*.png";

        explorer.OpenExplorer(initialDir, restoreDir, title, defExt, filter);
        readImage = true;
    }
    private void Update()
    {
        if(explorer.resultOK && readImage)
        {
            GetImage(explorer.fileName);
            readImage = false;
        }
    }
    public void GetImage(string path)
    {
        www = new WWW("file:///" + path);
        image.texture = www.texture;
    }
    public void ImageColorClustering()
    {
        if (www != null)
        {
            // Load a test image (shown in a picture box below)
            //var sampleImages = new TestImages("Resources");
            MemoryStream bitms = new MemoryStream(www.bytes);
            Bitmap image_1 = new Bitmap(bitms);

            // ImageBox.Show("Original", image).Hold();

            // Create converters to convert between Bitmap images and double[] arrays
            var imageToArray = new ImageToArray(min: -1, max: +1);
            var arrayToImage = new ArrayToImage(image_1.Width, image_1.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels; imageToArray.Convert(image_1, out pixels);


            // Create a K-Means algorithm using given k and a
            //  square Euclidean distance as distance metric.
            KMeans kmeans = new KMeans(k: 5)
            {
                Distance = new SquareEuclidean(),

                // We will compute the K-Means algorithm until cluster centroids
                // change less than 0.5 between two iterations of the algorithm
                Tolerance = 0.05
            };


            // Learn the clusters from the data
            var clusters = kmeans.Learn(pixels);

            // Use clusters to decide class labels
            int[] labels = clusters.Decide(pixels);

            // Replace every pixel with its corresponding centroid
            double[][] replaced = pixels.Apply((x, i) => clusters.Centroids[labels[i]]);

            // Retrieve the resulting image (shown in a picture box)
            Bitmap result; arrayToImage.Convert(replaced, out result);

            //changing bitmap to texture
            MemoryStream ms = new MemoryStream();
            result.Save(ms, ImageFormat.Png);
            var buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(buffer);
            image.texture = t;
            //ImageBox.Show("k-Means clustering", result).Hold();
        }
    }
}
