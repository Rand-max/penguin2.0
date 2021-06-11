using UnityEngine;
using System.Collections.Generic;
public class AppleGenerator : MonoBehaviour {
	public GameObject[] GeneratableMeshs;
    public Vector2 gentime;
    public float offsetHeight;
    public GameObject[] apples;
    public Vector2 skillGentime;
    public float skillOffsetHeight;
    public GameObject[] skillObjects;
	private List<MeshFilter> meshF=new List<MeshFilter>();
    private List<Vector3> vertexs=new List<Vector3>();
    private float cooldown;
    private float[] skillCooldown;
	//private MeshRenderer[] meh;
	void Start ()
	{
        skillCooldown=new float[skillObjects.Length];
        for(int i=0;i<GeneratableMeshs.Length;i++){
            meshF.AddRange(GeneratableMeshs[i].GetComponentsInChildren<MeshFilter>());
        }
        for(int i=0;i<meshF.Count;i++){
            for(int j=0;j<meshF[i].mesh.vertices.Length;j++){
                vertexs.Add(meshF[i].transform.TransformPoint(meshF[i].mesh.vertices[j]));
            }
        }
        for(int i=0;i<skillObjects.Length;i++){
            skillCooldown[i]=Random.Range(skillGentime[0],skillGentime[1]);
        }
		cooldown=Random.Range(gentime[0],gentime[1]);
	}
    void Update(){
        cooldown-=Time.deltaTime;
        for(int i=0;i<skillObjects.Length;i++){
            if(!skillObjects[i].activeSelf){
                skillCooldown[i]-=Time.deltaTime;
                if(skillCooldown[i]<0){
                    skillCooldown[i]=Random.Range(skillGentime[0],skillGentime[1]);
                    Vector3 posi=vertexs[Random.Range(0,vertexs.Count)];
                    posi.y+=skillOffsetHeight;
                    skillObjects[i].transform.position=posi;
                    skillObjects[i].SetActive(true);
                }
            }
        }
        if(cooldown<=0){
            cooldown=Random.Range(gentime[0],gentime[1]);
            Vector3 posi=vertexs[Random.Range(0,vertexs.Count)];
            posi.y+=offsetHeight;
            Instantiate(apples[Mathf.FloorToInt(Random.Range(0,apples.Length))],posi,default);
        }
    }
}