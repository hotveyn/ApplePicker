using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : Thing
{   
    void Start()
    {
        score = -500;
    }

    public override void OverBottom()
    {
        Destroy(this.gameObject);
    }
}
