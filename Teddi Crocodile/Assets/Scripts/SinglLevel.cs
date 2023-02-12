using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglLevel : MonoBehaviour
{
    private int starsNum;
    private int currenStarsNum = 0;
    public int levelIndex;


    [SerializeField] private GameObject scoreStarPanel;
    [SerializeField] private GameObject starCollect1;
    [SerializeField] private GameObject starCollect2;
    [SerializeField] private GameObject starCollect3;

    [SerializeField] private GameObject panelComplite;
    [SerializeField] private GameObject compliteStars1;
    [SerializeField] private GameObject compliteStars2;
    [SerializeField] private GameObject compliteStars3;
    [SerializeField] private GameObject controlPanel;

    private bool star1;
    private bool star2;
    private bool star3;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        StarCheack();
        StarCheack2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            starsNum++;
            AudioManager.Instance.PlaySFX("StarSound");
        }
        if (collision.gameObject.name == "Finish")
        {
            AudioManager.Instance.PlaySFX("FinishSound");
            AudioManager.Instance.musicSource.Stop();
            Level();
            panelComplite.SetActive(true);
            scoreStarPanel.SetActive(false);
            controlPanel.SetActive(false);
            if (star1)
            {
                compliteStars1.SetActive(true);
            }
            if (star2)
            {
                compliteStars2.SetActive(true);
            }
            if (star3)
            {
                compliteStars3.SetActive(true);
            }
        }
    }
    public void Level()
    {
        currenStarsNum = starsNum;
        if (currenStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, starsNum);
        }
    }
    private void StarCheack()
    {
        if (star1)
        {
            starCollect1.SetActive(true);
        }
        if (star2)
        {
            starCollect2.SetActive(true);
        }
        if (star3)
        {
            starCollect3.SetActive(true);
        }
    }

    private void StarCheack2()
    {
        if (starsNum == 1)
        {
            star1 = true;
        }
        if (starsNum == 2)
        {
            star2 = true;
        }
        if (starsNum == 3)
        {
            star3 = true;
        }
    }

}
