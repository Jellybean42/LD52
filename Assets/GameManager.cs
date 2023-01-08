using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public plantscript pickedPlant;
    public Image img;
    float winDelay = 5;
    public float totalTime = 0;
    bool count = true;
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        PickPlant();
        aS= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aS.volume < 1)
        {
            aS.volume += Time.deltaTime;
        }
        if (count)
        {
            totalTime += Time.deltaTime;
        }
        if(pickedPlant == null)
        {
            PickPlant();
        }
    }

    void PickPlant()
    {
        if (FindObjectsOfType<plantscript>().Length == 0)
        {
            winDelay -= Time.deltaTime;
            count = false;
            if(winDelay<=0)
            {
                SceneManager.LoadScene("Win");
            }
            return;
        }
        plantscript[] plants = FindObjectsOfType<plantscript>();
        pickedPlant = plants[Random.Range(0, plants.Length)];
        pickedPlant.pickplant();
        img.sprite = pickedPlant.GetComponent<SpriteRenderer>().sprite;

    }
}
