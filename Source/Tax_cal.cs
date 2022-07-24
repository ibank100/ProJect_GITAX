using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tax_cal : MonoBehaviour
{
    public Text icon_text;
    public Text tax_text;
    public Text discount_text;
    public Text expenses_text;

    private float final_tax = 0; // ������
    private float money_2 = 0; // �Թ�����ͧ��������
    private float money = 0; // �����������
    private float money_1; // �Թ���������� 1
    private float money_dis = 0; // ������Ŵ���͹
    private float income = 0; // ����Թ��
    private float income2 = 0; // ���Ŵ���͹������ͧ�ع���ͧ����§�վ, RMF, SSF, ������, ���ºӹҭ
    private float give = 0;
    private float give2 = 0;
    private float tax = 0;
    private float calTax = 0;

    // Start is called before the first frame update
    void Start()
    {
        cal();
        money_2 = income - money;
        dis();

        money_dis += income2;

        final_tax = money_2 - money_dis;

        if (final_tax <= 0)
        {
            final_tax = 0;
        }

        tax = final_tax * 10 / 100;

        if (give * 2 >= tax && final_tax > 0)
        {
            final_tax -= tax;
            money_dis += tax;
        }
        else
        {
            final_tax -= give * 2;
            money_dis += give * 2;

            tax -= give * 2;
            if (give2 >= tax && final_tax > 0)
            {
                final_tax -= tax;
                money_dis += tax;
            }
            else
            {
                final_tax -= give2;
                money_dis += give2;
            }
        }

        taxCal(final_tax);

        icon_text.text = income.ToString() + " �ҷ";
        expenses_text.text = money.ToString() + " �ҷ";
        discount_text.text = money_dis.ToString() + " �ҷ";
        tax_text.text = calTax.ToString() + " �ҷ";

        Debug.Log(final_tax);
        Debug.Log(calTax);
    }

    void cal()
    {
        int money01 = 0;
        foreach (var item in Money.income)
        {
            income += item.Value;
            if (item.Key == "�Թ��͹" || item.Key == "��Ҩ�ҧ�����")
            {
                money01 += item.Value;
                if (item.Key == "�Թ��͹")
                {
                    money_1 += item.Value;
                }
            }
            else
            {
                money += exp(item.Key, item.Value);
            }
        }

        if (money01 * 50 / 100 >= 100000)
        {
            money += 100000;
        }
        else
        {
            money += money01 * 50 / 100;
        }
    }

    float exp(string name, int num)
    {
        float test = 0;
        if (name == "����Ԣ�Է���")
        {
            if (num * 50 / 100 >= 100000)
            {
                test += 100000;
            }
            else
            {
                test += num * 50 / 100;
            }
        }
        else if (name == "������")
        {
            test = num * 30 / 100;
        }
        else if (name == "����ԪҪվ�����")
        {
            test = num * 30 / 100;
        }
        else if (name == "����Ѻ����")
        {
            test = num * 60 / 100;
        }
        else if (name == "�Թ������")
        {
            if (num <= 300000)
            {
                test = num * 60 / 100;
            }
            else if (num > 300000)
            {
                test = (num * 40 / 100) + 180000;
            }

            if (test > 600000)
            {
                test = 600000;
            }
            
        }
        return test;
    }

    void dis()
    {
        foreach (var item2 in Player.discount)
        {
            if (item2.Key == "�ؤ��")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "�������")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "�ص�")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "����§�پ�����")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "���ԡ��")
            {
                money_dis += item2.Value * 60000;
            }
            else if (item2.Key == "���»�Сѹ���Ե")
            {
                if (item2.Value <= 100000) { money_dis += item2.Value; }
                else { money_dis += 100000; }
            }
            else if (item2.Key == "���»�Сѹ�آ�Ҿ������")
            {
                if (item2.Value <= 15000) { money_dis += item2.Value; }
                else { money_dis += 15000; }
            }
            else if (item2.Key == "�͡���¡�����")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "�Թ������Сѹ�ѧ��")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "���»�Сѹ�آ�Ҿ����ͧ")
            {
                money_dis += item2.Value;
            }
            else if (item2.Key == "�Թ��ԨҤ�����")
            {
                give += item2.Value;
            }
            else if (item2.Key == "�Թ��ԨҤ")
            {
                give2 += item2.Value;
            }
            dis2(item2.Key, item2.Value);
        }
    }

    void dis2(string name2, int num2)
    {
        if (name2 == "�ͧ�ع���ͧ����§�վ")
        {
            income2 += num2;
        }
        else if (name2 == "RMF")
        {
            if (num2 >= money_2 * 30 / 100)
            {
                income2 += money_2 * 30 / 100;
            }
            else
            {
                income2 += num2;
            }
        }
        else if (name2 == "���»�Сѹ���Ե�ӹҭ")
        {
            if (money_2 * 15 / 100 < 200000)
            {
                if (num2 >= money_2 * 15 / 100)
                {
                    income2 += money_2 * 30 / 100;
                }
                else
                {
                    income2 += num2;
                }
            }
            else
            {
                income2 += 200000;
            }
        }
        else if (name2 == "�Թ�����ͧ�ع��������觪ҵ�")
        {
            if (num2 >= 13200)
            {
                income2 += 13200;
            }
            else
            {
                income2 += num2;
            }
        }
        else if (name2 == "SSF")
        {
            if (money_2 * 30 / 100 < 200000)
            {
                if (num2 >= money_2 * 30 / 100)
                {
                    income2 += money_2 * 30 / 100;
                }
                else
                {
                    income2 += num2;
                }
            }
            else
            {
                income2 += 200000;
            }
        }

        if (income2 >= 500000)
        {
            income2 = 500000;
        }
    }

    void taxCal(float num)
    {
        if (num <= 150000)
        {
            calTax = 0;
        }
        else if(num > 150000 && num <= 300000)
        {
            calTax += (num - 150000) * 5 / 100;
        }
        else if (num > 300000 && num <= 500000)
        {
            calTax += 7500;
            calTax += (num - 300000) * 10 / 100;
        }
        else if (num > 500000 && num <= 750000)
        {
            calTax += 27500;
            calTax += (num - 500000) * 15 / 100;
        }
        else if (num > 750000 && num <= 1000000)
        {
            calTax += 65000;
            calTax += (num - 750000) * 20 / 100;
        }
        else if (num > 1000000 && num <= 2000000)
        {
            calTax += 115000;
            calTax += (num - 1000000) * 25 / 100;
        }
        else if (num > 2000000 && num <= 5000000)
        {
            calTax += 365000;
            calTax += (num - 2000000) * 30 / 100;
        }
        else if (num > 5000000)
        {
            calTax += 1265000;
            calTax += (num - 5000000) * 35 / 100;
        }
    }
}
