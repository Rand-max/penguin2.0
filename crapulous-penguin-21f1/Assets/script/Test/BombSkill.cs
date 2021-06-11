using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : Skill
{
    private GameObject exfield;
    private GameObject player;
    private playercontroler Playercontroler;
    public BombSkill(playercontroler playercontroler) : base(playercontroler)
    {
        this.Playercontroler = playercontroler;
        exfield = playercontroler.exfield;
        player = playercontroler.gameObject;
    }
    public override void Tick()
    {
        Playercontroler.Playsound(3);
        var exfie = GameObject.Instantiate(exfield, player.transform.position, Quaternion.identity);
        exfie.transform.position=player.transform.position;
        exfie.GetComponent<exfieldcontroller>().initiator=player;
        exfie.transform.tag=player.tag;
        exfie.SetActive(true);
        //Instantiate(sparkles, this.gameObject.transform.position, Quaternion.identity);
    }
}
