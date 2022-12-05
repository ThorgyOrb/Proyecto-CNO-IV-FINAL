using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBloom : MonoBehaviour
{
    //assign in inspector a 2d material with a bloom shader
    public Material bloomMaterial;
    public Color goodHealthColor;
    public Color mediumHealthColor;
    public Color badHealthColor;
    private Color currentColor;
    public bool hasGoodHealth;
    public bool hasMediumHealth;
    public bool hasBadHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGoodHealth)
        {
            currentColor = goodHealthColor;
        }
        else if (hasMediumHealth)
        {
            currentColor = mediumHealthColor;
        }
        else if (hasBadHealth)
        {
            currentColor = badHealthColor;
        }
        //Change the emission color of the bloom material every second
        bloomMaterial.SetColor("_Color", currentColor * Mathf.Pow(2, 6));
        //bloomMaterial.SetColor("_Color", Color.HSVToRGB(Time.time % 1, 1, 1) * Mathf.Pow(2, 6));
        
    }
}
