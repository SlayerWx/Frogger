using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum AnimationState
{
    idle,front,right,back,left
}
public class AnimatorController : MonoBehaviour
{
    public Animator myAnim;
    private void OnEnable()
    {
        PlayerMove.OnMove += Play;
    }
    private void OnDisable()
    {

        PlayerMove.OnMove -= Play;
    }
    public void Play(AnimationState state)
    {
        if(state != AnimationState.idle)
        {
            myAnim.SetFloat("blendidle",(int)state);
        }
        myAnim.SetInteger("direction",(int)state);
    }
}
