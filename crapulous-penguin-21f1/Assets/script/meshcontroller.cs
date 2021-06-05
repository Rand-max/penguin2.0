using UnityEngine;
using UnityEngine.UI;

public class meshcontroller : MonoBehaviour {
	public GameObject meshs;
	private MeshFilter[] meshF;
	//private MeshRenderer[] meh;
	void Start ()
	{
		meshF=meshs.GetComponentsInChildren<MeshFilter>();
		for(int i=0;i<meshF.Length;i++){
            int length=meshF[i].mesh.vertices.Length;
			Color32[] mecol= new Color32[length];
			for(int j=0;j<length;j++){
				mecol[j]= new Color32(0,0,0,1);
			}
			meshF[i].mesh.colors32=mecol;
		}
	}
}