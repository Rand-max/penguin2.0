using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Audios" ,menuName ="Audios")]
public class AudioObjects : ScriptableObject
{
    public List<AudioClip> audioList;
}
