using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class medal : MonoBehaviour
{
    public Sprite metalmedal, bronzemedal, silvermedal, goldmedal;
    Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <=1)
        {
            img.sprite = metalmedal;
        }
        else if (gameScore > 1 && gameScore <= 2)
        {
            img.sprite= bronzemedal;
        }
        else if (gameScore > 2 && gameScore <= 3)
        {
            img.sprite = silvermedal;
        }
        else if (gameScore > 3)
        {
            img.sprite = goldmedal;
        }
    }

}
