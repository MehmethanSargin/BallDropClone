using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    float passedObstacle = 0.0f;
    public float allObstacle;
    public TMPro.TextMeshProUGUI score_txt;
    public Image bar;
    public void passObstacle() 
    {
        score += 25;
        score_txt.text = score.ToString();
        passedObstacle += 1.0f;
        bar.fillAmount = passedObstacle / allObstacle;
    }
    public void ReturnGame() 
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void NextLevel() 
    {
        SceneManager.LoadScene("Level2");
    }
}
