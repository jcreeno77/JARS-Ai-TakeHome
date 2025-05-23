using UnityEngine;

[CreateAssetMenu(fileName = "Anim_MetaData", menuName = "Scriptable Objects/Anim_MetaData")]
public class Anim_MetaData : ScriptableObject
{
    public AnimationClip animation;
    [SerializeField] public string[] categories;
    public int animSelect;
}
