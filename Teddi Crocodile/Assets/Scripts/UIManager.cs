using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI starsText;


    private void Start()
    {
        AudioManager.Instance.PlayMusic("MenuMusic");
    }
    private void Update()
    {
        UpdateStarsUI();
    }
    private void UpdateStarsUI()
    {
        int sum = 0;

        for (int i = 0; i < 20; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }

        starsText.text = sum + "/" + 60;
    }

    
}
