using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

 public GameObject[] levels;
 int current_level = 0;
 public GameObject button;
 public bool isActive=false;

 void Update()
    {
        SetActive();
    }

   public void SetActive(){
       if(isActive==true){
        button.SetActive(true);
        }else{
        button.SetActive(false);}

    }
 
 public void Upgradee()
 {
  
     if(current_level < levels.Length - 1)  
     { 
        current_level++;
        SwitchObject(current_level);
     }
     
 }

 void SwitchObject(int lvl) 
 {
 for (int i = 0; i < levels. Length; i++) 
 { 
    if (i==lvl)
    levels[i].SetActive(true); 
    else
    levels[i].SetActive(false);
    
 }
}

}