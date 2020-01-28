using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxisManagement : MonoBehaviour
{
    public static AxisManagement instance;

    public int horizontalIndex = 0;
    public int verticalIndex = 1;
    public Text vertical_text;
    public Text horizontal_text;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    //for horizontal axis
    public void HorizontalSepalLength(bool isOn)
    {
        if (isOn)
        {
            horizontalIndex = 0;
            horizontal_text.text = "Sepal Length"; 
        }
    }
    public void HorizontalSepalWidth(bool isOn)
    {
        if (isOn)
        {
            horizontalIndex = 1;
            horizontal_text.text = "Sepal Width";
        }
    }
    public void HorizontalPetalLength(bool isOn)
    {
        if (isOn)
        {
            horizontalIndex = 2;
            horizontal_text.text = "Petal Length";
        }
    }
    public void HorizontalPetalWidth(bool isOn)
    {
        if (isOn)
        {
            horizontalIndex = 3;
            horizontal_text.text = "Petal Width";
        }
    }
    //for vertical axis
    public void VerticalSepalLength(bool isOn)
    {
        if (isOn)
        {
            verticalIndex = 0;
            vertical_text.text = "Sepal Length";
        }
    }
    public void VerticalSepalWidth(bool isOn)
    {
        if (isOn)
        {
            verticalIndex = 1;
            vertical_text.text = "Sepal Width";
        }
    }
    public void VerticalPetalLength(bool isOn)
    {
        if (isOn)
        {
            verticalIndex = 2;
            vertical_text.text = "Petal Length";
        }
    }
    public void VerticalPetalWidth(bool isOn)
    {
        if (isOn)
        {
            verticalIndex = 3;
            vertical_text.text = "Petal Width";
        }
    }
}
