using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static int money;
    public static Dictionary<string, int> discount;
    public static bool start;
    private string dis_name;
    private int val_Num = 0;

    private static bool life_act;
    private static bool self_act;
    private static bool parent_act;
    private static bool persion_act;
    private static bool provident_act;
    private static bool RMF_act;
    private static bool SSF_act;
    private static bool Social_act;

    // Start is called before the first frame update
    void Start()
    {
        if (start)
        {
            discount = new Dictionary<string, int>();
            discount.Add("��ǹ���", 60000);
            discount.Add("����§�پ�����", 60000);
            discount.Add("���»�Сѹ���Ե", 0);
            discount.Add("���»�Сѹ�آ�Ҿ����ͧ", 0);
            discount.Add("���»�Сѹ�آ�Ҿ������", 0);
            discount.Add("���»�Сѹ���Ե�ӹҭ", 0);
            discount.Add("�ͧ�ع���ͧ����§�վ", 0);
            discount.Add("�Թ������Сѹ�ѧ��", 0);
            discount.Add("RMF", 0);
            discount.Add("SSF", 0);
            discount.Add("�Թ��ԨҤ�����", 0);
            discount.Add("�Թ��ԨҤ", 0);
            Debug.Log("���Ŵ���͹: ���ҧ�����");
            start = false;
            life_act = true;
            self_act = true;
            parent_act = true;
            persion_act = true;
            provident_act = true;
            RMF_act = true;
            SSF_act = true;
            Social_act = true;
}
    }
    public void startgame()
    {
        start = true;
        Money.startgame = true;
        Scene_Control.scenecount = 1;
        Helper.helpStart = true;
    }

    public void income(int income01)
    {
        money = income01;
        Debug.Log(money);
    }

    // for Insurance

    public void ins(int val1)
    {
        if (val1 == 0)
        {
            dis_name = "���»�Сѹ���Ե";
        }
        else if (val1 == 1)
        {
            dis_name = "���»�Сѹ�آ�Ҿ����ͧ";
        }
        else if (val1 == 2)
        {
            dis_name = "���»�Сѹ�آ�Ҿ������";
        }
        else if (val1 == 3)
        {
            dis_name = "���»�Сѹ���Ե�ӹҭ";
        }
        Debug.Log("Complete " + dis_name);
    }

    // for Fund

    public void fund(int val2)
    {
        if (val2 == 0)
        {
            dis_name = "RMF";
        }
        else if (val2 == 1)
        {
            dis_name = "SSF";
        }
        Debug.Log("Complete " + dis_name);
    }

    // for Provident value only

    public void fund2(int val3)
    {
        dis_name = "�ͧ�ع���ͧ����§�վ";
        if (provident_act)
        {
            if (val3 == 0)
            {
                Money.proNum = 3;
                provident_act = false;
            }
            else if (val3 == 1)
            {
                Money.proNum = 5;
                provident_act = false;
            }
            else if (val3 == 2)
            {
                Money.proNum = 10;
                provident_act = false;
            }
            else if (val3 == 3)
            {
                Money.proNum = 15;
                provident_act = false;
            }
            Debug.Log("Complete " + dis_name + " : " + discount[dis_name]);
        }
        
    }

    // for Social value only

    public void fund3(int val3)
    {
        dis_name = "�Թ������Сѹ�ѧ��";
        if (Social_act)
        {
            if (val3 == 0)
            {
                discount[dis_name] = 70;
                Money.proNum = 70;
                Social_act = false;
            }
            else if (val3 == 1)
            {
                discount[dis_name] = 100;
                Money.proNum = 100;
                Social_act = false;
            }
            else if (val3 == 2)
            {
                discount[dis_name] = 300;
                Money.proNum = 300;
                Social_act = false;
            }
            Debug.Log("Complete " + dis_name + " : " + discount[dis_name]);
        }

    }

    // for Discount value 

    public void valNum(int num)
    {
        val_Num = num;
    }

    public void val()
    {
        if (isActive(dis_name))
        {
            foreach (var item in discount)
            {
                if (dis_name == item.Key)
                {
                    if (val_Num == 2 && Money.moneyAmount >= 20000)
                    {
                        discount[dis_name] = 20000;
                        Money.moneyAmount -= 20000;
                    }
                    else if (val_Num == 1 && Money.moneyAmount >= 10000)
                    {
                        discount[dis_name] = 10000;
                        Money.moneyAmount -= 10000;
                    }
                    else if (val_Num == 0)
                    {
                        discount[dis_name] = 0;
                    }
                    break;
                }
            }
            Debug.Log("Complete " + dis_name + " : " + discount[dis_name]);
        }
    }

    public void fund_val(InputField numField)
    {
        if (isActive(dis_name))
        {
            foreach (var item in discount)
            {
                if (dis_name == item.Key && Money.moneyAmount >= int.Parse(numField.text))
                {
                    discount[dis_name] += int.Parse(numField.text);
                    Money.moneyAmount -= int.Parse(numField.text);
                    break;
                }
            }
            Debug.Log("Complete " + dis_name + " : " + discount[dis_name]);
        }
    }

    // for Given and value

    public void give(int num1)
    {
        if (num1 == 0)
        {
            dis_name = "�Թ��ԨҤ�����";
        }
        else if (num1 == 1)
        {
            dis_name = "�Թ��ԨҤ";
        }
        Debug.Log("Complete " + dis_name);
    }

    public void give2_val(InputField numField)
    {
        foreach (var item in discount)
        {
            if (dis_name == item.Key && Money.moneyAmount >= int.Parse(numField.text))
            {
                discount[dis_name] += int.Parse(numField.text);
                Money.moneyAmount -= int.Parse(numField.text);
                break;
            }
        }
        Debug.Log("Complete " + dis_name + " : " + discount[dis_name]);
    }

    // check active discount and change active discount

    public void changeActive()
    {
        if (dis_name == "���»�Сѹ���Ե")
        {
            life_act = false;
        }
        else if (dis_name == "���»�Сѹ�آ�Ҿ����ͧ")
        {
            self_act = false;
        }
        else if (dis_name == "���»�Сѹ�آ�Ҿ������")
        {
            parent_act = false;
        }
        else if (dis_name == "���»�Сѹ���Ե�ӹҭ")
        {
            persion_act = false;
        }
        else if (dis_name == "RMF")
        {
            RMF_act = false;
        }
        else if (dis_name == "SSF")
        {
            SSF_act = false;
        }
        else if (dis_name == "�ͧ�ع���ͧ����§�վ")
        {
            provident_act = false;
        }
        else if (dis_name == "�Թ������Сѹ�ѧ��")
        {
            Social_act = false;
        }
    }

    public bool isActive(string name)
    {
        if (name == "RMF")
        {
            return RMF_act;
        }
        else if (name == "SSF")
        {
            return SSF_act;
        }
        else if (name == "���»�Сѹ���Ե")
        {
            return life_act;
        }
        else if (name == "���»�Сѹ�آ�Ҿ����ͧ")
        {
            return self_act;
        }
        else if (name == "���»�Сѹ�آ�Ҿ������")
        {
            return parent_act;
        }
        else if (name == "���»�Сѹ���Ե�ӹҭ")
        {
            return persion_act;
        }
        else
        {
            return false;
        }
    }

    public void setChar(int num)
    {
        Player_spawn.character_select = num;
    }
}