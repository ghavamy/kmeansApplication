using Accord.MachineLearning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KmeansAlgorithm : MonoBehaviour
{
    public GameObject dataPoint;
    public GameObject panel;//for referencing main panel
    public int number_of_clusters = 3;

    private Color[] colors;
    public void Clustering()
    {
        Accord.Math.Random.Generator.Seed = 0;

        panel.SetActive(false);
        KMeans kmeans = new KMeans(number_of_clusters);
        var clusters = kmeans.Learn(TextScript.instance.textData);
        int[] label = clusters.Decide(TextScript.instance.textData);

        SetColors(number_of_clusters);
        CreatePoints(label);
    }
    private void SetColors(int k)
    {
        //setting color for each label
        colors = new Color[k];

        //giving each label a random color
        for (int i = 0; i < k; i++)
        {
            colors[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
    private void CreatePoints(int[] label)
    {
        GameObject temp;
        Vector2 pos;
        for (int i = 0; i < 150; i++)
        {
            pos = new Vector2((float)TextScript.instance.textData[i][0], (float)TextScript.instance.textData[i][1]);
            temp = Instantiate(dataPoint, pos, Quaternion.identity) as GameObject;
            temp.GetComponent<SpriteRenderer>().material.color = colors[label[i]];
        }
    }
    public void SetNumberOfClusters(string number)
    {
            number_of_clusters = int.Parse(number);
    }
}
