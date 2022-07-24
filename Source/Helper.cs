using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [SerializeField] GameObject startHelp;
    public static bool helpStart;
    public Sprite[] helpImage;
    public Image helpPage;
    public int num = 0;

    void Start()
    {
        if (helpStart)
        {
            startHelp.SetActive(true);
            helpStart = false;
            Time.timeScale = 0;
        }
    }

    public void close()
    {
        startHelp.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        helpPage.sprite = helpImage[num];
    }

    public void nextPage()
    {
        if (num < 2)
        {
            num++;
        }
        else
        {
            num = 2;
        }
    }

    public void previousPage()
    {
        if(num > 0)
        {
            num--;
        }
        else
        {
            num = 0;
        }
    }
}
