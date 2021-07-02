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

        // �������� ������� ���������� ������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� Z ������ ����������, ��� ������ � ���������� ������������ ��������� ������ ����
        mousePos2D.z = 10f;

        // ������������� ����� �� ��������� ��������� ������ � ��������� ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� � � ���������� � ������� ����
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;

        // ������� ������ �� ��� y � ����������� �� � ��������� �������
        float h = Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        // ���� ������ �� ��������, �� ���� ���������� ������
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    
    public void DeleteOnceOfBasketAndAllDrops()
    {
        // Take damage sound
        audioSource.Play();

        //�������� ����� �� ������ ��� ������������ � ���� ������
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        Destroy(tBasketGO);
        basketList.RemoveAt(basketIndex);

        //����������� ����������� ��������� � �������� ��������
        AppleTree.treeSpeed = 12f;
        Physics.gravity = new Vector3(0, -9.81f, 0);
        AppleTree.gravity = new Vector3(0, -9.81f, 0);
        AppleTree.secondBetweenDrops = 1f;
        GameObject appleTree = GameObject.Find("AppleTree");
        appleTree.transform.position = new Vector3(0, 8f, -0.5f);
       

        // ��������� ���� ������(�����, ������� ����� � ����) � ������
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
        // ������� ��� �����
        foreach(GameObject drop in allDrops)
        {
            Destroy(drop);
        }


    }

}
