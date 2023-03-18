using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{

    [SerializeField] List<ObjectColour> colours = new List<ObjectColour>();
    void Start()
    {
        SetColour();
    }

    public List<ObjectColour> Colours
    {
        get { return colours; }
        set { colours.AddRange(value); }
    }

    private void SetColour()
    {
        foreach (ObjectColour colour in colours)
        {
            SpriteRenderer spriteRenderer = gameObject.transform.Find(colour.objectName).GetComponent<SpriteRenderer>();
            spriteRenderer.color = colour.color;
        }
    }

}
