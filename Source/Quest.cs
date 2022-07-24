using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{

    private float activeTime;
    private bool activeQuest = false;
    public static int rewardQuest;
    public int[] reward;
    public int[] time;

    public Text questTime_text;
    public string[] isquestactive_text;

    // Update is called once per frame
    void Update()
    {
        if (activeQuest)
        {
            activeTime = activeTime - Time.deltaTime;
            questTime_text.text = activeTime.ToString();

            if (activeTime <= 0)
            {
                activeQuest = false;
                Money.questActive = true;
            }
        }
        else
        {
            questTime_text.text = isquestactive_text[Player_spawn.character_select];
        }
    }

    public void active()
    {
        if (!activeQuest)
        {
            activeTime = time[Player_spawn.character_select];
            activeQuest = true;
            rewardQuest = reward[Player_spawn.character_select];
        }
    }
}
