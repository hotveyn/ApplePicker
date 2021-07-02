using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baskets : MonoBehaviour
{
    public GameObject basketPrefab;
    public List<GameObject> basketList;
    public int numBaskets = 3;
    public float basketBottomY = -8f;
    public float basketSpacingY = -2f;

    List<GameObject> allDrops = new List<GameObject>();
    private AudioSource audioSource;
    

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            tBasketGo.transform.SetParent(this.transform);
            
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            pos.x += 0.75f;
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }

        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        // Получить текущие координаты курсора мишы на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трехмерном пространстве находится курсор мыши
        mousePos2D.z = 10f;

        // Преобразовать точку на двумерной плоскости экрана в трёхмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси Х в координату Х курсора мыши
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;

        // Поворот корзин по оси y в зависимости от х координат курсора
        float h = Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        // Если корзин не осталось, то игра начинается заново
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    
    public void DeleteOnceOfBasketAndAllDrops()
    {
        // Take damage sound
        audioSource.Play();

        //Удаление одной из корзин при столкновении и всех дропов
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        Destroy(tBasketGO);
        basketList.RemoveAt(basketIndex);

        //Возвращение показателей сложности к обычному значению
        AppleTree.treeSpeed = 12f;
        Physics.gravity = new Vector3(0, -9.81f, 0);
        AppleTree.gravity = new Vector3(0, -9.81f, 0);
        AppleTree.secondBetweenDrops = 1f;
        GameObject appleTree = GameObject.Find("AppleTree");
        appleTree.transform.position = new Vector3(0, 8f, -0.5f);
       

        // Помещение всех дропов(яблок, золотых яблок и бомб) в список
        foreach(GameObject apples in GameObject.FindGameObjectsWithTag("Apple"))
        {
            allDrops.Add(apples);
        }
        foreach(GameObject goldenApples in GameObject.FindGameObjectsWithTag("GoldenApple"))
        {
            allDrops.Add(goldenApples);
        }
        foreach(GameObject bombs in GameObject.FindGameObjectsWithTag("Bomb"))
        {
            allDrops.Add(bombs);
        }
        // Удаляем все дропы
        foreach(GameObject drop in allDrops)
        {
            Destroy(drop);
        }


    }

}
