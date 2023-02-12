using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject plyMusic;
    [SerializeField] private GameObject Volume;
    [SerializeField] private GameObject plyMenu;
    [SerializeField] private GameObject exitMenuText;
    [SerializeField] private GameObject plyMenuButton;
    [SerializeField] private GameObject settingMenuButton;
    [SerializeField] private GameObject exitMenuButton;
    [SerializeField] private GameObject totalStars;
    
    public void LoadScene (int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }


    public void ClosePlyMenu()
    {
        plyMenu.SetActive(false);
        settingMenuButton.SetActive(true);
        plyMenuButton.SetActive(true);
        exitMenuButton.SetActive(true);
        totalStars.SetActive(false);
        
    }

    public void OpenPlyMenu()
    {
        plyMenu.SetActive(true);
        settingMenuButton.SetActive(false);
        plyMenuButton.SetActive(false);
        exitMenuButton.SetActive(false);
        totalStars.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void NoExit()
    {
        exitMenuText.SetActive(false);
        plyMenuButton.SetActive(true);
        settingMenuButton.SetActive(true);
        exitMenuButton.SetActive(true);
    }


    public void Exitquestion()
    {
        exitMenuText.SetActive(true);
        plyMenuButton.SetActive(false);
        settingMenuButton.SetActive(false);
        exitMenuButton.SetActive(false);
    }

    public void CloseVolumeSetting()
    {
        Volume.SetActive(false);
        plyMenuButton.SetActive(true);
        exitMenuButton.SetActive(true);
        settingMenuButton.SetActive(true);

    }
    public void MenuSetting()
    {
        Volume.SetActive(true);
        settingMenuButton.SetActive(false);
        plyMenuButton.SetActive(false);
        exitMenuButton.SetActive(false);
    }
}
