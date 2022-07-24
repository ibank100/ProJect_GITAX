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
            infoName.text = "แอนชิลี คอนเมลล์";
            infoProfile.text = "แอนชิลีเป็นเด็กจบใหม่ที่พึ่งเริ่มทำงานได้ไม่นาน เธอทำงานเป็นพนักงานเงินเดือน ที่กำลังใต่เต้าสู่ตำแหน่งใหญ่ของบริษัทที่เธอทำอยู่";
            infoBonus.text = "อาชีพ พนักงานเงินเดือน, ดูแลพ่อแม่";
}
        else if (Player.money == 2)
        {
            infoIcon.sprite = infoImage[1];
            infoName.text = "อุ๋ย อรทิพย์";
            infoProfile.text = "อุ๋ยเป็นฟรีแลนซ์นักตัดมือทองทั้งภาพนิ่งภาพขยับเธอทำได้หมด แม้แต่โมชั่นกราฟฟิคเธอยังทำได้";
            infoBonus.text = "อาชีพ ฟรีแลนซ์, ดูแลพ่อแม่";
        }
        else if (Player.money == 8)
        {
            infoIcon.sprite = infoImage[2];
            infoName.text = "นิ้ง โสภินี";
            infoProfile.text = "นิ้งเป็นดาราหน้าใหม่ดาวรุ่งพุ่งแรง ที่มีงานหลั่งไหลมาให้เลือกมากมาย";
            infoBonus.text = "อาชีพ คารา, ดูแลพ่อแม่";
        }
    }
}
