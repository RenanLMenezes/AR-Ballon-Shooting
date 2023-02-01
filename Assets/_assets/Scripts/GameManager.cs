using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int points = 0;
    private static float timer = 90;

    [SerializeField]
    private List<GameObject> bloons;
    [SerializeField]
    private Camera arCam;
    [SerializeField]
    private TMP_Text pointsTxt;
    [SerializeField]
    private TMP_Text timerTxt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
        GameManager.points = 0;
        GameManager.timer = 90;
    }

    // Update is called once per frame
    void Update()
    {
        pointsTxt.text = $"Points: {points}";
        timer -= Time.deltaTime;
        int sec = ((int)GameManager.timer % 60);
        int min = ((int)GameManager.timer / 60);
        timerTxt.text = GameManager.timer > 0 ? string.Format("{0:00}:{1:00}", min, sec) : "00:00";
        if(timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator SpawnObjects()
    {
        GameObject balloon;
        Vector3 pos = arCam.transform.position + arCam.transform.forward * Random.Range(4, 10);
        pos.y -= 4;        
        
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);

            pos.x = Random.Range(-5, 5);
            balloon = Instantiate(bloons[Random.Range(0, bloons.Count)], pos, Quaternion.identity);
        }

        
    }
}
