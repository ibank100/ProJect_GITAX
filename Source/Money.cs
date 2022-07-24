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
        moneytext.text = (int)(moneyAmount) + " �ҷ";
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            time = 60;
            if (Player.money == 1)
            {
                salary();
                moneyAmount -= 750;
                Player.discount["�Թ������Сѹ�ѧ��"] += 750;
                moneyAmount -= 25000 * proNum / 100;
                Player.discount["�ͧ�ع���ͧ����§�վ"] += 25000 * proNum / 100;
            }
            else
            {
                moneyAmount -= proNum;
                Player.discount["�Թ������Сѹ�ѧ��"] += proNum;
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

    // �������Թ��
    // �Թ���������� 1
    void salary()
    {
        moneyAmount += 25000;
        if (income.ContainsKey("�Թ��͹"))
        {
            income["�Թ��͹"] += 25000;
        }
        else
        {
            income.Add("�Թ��͹", 25000);
        }
    }

    // �Թ���������� 2
    void wages(int num2)
    {
        moneyAmount += num2;
        if (income.ContainsKey("��Ҩ�ҧ�����"))
        {
            income["��Ҩ�ҧ�����"] += num2;
        }
        else
        {
            income.Add("��Ҩ�ҧ�����", num2);
        }
    }

    // �Թ���������� 3
    void royalty()
    {
        moneyAmount += 100;
        if (income.ContainsKey("����Ԣ�Է���"))
        {
            income["����Ԣ�Է���"] += 100;
        }
        else
        {
            income.Add("����Ԣ�Է���", 100);
        }
    }

    // �Թ���������� 4
    void dividend()
    {
        if (income.ContainsKey("�͡����"))
        {
            income["�͡����"] += 500;
        }
        else
        {
            income.Add("�͡����", 500);
        }
    }

    // �Թ���������� 5
    void rent()
    {
        moneyAmount += 2000;
        if (income.ContainsKey("������"))
        {
            income["������"] += 2000;
        }
        else
        {
            income.Add("������", 2000);
        }
    }

    // �Թ���������� 6
    void professional()
    {
        moneyAmount += 600;
        if (income.ContainsKey("����ԪҪվ�����"))
        {
            income["����ԪҪվ�����"] += 600;
        }
        else
        {
            income.Add("����ԪҪվ�����", 600);
        }
    }

    // �Թ���������� 7
    void contractor()
    {
        moneyAmount += 1500;
        if (income.ContainsKey("����Ѻ����"))
        {
            income["����Ѻ����"] += 1500;
        }
        else
        {
            income.Add("����Ѻ����", 1500);
        }
    }

    // �Թ���������� 8
    void other(int num8)
    {
        moneyAmount += num8;
        if (income.ContainsKey("�Թ������"))
        {
            income["�Թ������"] += num8;
        }
        else
        {
            income.Add("�Թ������", num8);
        }
    }
}
