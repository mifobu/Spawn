using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunFactory
{
    IGun Create(GunRequirements requirements);
}

public abstract class AbstractGunFactory
{
    public abstract IGun Create();
}

public class GunFactory : AbstractGunFactory
{
    private readonly IGunFactory _factory;
    private readonly GunRequirements _requirements;

    public GunFactory(GunRequirements requirements)
    {
        _factory = requirements.Automatic ? (IGunFactory) new AutoFactory() : new SemiAutoFactory();
        _requirements = requirements;
    }

    public override IGun Create()
    {
        return _factory.Create(_requirements);
    }
}

public class SemiAutoFactory : IGunFactory
{
    public IGun Create(GunRequirements requirements)
    {
        switch (requirements.Complexity)
        {
            case 1:
                if (requirements.NumberOfRounds == 1) return new Flint_Pistol();
                return new Pistol();
            case 2:
                return new Sawed_Off();
            case 3:
                return new Rifle();
            case 4:
                if (requirements.Scoped && requirements.NumberOfRounds > 1) return new Sniper_Rifle();
                return new Cannon();
            default:
                return new Pistol();
        }
    }
}

public class AutoFactory : IGunFactory
{
    public IGun Create(GunRequirements requirements)
    {
        switch (requirements.Complexity)
        {
            case 1:
                if (requirements.NumberOfRounds == 1) return new Machine_Pistol();
                return new Claymore();
            case 2:
                if (requirements.NumberOfRounds == 2) return new Automatic_Shotgun();
                return new Machine_Pistol();
            case 3:
                if (requirements.NumberOfRounds  > 3) return new Assault_Rifle();
                return new Machine_Pistol();
            default:
                return new Machine_Pistol();
        }
    }
}


