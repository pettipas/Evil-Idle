using UnityEngine;
using System.Collections;
using System;

public class DPSHeroData : HeroData {
    
    public int initialDPS;


    #region implemented abstract members of HeroData
    public override int Cost
    {
        get
        {
            double l = (double)heroLevel;
            int val = (int)Math.Floor(Math.Pow(costMult,l));
            return initialCost + (heroLevel * val);
        }
    }

    public override int GetDPS {
        get{
            return initialDPS * heroLevel;
        }
    }

    public override int GetDPC
    {
        get
        {
            return 0;
        }
    }
    #endregion
}
