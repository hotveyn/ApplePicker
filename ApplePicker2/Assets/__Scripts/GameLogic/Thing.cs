using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    
    Vector3 rotDirection;
    

    void Start()
    {
        rotDirection = RotationDirection();
    }

    void Update()
    {
        if (transform.position.y < -20f)
        {
            if (tag != "Bomb")
            {
                GameObject basketSpawn = GameObject.Find("Baskets");
                Baskets bskSpawn = basketSpawn.GetComponent<Baskets>();
                
                List<GameObject> tAppleList = new List<GameObject>();
                foreach (GameObject allAples in GameObject.FindGameObjectsWithTag("Apple"))
                {
                    tAppleList.Add(allAples);
                }
                foreach (GameObject allAples in GameObject.FindGameObjectsWithTag("GoldenApple"))
                {
                    tAppleList.Add(allAples);
                }
                foreach (GameObject allAples in GameObject.FindGameObjectsWithTag("Bomb"))
                {
                    tAppleList.Add(allAples);
                }
                foreach (GameObject tGO in tAppleList)
                {
                    Destroy(tGO);
                }

                //bskSpawn.DeleteOnceOfBasket();

                

            }
            Destroy(this.gameObject);                   
        }

        transform.Rotate(rotDirection * Time.deltaTime);
    }

    Vector3 RotationDirection()
    {
        int minusOrPlus;
        Vector3 rotationDirection = new Vector3(0f, 0f, 0f);

        minusOrPlus = Random.Range(0, 2);
        if (minusOrPlus == 0)
        {
            rotationDirection.x = Random.Range(30f, 60f);
        }
        else
        {
            rotationDirection.x = Random.Range(-60f, -30f);
        }

        minusOrPlus = Random.Range(0, 2);
        if (minusOrPlus == 0)
        {
            rotationDirection.y = Random.Range(30f, 60f);
        }
        else
        {
            rotationDirection.y = Random.Range(-60f, -30f);
        }
       
        return rotationDirection;
    }

}
