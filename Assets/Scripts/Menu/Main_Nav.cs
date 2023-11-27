using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Nav : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject GuidePanel;
    [SerializeField] private GameObject General_Panel;
    [SerializeField] private GameObject Video_Panel;
    [SerializeField] private GameObject Audio_Panel;

    private void Start()
    {
        MenuPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    // --------- Menu methods 
    public void StartGame()
    {
        Debug.Log("Loading Game Scene 1");
        SceneManager.LoadScene(1);
    }
    
    public void OpenSetting()
    {
        Debug.Log("Opening setting panel");
        SettingPanel.SetActive(true);
        MenuPanel.SetActive(false);
        General_Panel.SetActive(true);
        Video_Panel.SetActive(false);
        Audio_Panel.SetActive(false);
    }

    public void OpenGuide()
    {
        Debug.Log("Opening guide panel");
        GuidePanel.SetActive(true);
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(false);
        General_Panel.SetActive(false);
        Video_Panel.SetActive(false);
        Audio_Panel.SetActive(false);

    }

    public void ExitApp()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    // --------- Menu methods 
    public void OpenMenu()
    {
        Debug.Log("Opening Menu");
        GuidePanel.SetActive(false);
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
        General_Panel.SetActive(false);
        Video_Panel.SetActive(false);
        Audio_Panel.SetActive(false);
    }

    public void OpenGeneral()
    {
        Debug.Log("Opening General panel");
        General_Panel.SetActive(true);
        Video_Panel.SetActive(false);
        Audio_Panel.SetActive(false);
    }

    public void OpenVideo()
    {
        Debug.Log("Opening Video panel");
        General_Panel.SetActive(false);
        Video_Panel.SetActive(true);
        Audio_Panel.SetActive(false);
    }

    public void OpenAudio()
    {
        Debug.Log("Opening Audio panel");
        General_Panel.SetActive(false);
        Video_Panel.SetActive(false);
        Audio_Panel.SetActive(true);
    }
}
