using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAnimation : MonoBehaviour

{
    public Animator anim; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component from the GameObject
        anim = GetComponent<Animator>();

        // Get the Button component and add a listener for the click event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayAnimation);
        }
    }

    // Function to play the animation
    public void PlayAnimation()
    {
        // Trigger the animation by setting a bool parameter in the Animator Controller
        if (anim != null)
        {
            anim.SetBool("PlayAnimation", true); // "PlayAnimation" is the name of the bool parameter
        }
    }
}
