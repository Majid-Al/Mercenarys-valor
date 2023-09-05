using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Opencontract : MonoBehaviour
{
   
    public GameObject contract;

   
void Start()
{
}
 public void Activate()
 {
   contract.SetActive(true); 
 }


 public void Deactivate()
 {
    contract.SetActive(false);
 }
 
}
