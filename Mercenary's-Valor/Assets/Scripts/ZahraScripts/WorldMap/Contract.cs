using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    public GameObject[] cityChildren;

    void Start()
    {
        // Activate a random child game object
        int randomIndex = Random.Range(0, cityChildren.Length);
        cityChildren[randomIndex].SetActive(true);
    }

}

