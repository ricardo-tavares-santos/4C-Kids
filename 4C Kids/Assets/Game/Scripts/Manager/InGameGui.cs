﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameGui : MonoBehaviour {

    private AudioSource sound;
    public GameObject gameOn , gameOver;
    public Text score, best, ingameScore, pointText;
    public Color[] medalCols;
    public Image medal;
    public Button homeBtn, leaderBtn, retryBtn, shareBtn;
    public string mainMenu;
    int i = 0;
	int count = 0;
	// Use this for initialization
	void Start ()
    {
        sound = GetComponent<AudioSource>();
        GameManager.instance.currentScore = 0;
        ingameScore.text = "" + GameManager.instance.currentScore;
        homeBtn.GetComponent<Button>().onClick.AddListener(() => { HomeBtn(); });    //home
        leaderBtn.GetComponent<Button>().onClick.AddListener(() => { LeaderboardBtn(); });    //leaderboard
        retryBtn.GetComponent<Button>().onClick.AddListener(() => { RetryBtn(); });    //retry
        shareBtn.GetComponent<Button>().onClick.AddListener(() => { ShareBtn(); });    //snapshot
        
    }

    // Update is called once per frame
    void Update ()
    {
        ingameScore.text = "" + GameManager.instance.currentScore;

        if (GameManager.instance.currentScore >= GameManager.instance.hiScore)
        {
            GameManager.instance.hiScore = GameManager.instance.currentScore;
            GameManager.instance.Save();
        }

        if (GameManager.instance.isGameOver)
        {
            score.text = "" + GameManager.instance.currentScore;
            best.text = "" + GameManager.instance.hiScore;
            MedalColor();
            gameOn.SetActive(false);
            gameOver.SetActive(true);

if (count == 0) {
	AdsManager.instance.ShowInterstitial(); 
	count = 1;
}

            if (GameManager.instance.currentScore >= 10 && i == 0)
            {
                int point = GameManager.instance.currentScore / 10;
                pointText.text = "+" + point;
                GameManager.instance.points = point;
                GameManager.instance.Save();
                i = 1;
            }
        }

    }

    void HomeBtn()
    {
        sound.Play();
        GameManager.instance.isGameOver = false;
        SceneManager.LoadScene(mainMenu);
    }

    void RetryBtn()
    {
        sound.Play();
        GameManager.instance.isGameOver = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    void LeaderboardBtn()
    {
        sound.Play();
    }

    void ShareBtn()
    {
        sound.Play();
        //FacebookShare.instance.FBShareLink();
    }

    void MedalColor()
    {
        if (GameManager.instance.currentScore >= 10)
        {
            medal.color = medalCols[0];
        }
        else if (GameManager.instance.currentScore >= 25)
        {
            medal.color = medalCols[1];
        }
        else if (GameManager.instance.currentScore >= 40)
        {
            medal.color = medalCols[2];
        }
        else if (GameManager.instance.currentScore >= 60)
        {
            medal.color = medalCols[3];
        }
        else if (GameManager.instance.currentScore >= 80)
        {
            medal.color = medalCols[4];
        }
    }


}
