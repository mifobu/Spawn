using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfRounds;
    public int Complexity;
    public bool Automatic;
    public bool Scoped;

    void Start()
    {
        NumberOfRounds = Mathf.Max(NumberOfRounds, 1);
        Complexity = Mathf.Max(Complexity, 1);

        GunRequirements requirements = new GunRequirements();
        requirements.NumberOfRounds = NumberOfRounds;
        requirements.Automatic = Automatic;
        requirements.Complexity = Complexity;

        IGun v = GetGun(requirements);
        Debug.Log(v);
    }

    private static IGun GetGun(GunRequirements requirements)
    {
        GunFactory factory = new GunFactory(requirements);
        return factory.Create();
    }
}