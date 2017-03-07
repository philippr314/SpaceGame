using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalData : MonoBehaviour {

    public Star physicalObject;

}

[System.Serializable]
public class PhysicalObject
{
    public long mass;
    public long radius;
    public double velocity;
    public long impulse;
}

[System.Serializable]
public class Star : PhysicalObject
{
    public double apparentMagnitude;
    public SpectralClass spectralClass;
}

[System.Serializable]
public class SpectralClass
{
    public static Dictionary<char, List<string>> types = new Dictionary<char, List<string>>();

    //O, B, A, F, G and so on..
    public char identifier;
    public List<string> chemicalElements;

    public SpectralClass(char id)
    {
        SetTypes();
        identifier = id;
        chemicalElements = types[identifier];
    }

    private void SetTypes()
    {
        types.Add('O', new List<string> {"Ionised Helium"});
        types.Add('B', new List<string> { "Neutral Helium", "Balmer Series Hydrogen" });
        //TODO: add rest of the types 
    }

}