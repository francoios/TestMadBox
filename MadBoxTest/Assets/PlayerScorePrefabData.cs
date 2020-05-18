using System.Collections;
using System.Collections.Generic;
using MadBoxTest;
using UnityEngine;

public class PlayerScorePrefabData : MadBoxMonobehaviour
{
    public UILabel position;
    public UILabel userName;
    public UILabel userScore;

    public void SetScore(int nb)
    {
        userScore.text = nb + "";
        userScore.UpdateNGUIText();
    }

    public void SetUserName(string name)
    {
        userName.text = name;
        userName.UpdateNGUIText();
    }

    public void SetPosition(int nb)
    {
        position.text = nb + "";
        position.UpdateNGUIText();
    }
}
