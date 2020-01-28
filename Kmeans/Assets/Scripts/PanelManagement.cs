using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagement : MonoBehaviour
{
    public GameObject definition_Panel;
    public GameObject iris_Panel;
    public GameObject image_Panel;

    public void GoToIrisPage()
    {
        definition_Panel.SetActive(false);
        iris_Panel.SetActive(true);
    }
    public void GoToImagePanel()
    {
        definition_Panel.SetActive(false);
        image_Panel.SetActive(true);
    }
    public void BackFromIrisPanel()
    {
        KmeansAlgorithm.instance.RemovePoints();
        iris_Panel.SetActive(false);
        definition_Panel.SetActive(true);
    }
    public void BackFromImagePanel()
    {
        image_Panel.SetActive(false);
        definition_Panel.SetActive(true);
    }
    public void ExitProgram()
    {
        Application.Quit(0);
    }
}
