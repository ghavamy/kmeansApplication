using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartProgram : MonoBehaviour
{
    public GameObject introPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartIntro");
    }
    IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(4f);
        introPanel.SetActive(true);
    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitProgram()
    {
        Application.Quit(0);
    }
}
