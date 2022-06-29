using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Invoke("LoadLevelGame", 93.0f);
    }

    void LoadLevelGame()
    {
        Application.LoadLevel("Tutorial-Upd 1");
    }
}
