using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_info : MonoBehaviour
{
    public Text infoName;
    public Text infoProfile;
    public Text infoBonus;
    public Image infoIcon;
    public Sprite[] infoImage;


    // Update is called once per frame
    void Update()
    {
        if (Player.money == 1)
        {
            infoIcon.sprite = infoImage[0];
            infoName.text = "�͹���� �͹�����";
            infoProfile.text = "�͹�������硨���������������ӧҹ�����ҹ �ͷӧҹ�繾�ѡ�ҹ�Թ��͹ �����ѧ����������˹��˭�ͧ����ѷ����ͷ�����";
            infoBonus.text = "�Ҫվ ��ѡ�ҹ�Թ��͹, ���ž�����";
}
        else if (Player.money == 2)
        {
            infoIcon.sprite = infoImage[1];
            infoName.text = "���� �÷Ծ��";
            infoProfile.text = "�����繿���Ź��ѡ�Ѵ��ͷͧ����Ҿ����Ҿ��Ѻ�ͷ������ ���������蹡�ҿ�Ԥ���ѧ����";
            infoBonus.text = "�Ҫվ ����Ź��, ���ž�����";
        }
        else if (Player.money == 8)
        {
            infoIcon.sprite = infoImage[2];
            infoName.text = "��� ���Թ�";
            infoProfile.text = "����繴���˹����������觾���ç ����էҹ���������������͡�ҡ���";
            infoBonus.text = "�Ҫվ ����, ���ž�����";
        }
    }
}
