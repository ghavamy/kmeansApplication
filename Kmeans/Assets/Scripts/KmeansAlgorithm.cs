using Accord.MachineLearning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KmeansAlgorithm : MonoBehaviour
{
    public static KmeansAlgorithm instance;
    public GameObject dataPoint;
    public int number_of_clusters = 3;

    private Color[] colors;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    public void Clustering()
    {
        Accord.Math.Random.Generator.Seed = 0;

        TextScript.instance.ReadFile();
        KMeans kmeans = new KMeans(number_of_clusters);
        var clusters = kmeans.Learn(TextScript.instance.textData);
        int[] label = clusters.Decide(TextScript.instance.textData);

        SetColors(number_of_clusters);
        GeneratePoints(label);
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
    private void GeneratePoints(int[] label)
    {
        RemovePoints();

        GameObject temp;
        Vector2 pos;
        for (int i = 0; i < 150; i++)
        {
            pos = new Vector2((float)TextScript.instance.textData[i][AxisManagement.instance.horizontalIndex] - 2f,
                (float)TextScript.instance.textData[i][AxisManagement.instance.verticalIndex] - 2f);
            temp = Instantiate(dataPoint, pos, Quaternion.identity) as GameObject;
            temp.GetComponent<SpriteRenderer>().material.color = colors[label[i]];
        }
    }
    public void RemovePoints()
    {
        GameObject[] previousBall = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < previousBall.Length; i++)
        {
            Destroy(previousBall[i]);
        }
    }
    public void SetNumberOfClusters(string number)
    {
        if (!string.IsNullOrEmpty(number))
        {
            number_of_clusters = int.Parse(number);
        }
    }
}
