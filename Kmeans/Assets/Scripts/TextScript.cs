using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextScript : MonoBehaviour
{
    public static TextScript instance;
    public double[][] textData;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        
        instance = this;
    }
    public void ReadFile()
    {
        textData = new double[150][];
        string path = "Assets/iris.txt";

        TextAsset txt = (TextAsset)Resources.Load("iris");
        print(txt.text);
        string[] lines = txt.text.Split('\n');
        //StreamReader reader = new StreamReader(path);

        int i = 0;
        foreach(string line in lines) 
        { 
            if(!string.IsNullOrWhiteSpace(line))
            {
                textData[i] = new double[4];
                string[] param = line.Split(',');
                for(int j = 0;j < 4;j++)
                {
                    textData[i][j] = 
                        double.Parse(param[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                }
                i++;
            }
        }
    }
}