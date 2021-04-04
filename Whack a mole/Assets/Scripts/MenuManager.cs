using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainPanel, CreditsPanel, InstruccionesPanel;

    void Start()
    {
        MainPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        InstruccionesPanel.SetActive(false);
    }

    public void Creditos()
    {
        MainPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        InstruccionesPanel.SetActive(false);

    }

    public void Instrucciones()
    {
        MainPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstruccionesPanel.SetActive(true);

    }

    public void backMainMenu()
    {
        MainPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        InstruccionesPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AbrirURL()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1JYOSl2XTvxUUCVzmvmpAQ293JoMT6AvH?usp=sharing");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
