using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    private int remainCount;
    private playercontroler Playercontroler;

    public Skill(playercontroler playercontroler)
    {
        this.Playercontroler = playercontroler;
    }
    public abstract void Tick();
}
