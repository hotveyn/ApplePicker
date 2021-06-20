using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    Vector3 rotDirection;
    public int score = 100; 
    Rigidbody rb;



    void Start()
    {
        rotDirection = RotationDirection();

        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(transform.position.y <= -20)
        {
            try
            {
                GameObject baskets = GameObject.Find("Baskets");
                Baskets bsktsScript = baskets.GetComponent<Baskets>();
                bsktsScript.DeleteOnceOfBasketAndAllDrops();
                Destroy(this.gameObject);
            }            
            catch
            {
                Destroy(this.gameObject);
            }
            
        }


        transform.Rotate(rotDirection * Time.deltaTime);
    }
   
    // ¬озвращает случайное направление вращение
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
