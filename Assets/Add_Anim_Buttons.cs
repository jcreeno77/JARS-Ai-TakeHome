using UnityEngine;
using UnityEngine.UI;

public class Add_Anim_Buttons : MonoBehaviour
{
    [Header("Animation Button Prefab")]
    [SerializeField] GameObject buttonPrefab;
    [Header("Anim Meta Data Scriptable Objs")]
    [SerializeField] Anim_Control_Script animControlScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void MakeButton(Anim_MetaData animData)
    {
        GameObject anim_B = Instantiate(buttonPrefab, transform);
        Animation_MetaData animMeta = anim_B.GetComponent<Animation_MetaData>();
        //set info
        animMeta.animName.text = animData.animation.name;
        animMeta.AnimLen.text = "Animation - " + animData.animation.length.ToString("F2") + "s";
        animMeta.categories = animData.categories;
        animMeta.animSelect = animData.animSelect;
        anim_B.GetComponent<Button>().onClick.AddListener(() =>
        {
            animControlScript.SwitchAnim(animMeta.animSelect);
        });
    }
}
