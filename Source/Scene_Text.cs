using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Text : MonoBehaviour
{
    public Text sceneText;

    void Update()
    {
        sceneText.text = "Chapter " + Scene_Control.scenecount + "\n" + "ไตรมาสที่ " + Scene_Control.scenecount;
    }
}
