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
    private int level = 1;

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
    }

    private void OnLevelWasLoaded(int index)
    {
        level++;
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
