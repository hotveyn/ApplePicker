using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScript : MonoBehaviour
{
    static public int score = 0;

    private void Awake()
    {

        // ���� �������� HighScore ��� ��������� � PLayerPrefs, �� ��������� ���
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // ��������� ������ ���������� HighScore � ���������
        PlayerPrefs.SetInt("HighScore", score);

    }
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
