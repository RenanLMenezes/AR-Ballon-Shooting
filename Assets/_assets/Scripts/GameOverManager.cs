using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private float timer = 10;

    [SerializeField]
    private TMP_Text timerTxt;
    [SerializeField]
    private TMP_Text scoreTxt;

    private void Start()
    {
        scoreTxt.text = $"Score: {GameManager.points}";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int sec = (int)timer % 60;
        timerTxt.text = $"The game will return to the menu in {sec} seconds";
        
        if(timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
