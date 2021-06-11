using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkill : Skill
{
    private playercontroler Playercontroler;
    public JumpSkill(playercontroler playercontroler) : base(playercontroler)
    {
        this.Playercontroler = playercontroler;
    }
    public override void Tick()
    {
        Playercontroler.Playsound(1);
        var forward = Playercontroler.rb.transform.forward;
        Playercontroler.movement = new Vector3 (forward.x*100, forward.y*100+1470f,forward.z*100);
    }
}
