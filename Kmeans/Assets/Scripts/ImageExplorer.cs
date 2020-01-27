using UnityEngine;
using UnityEngine.UI;
using SmartDLL;

public class ImageExplorer : MonoBehaviour
{
    public SmartFileExplorer explorer = new SmartFileExplorer();
    public RawImage image;

    private bool readImage;

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
        WWW www = new WWW("file:///" + path);
        image.texture = www.texture;
    }
}
