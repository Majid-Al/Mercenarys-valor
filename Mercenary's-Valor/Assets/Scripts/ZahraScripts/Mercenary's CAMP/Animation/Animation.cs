using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
   
    // Update is called once per frame
     private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    public void OnResetButtonClick()
    {
        // Trigger the animation by setting a trigger parameter
        animator.SetTrigger("ResetTrigger"); // Replace "ResetTrigger" with your animation trigger name
    }
}
