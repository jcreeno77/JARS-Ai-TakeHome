using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class Anim_Control_Script : MonoBehaviour
{
    [Header("Core Animation Components")]
    [SerializeField] Animator _animator;
    [SerializeField] AnimatorController _animatorController;
    //[SerializeField] AnimationClip[] _anims;
    [SerializeField] Anim_MetaData[] animMetaData;
    [SerializeField] Add_Anim_Buttons add_Anim_Buttons;

    [Header("Animation Control Transition Variables")]
    [SerializeField] float transitionTime = 1;
    [SerializeField] float normalizedTimeOffset = 1;
    [SerializeField] int startAnim = 0;
    int lastPlayed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddAnimsToController();
    }

    void AddAnimsToController()
    {
        Dictionary<string, int> stateDict = new Dictionary<string, int>();
        foreach (var state in _animatorController.layers[0].stateMachine.states)
        {
            stateDict[state.state.name] = 1;

        }
        //add animation motions to anim controller
        int cnt = 0;
        foreach (Anim_MetaData animData in animMetaData)
        {
            if (!stateDict.ContainsKey(animData.animation.name))
            {
                _animatorController.AddMotion(animData.animation);
            }
            animData.animSelect = cnt;
            //add animation buttons
            add_Anim_Buttons.MakeButton(animData);
            cnt++;
        }
    }

    public void SwitchAnim(int select)
    {
        if(_animator.speed == 0)
        {
            _animator.speed = 1;
            _animator.Play(animMetaData[select].animation.name);
        }
        else
        {
            _animator.CrossFade(animMetaData[select].animation.name, transitionTime, -1, normalizedTimeOffset);
            
        }
        lastPlayed = select;
        
    }

    public void ControlAnim(string func)
    {
        switch (func)
        {
            case "Play":
                _animator.speed = 1;
                _animator.Play(animMetaData[lastPlayed].animation.name);
                break;
            case "Pause":
                _animator.speed = 0;
                break;
            case "Restart":
                _animator.speed = 1;
                _animator.Play(animMetaData[lastPlayed].animation.name, -1, 0);
                break;
        }
    }

}

public enum AnimatorFunc
{
    Play,
    Pause,
    Restart
};