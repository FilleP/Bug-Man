using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float startDelay = 2f;
    public int playerHealth = 10;
    public static GameManager instance = null;

    private Text levelText;
    private GameObject levelImage;
    private int level = 1;
    private bool doingSetup;
    private bool enemiesMoving;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    private void OnLevelWasLoaded(int index)
    {
        level++;

        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level" + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", startDelay);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "Game Over " + "Level:" + level;

        levelImage.SetActive(true);

        enabled = false;
    }

    void Update()
    {
        if (doingSetup)
        {
            return;
        }
        else
        {
            enemiesMoving = true;
        }
    }
}
