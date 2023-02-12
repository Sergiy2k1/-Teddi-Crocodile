using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars = new GameObject[3];

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Time.timeScale = 1;
        //PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);

            for(int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.SetActive(true);

            }
        }
    }

    private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

    public void PressSelection(int _sceneid)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_sceneid);
        }
    }
}
