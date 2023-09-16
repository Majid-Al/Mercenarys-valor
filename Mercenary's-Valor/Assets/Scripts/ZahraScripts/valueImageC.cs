using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class valueImageC : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI contractText;
    public int stone;
    public int gold;
    public int food;
    public int wood ;
    
   
    
   private void Start()
{
    UpdateText();
}

private void UpdateText()
{
        // Calculate the increase (30% more)
float increasePercentage = 0.30f; // 30% as a decimal
int increaseAmount = Mathf.RoundToInt(gold * increasePercentage);

// Add the increase to the original gold value
gold += increaseAmount;
    woodText.text = wood.ToString();
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

