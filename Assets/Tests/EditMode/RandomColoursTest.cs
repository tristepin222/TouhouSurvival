using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RandomColoursTest
{
    RandomColour randomColour;

    [Test]
    public void SetRandomColoursReturnsCorrectColours()
    {
        randomColour = new RandomColour();
        List<ObjectColour> colours = new List<ObjectColour>();
        colours.Add(new ObjectColour { color = new Color(1, 1, 1), objectName = "test" });
        randomColour.Colours = colours;

        Assert.AreEqual(colours, randomColour.Colours);
    }
}
