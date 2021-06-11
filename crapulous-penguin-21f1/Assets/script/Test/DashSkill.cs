using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    private playercontroler Playercontroler;
    public DashSkill(playercontroler playercontroler) : base(playercontroler)
    {
        this.Playercontroler = playercontroler;
    }
    public override void Tick()
    {
        Playercontroler.Playsound(2, 0.3f);
        var forward = Playercontroler.rb.transform.forward;
        Playercontroler.movement = new Vector3 (forward.x*2000, forward.y*2000-49f,forward.z*2000);
    }
}
