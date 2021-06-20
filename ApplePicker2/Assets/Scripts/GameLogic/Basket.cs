using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }
    

    void OnCollisionEnter(Collision collision)
    {        
        int score = int.Parse(scoreGT.text);
        GameObject colled = collision.gameObject;
        if (colled.tag == "Apple")
        {
            // Add 100 point to score counter     
            Apple appleScript = colled.GetComponent<Apple>();
            score += appleScript.score;
            scoreGT.text = score.ToString();

            Destroy(colled);
        }
        else if (colled.tag == "GoldenApple")
        {
            // Add 1000 point to score counter      
            GoldenApple gldnScript = colled.GetComponent<GoldenApple>();
            score += gldnScript.score;
            scoreGT.text = score.ToString();

            Destroy(colled);
        }
        else if (colled.tag == "Bomb")
        {
            // Delete 1 basket           
            GameObject baskets = GameObject.Find("Baskets");
            Baskets bsktsScript = baskets.GetComponent<Baskets>();
            bsktsScript.DeleteOnceOfBasketAndAllDrops();

            Bomb bmbScript = colled.GetComponent<Bomb>();
            score += bmbScript.score;
            scoreGT.text = score.ToString();

            Destroy(colled);
        }

        // Remember high score
        if (score > HighScript.score)
        {
            HighScript.score = score;
        }
    }
    
}
