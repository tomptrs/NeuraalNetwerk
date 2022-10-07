using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMaterial : MonoBehaviour
{
    // Start is called before the first frame update

    public Material goodMaterial;
    public Material badMaterial;
    public Material selectedMaterial;
    void Start()
    {
        selectedMaterial = goodMaterial;
        
    }

    public void ChangeMaterial(bool IsWrong)
    {
        if (IsWrong)
        {
            selectedMaterial = badMaterial;
        }
        else
        {
            selectedMaterial = goodMaterial;
        }
        this.gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
