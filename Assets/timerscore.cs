using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscore : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        GetComponent<Text>().text = ""+Mathf.Round(gm.totalTime); 
    }

    // Update is called once per frame

}
