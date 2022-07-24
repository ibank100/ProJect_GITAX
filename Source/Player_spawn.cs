using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_spawn : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public static int character_select = 0;
    public Vector2 charPosition = new Vector2(0, -4);

    // Start is called before the first frame update
    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectCharacter", character_select);
        Instantiate(playerPrefabs[characterIndex], charPosition, Quaternion.identity);

    }
}
