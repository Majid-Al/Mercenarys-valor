using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Opencontract : MonoBehaviour, IPointerClickHandler


{
  public GameObject panel;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (panel != null)
    {
      panel.SetActive(!panel.activeSelf);
    }
  }
}

// {
//   public GameObject panel; // Reference to your panel GameObject

//   void Start()
//   {
//     // Deactivate the panel when the game starts
//     panel.SetActive(false);
//   }

//   public void ActivatePanel()
//   {
//     // Activate the panel when called
//     panel.SetActive(true);
//   }

//   public void DeactivatePanel()
//   {
//     // Deactivate the panel when called
//     panel.SetActive(false);
//   }
// }

