
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Slider slider;
    private int currentFame = 0; // Current fame value

    void Start()
    {
        // Initialize slider with an empty value
        SetFame(currentFame);
    }

    public void AcceptContract()
    {
        // Increase the fame value by one when the player accepts a contract
        SetFame(++currentFame);
    }

    public void SetFame(int Fame)
    {
        slider.value = Fame;
    }
}
