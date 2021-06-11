using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playercontroler : MonoBehaviour {
	public float speed;
	public float rotationalspeed;
	public float backspeed;
	public int player;
	public Rigidbody rb;
	private float cooldown=0;
	public Color32 colo;
	public int layerMask;
	public GameObject enemytrail;
	//private int[][] triangles;
	//private MeshRenderer[] meh;
	public GameObject exfield;
	public AudioClip[] audioref;
	public GameObject sound;
	public GameObject respawner;
	public int currentskill=0;
	public int skillcount=0;
	public Material dskin;
	public Material dsball;
	public GameObject enemy;
	public int territory=0;
	public TrailRenderer[] thistrails;
	private string axistringx;
	private string axistringy;
	private string function;
	private float taillengthorigin;
	private float speedorigin;
	private float cooldownrespawn=0f;
	public Vector3 movement;
	public SkillController skillController;

	private void Awake()
	{
		skillController = new SkillController(this);
	}

	void Start ()
	{
		taillengthorigin=thistrails[0].time;
		speedorigin=speed;
		rb = GetComponent<Rigidbody> ();
		axistringx="Horizontal"+player;
		axistringy="Vertical"+player;
		function="Function"+player;
	}
	void FixedUpdate (){
		
		if(skillcount<=0){
			currentskill=0;
		}
		if(cooldownrespawn<=0){
		float movex = Input.GetAxis(axistringx);
		float movez = Input.GetAxis(axistringy);
		RaycastHit hit;
		/*if(cooldown==0){
			transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(-rb.velocity.y*30,transform.eulerAngles.y,0f),0.8f*Time.deltaTime);
		}*/
		if(Physics.SphereCast(transform.position, 0.01f, new Vector3(0f,-1f,0f), out hit, 0.6f,layerMask)) {
			if(hit.triangleIndex>=0){
				Vector3 leerp=new Vector3(Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal)).eulerAngles.x,Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal)).eulerAngles.y,0f);
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(leerp),backspeed*4*Time.deltaTime);
				MeshFilter meshh = hit.transform.GetComponent<MeshFilter>();
				//var vert1 = triangles[hit.triangleIndex * 3 + 0];
				//var vert2 = triangles[hit.triangleIndex * 3 + 1];
				//var vert3 = triangles[hit.triangleIndex * 3 + 2];
				Color32[] mecol= meshh.mesh.colors32;
				{Color32 a=mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 0]];
				if(!(a.r==colo.r&&a.g==colo.g&&a.b==colo.b)){
					mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 0]] = colo;
					territory+=1;
					Color32 c=enemy.GetComponent<playercontroler>().colo;
					if(a.r==c.r&&a.g==c.g&&a.b==c.b){
						enemy.GetComponent<playercontroler>().territory-=1;
					}
				}}
				{Color32 a=mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 1]];
				if(!(a.r==colo.r&&a.g==colo.g&&a.b==colo.b)){
					mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 1]] = colo;
					territory+=1;
					Color32 c=enemy.GetComponent<playercontroler>().colo;
					if(a.r==c.r&&a.g==c.g&&a.b==c.b){
						enemy.GetComponent<playercontroler>().territory-=1;
					}
				}}
				{Color32 a=mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 2]];
				if(!(a.r==colo.r&&a.g==colo.g&&a.b==colo.b)){
					mecol[meshh.mesh.triangles[hit.triangleIndex * 3 + 2]] = colo;
					territory+=1;
					Color32 c=enemy.GetComponent<playercontroler>().colo;
					if(a.r==c.r&&a.g==c.g&&a.b==c.b){
						enemy.GetComponent<playercontroler>().territory-=1;
					}
				}}
				meshh.mesh.colors32=mecol;
			}
		}
		else/* if(cooldown>0||rb.velocity.y<0)*/{
			if(transform.rotation.x<0){
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(10f,transform.eulerAngles.y,0f),backspeed*Time.deltaTime);
			}else{
				transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(Mathf.Clamp(-rb.velocity.y*100,-1,1)*30,transform.eulerAngles.y,0f),backspeed*Time.deltaTime);
			}
			//transform.eulerAngles=new Vector3(-rb.velocity.y,transform.eulerAngles.y,0f);
		}
		transform.Rotate(new Vector3(0f,movex*rotationalspeed,0f));
		movement = new Vector3 (rb.transform.forward.x*100, rb.transform.forward.y*100-49f, rb.transform.forward.z*100);
		if (Input.GetAxis(function)>0){
			if (cooldown <= 0)
			{
				skillController.UseSkill();
				cooldown = skillController.coolDown;
			}
			// skillcount--;
			// switch(currentskill){
			// 	case 1:
			// 	Playsound(1);
			// 	cooldown=1f;
			// 	movement = new Vector3 (rb.transform.forward.x*100, rb.transform.forward.y*100+1470f,rb.transform.forward.z*100);
			// 	break;
			// 	case 2:
			// 	Playsound(2,0.3f);
			// 	cooldown=1f;
			// 	movement = new Vector3 (rb.transform.forward.x*2000, rb.transform.forward.y*2000-49f, rb.transform.forward.z*2000);
			// 	break;
			// 	case 3:
			// 	Playsound(3);
			// 	cooldown=1f;
			// 	GameObject exfie = Instantiate(exfield, this.gameObject.transform.position, Quaternion.identity);
			// 	exfie.transform.position=this.transform.position;
			// 	exfie.GetComponent<exfieldcontroller>().initiator=this.gameObject;
			// 	exfie.transform.tag=this.tag;
			// 	exfie.SetActive(true);
			// 	//Instantiate(sparkles, this.gameObject.transform.position, Quaternion.identity);
			// 	break;
			//	}
		}
		rb.AddForce (movement * speed*60*Time.deltaTime);
		}
		if(cooldown>0){
			cooldown-=Time.deltaTime;
		}
		if(cooldownrespawn>0){
			this.transform.position=Vector3.Lerp(this.transform.position,respawner.transform.position,Time.deltaTime*10);
			this.transform.rotation=Quaternion.Lerp(this.transform.rotation,respawner.transform.rotation,Time.deltaTime*10);
			if(cooldownrespawn>2){
				dskin.SetFloat("_SliceAmount",dskin.GetFloat("_SliceAmount")-dskin.GetFloat("_SliceAmount")*Time.deltaTime*3);
				dsball.SetFloat("_SliceAmount",dsball.GetFloat("_SliceAmount")-dsball.GetFloat("_SliceAmount")*Time.deltaTime*3);

			}
			else{
				dskin.SetFloat("_SliceAmount",dskin.GetFloat("_SliceAmount")+(2f-dskin.GetFloat("_SliceAmount"))*Time.deltaTime);
				dsball.SetFloat("_SliceAmount",dsball.GetFloat("_SliceAmount")+(2f-dsball.GetFloat("_SliceAmount"))*Time.deltaTime);
				}
			cooldownrespawn-=Time.deltaTime;
		}
	}
	private void OnTriggerEnter(Collider other)
    {
		if(other.transform.tag==enemytrail.transform.tag)
		{
			Playsound(5,0.2f);
			for(int i=0;i<thistrails.Length;i++){
                thistrails[i].time=taillengthorigin;
            }
			speed=speedorigin;
			cooldownrespawn=3f;
			return;
		}
		
		if (other.GetComponent<SkillObjectController>())
		{
			skillController.ChangeSkill(other.GetComponent<SkillObjectController>().skillObject);
			cooldown = skillController.coolDown;
			Playsound(4);
		}
		// switch(other.gameObject.tag){
		// 	case "apple":
		// 	currentskill=1;
		// 	skillcount=3;
  //           Playsound(0);
		// 	break;
		// 	case "banana":
		// 	currentskill=2;
		// 	skillcount=3;
  //           Playsound(0);
		// 	break;
		// 	case "bomb":
		// 	currentskill=3;
		// 	skillcount=3;
  //           Playsound(0);
		// 	break;
  //       }
    }
	public void Playsound(int index,float offset=0f)
    {
		AudioSource[] sounds= sound.GetComponents<AudioSource>();
		for(int i=0;i<sounds.Length;i++){
			if(sounds[i].clip==audioref[index]){
				sounds[i].time = offset;
				sounds[i].Play();
			}
		}
    }
}
