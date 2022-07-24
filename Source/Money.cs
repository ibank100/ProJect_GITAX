using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Dictionary<string, int> income;
    public Text moneytext;
    public static bool startgame;
    public static float moneyAmount;
    private float time = 60;
    public static bool questActive = false;
    public static int proNum = 0;

    void Start()
    {
        if (startgame)
        {
            income = new Dictionary<string, int>();
            moneyAmount = 5000;
            startgame = false;
        }
    }

    void Update()
    {
        moneytext.text = (int)(moneyAmount) + " บาท";
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            time = 60;
            if (Player.money == 1)
            {
                salary();
                moneyAmount -= 750;
                Player.discount["เงินสมทบประกันสังคม"] += 750;
                moneyAmount -= 25000 * proNum / 100;
                Player.discount["กองทุนสำรองเลี้ยงชีพ"] += 25000 * proNum / 100;
            }
            else
            {
                moneyAmount -= proNum;
                Player.discount["เงินสมทบประกันสังคม"] += proNum;
            }
        }
        if (questActive)
        {
            if (Player.money == 1 || Player.money == 2)
            {
                wages(Quest.rewardQuest);
                questActive = false;
            }
            else if (Player.money == 8)
            {
                other(Quest.rewardQuest);
                questActive = false;
            }
        }
    }

    // ประเภทเงินได้
    // เงินได้ประเภทที่ 1
    void salary()
    {
        moneyAmount += 25000;
        if (income.ContainsKey("เงินเดือน"))
        {
            income["เงินเดือน"] += 25000;
        }
        else
        {
            income.Add("เงินเดือน", 25000);
        }
    }

    // เงินได้ประเภทที่ 2
    void wages(int num2)
    {
        moneyAmount += num2;
        if (income.ContainsKey("ค่าจ้างทั่วไป"))
        {
            income["ค่าจ้างทั่วไป"] += num2;
        }
        else
        {
            income.Add("ค่าจ้างทั่วไป", num2);
        }
    }

    // เงินได้ประเภทที่ 3
    void royalty()
    {
        moneyAmount += 100;
        if (income.ContainsKey("ค่าลิขสิทธิ์"))
        {
            income["ค่าลิขสิทธิ์"] += 100;
        }
        else
        {
            income.Add("ค่าลิขสิทธิ์", 100);
        }
    }

    // เงินได้ประเภทที่ 4
    void dividend()
    {
        if (income.ContainsKey("ดอกเบี้ย"))
        {
            income["ดอกเบี้ย"] += 500;
        }
        else
        {
            income.Add("ดอกเบี้ย", 500);
        }
    }

    // เงินได้ประเภทที่ 5
    void rent()
    {
        moneyAmount += 2000;
        if (income.ContainsKey("ค่าเช่า"))
        {
            income["ค่าเช่า"] += 2000;
        }
        else
        {
            income.Add("ค่าเช่า", 2000);
        }
    }

    // เงินได้ประเภทที่ 6
    void professional()
    {
        moneyAmount += 600;
        if (income.ContainsKey("ค่าวิชาชีพอิสระ"))
        {
            income["ค่าวิชาชีพอิสระ"] += 600;
        }
        else
        {
            income.Add("ค่าวิชาชีพอิสระ", 600);
        }
    }

    // เงินได้ประเภทที่ 7
    void contractor()
    {
        moneyAmount += 1500;
        if (income.ContainsKey("ค่ารับเหมา"))
        {
            income["ค่ารับเหมา"] += 1500;
        }
        else
        {
            income.Add("ค่ารับเหมา", 1500);
        }
    }

    // เงินได้ประเภทที่ 8
    void other(int num8)
    {
        moneyAmount += num8;
        if (income.ContainsKey("เงินได้อื่นๆ"))
        {
            income["เงินได้อื่นๆ"] += num8;
        }
        else
        {
            income.Add("เงินได้อื่นๆ", num8);
        }
    }
}
