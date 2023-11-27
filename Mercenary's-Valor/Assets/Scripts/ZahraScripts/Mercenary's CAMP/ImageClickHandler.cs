using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ImageClickHandler : MonoBehaviour
{


    public TextMeshProUGUI imageText; // Reference to the Text UI element



    public void Activation()
    {
        // show the text when the image is clicked
        imageText.gameObject.SetActive(true);

        StartCoroutine(DisableTextAfterDelay(3f));

    }


   private IEnumerator DisableTextAfterDelay(float delay)
    {
        // Wait for the 3seconds and hide
        yield return new WaitForSeconds(delay);

        // Disable the imageText after the delay
        imageText.gameObject.SetActive(false);
    }
   
}


