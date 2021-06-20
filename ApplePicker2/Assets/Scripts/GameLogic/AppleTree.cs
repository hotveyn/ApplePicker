using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    
    static public float treeSpeed = 12f;
    static public Vector3 gravity = new Vector3(0, -9.81f, 0);
    public float chanceToChangeDirection = 1f;
    static public float secondBetweenDrops = 1f;
    public float chanceToDropGoldenApple = 10f;
    public float chanceToDropBomb = 25f;

    public float secondsBetweenDifficultyUp = 3f;
    public float numberOfSpeedUp = 0.6f;
    public float numberOfGravityUp = 1f;
    public float numberOfAppleDropsUp = 0.2f;

    public float leftEdge = -24.3f;
    public float rightEdge = 24.3f;

    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject bombPrefab;

    Vector3 pos;


    private void Start()
    {
        InvokeRepeating("ThingDrop", 1f, secondBetweenDrops);
        InvokeRepeating("DifficultyUp", 3f, secondsBetweenDifficultyUp);
    }
    void Update()
    {
        // ƒвигает дерево в одну из сторон
        pos = transform.position;
        pos.x += treeSpeed * Time.deltaTime;
        transform.position = pos;
        if(transform.position.x <= leftEdge)
        {
            treeSpeed = Mathf.Abs(treeSpeed);
        }
        if(transform.position.x >= rightEdge)
        {
            treeSpeed = -Mathf.Abs(treeSpeed);
        }

        // ¬ращение дерево по своей оси
        transform.Rotate(new Vector3(0f, 10f * Time.deltaTime, 0f)); 
        
    }

    private void FixedUpdate()
    {
        // — некоторым шансом мен€тем направление движени€
        if (Random.Range(0f, 100f) <= chanceToChangeDirection)
        {
            treeSpeed = -treeSpeed;
        }
    }

    // —брасывает предмет на позиции €блони
    void ThingDrop()
    {
        Vector3 thingPos;
        thingPos = transform.position;
        thingPos.y += 5;
        
        if (UnityEngine.Random.Range(0, 100) < chanceToDropGoldenApple)
        {
            GameObject goldenApple = Instantiate<GameObject>(goldenApplePrefab);            
            goldenApple.transform.position = thingPos;
            
        }
        else if (UnityEngine.Random.Range(0, 100) < chanceToDropBomb)
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);            
            bomb.transform.position = thingPos;
            
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);           
            apple.transform.position = thingPos;
            
        }
    }

    //”величивает cложность путЄм увеличивани€ скорости €блони и (реализую потом) скорости падени€ €блок
    void DifficultyUp()
    {
        treeSpeed = Mathf.Abs(treeSpeed) + numberOfSpeedUp;

        gravity.y -= numberOfGravityUp;
        Physics.gravity = gravity;
        print(Physics.gravity);

        secondBetweenDrops -= numberOfAppleDropsUp;
    }
}
