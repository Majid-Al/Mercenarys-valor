using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class valueImageB : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI contractText;
    public float Wood;
    public float stone;
    public float gold;
    public float food;
   
    
   private void Start()
{
    UpdateText();
}

private void UpdateText()
{
    woodText.text = Wood.ToString();
    stoneText.text = stone.ToString();
    goldText.text = gold.ToString();
    foodText.text = food.ToString();
}

private void OnMouseUp()
{
    UpdateText();
}

void Update()
{

}
 
}

