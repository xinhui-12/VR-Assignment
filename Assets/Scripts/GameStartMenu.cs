using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject setting;
    //public GameObject about;

    [Header("Main Menu Buttons")]
    public Button selectEnvironment;
    public Button settingButton;
    public Button exitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        selectEnvironment.onClick.AddListener(SelectEnvironment);
        settingButton.onClick.AddListener(GameSetting);
        exitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectEnvironment()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        setting.SetActive(false);
        //about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        setting.SetActive(true);
        //about.SetActive(false);
    }
    public void GameSetting()
    {
        mainMenu.SetActive(false);
        setting.SetActive(true);
        //about.SetActive(false);
    }
    //public void EnableAbout()
    //{
    //    mainMenu.SetActive(false);
    //    setting.SetActive(false);
    //    //about.SetActive(true);
    //}
}
