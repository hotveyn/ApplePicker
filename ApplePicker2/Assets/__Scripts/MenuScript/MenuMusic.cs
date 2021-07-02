using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(createdTag);
        if(obj != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.tag = createdTag;
            DontDestroyOnLoad(gameObject);
        }
    }
}
