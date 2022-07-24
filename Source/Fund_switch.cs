using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fund_switch : MonoBehaviour
{
    [SerializeField] GameObject proFund;
    [SerializeField] GameObject socialFund;

    void Start()
    {
        if (Player.money == 1)
        {
            proFund.SetActive(true);
            socialFund.SetActive(false);
        }
        else if (Player.money == 2 || Player.money == 8)
        {
            proFund.SetActive(false);
            socialFund.SetActive(true);
        }
    }
}
