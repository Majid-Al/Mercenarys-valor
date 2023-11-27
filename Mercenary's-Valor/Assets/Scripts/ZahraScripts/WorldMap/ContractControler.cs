using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContractControler : MonoBehaviour
{

    [Header("Image(Day/Night)")]
    public GameObject Dayimage;
    public GameObject Nightimage;

    [Header("Texts")]
    public TextMeshProUGUI imageText; // Reference to the Text UI element (For rest/Failur to receive contract)

    [SerializeField] private string whichscene;//For Scene
    [SerializeField] private int Contractnumbers = 0;//To count contract




    public void LoadScene()
    {
        SceneManager.LoadScene(whichscene);
    }

    public void acceptedContract()
    {
        Contractnumbers++;
        if (Contractnumbers >= 1)
        {
            LoadScene();
        }

        if (Contractnumbers >= 2)
        {
            LoadScene();
            ChangeBackgroundWorldMap();
        }
        if (Contractnumbers >= 4)
        {
            Activation();
        }
    }

    private void ChangeBackgroundWorldMap()
    {
        Nightimage.SetActive(true);
        Dayimage.SetActive(false);

    }


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
