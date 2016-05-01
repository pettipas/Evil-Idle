using UnityEngine;
using System.Collections;
using System;

public class ClickHeroData : HeroData {
    #region implemented abstract members of HeroData

    public override int Cost
    {
        get
        {
            double l = (double)heroLevel;
            int val = (int)Math.Round(Math.Pow(1.07,l));
            return (5+heroLevel) * val;
        }
    }

  
    public override int GetDPS
    {
        get
        {
            return 0;
        }
    }

    public override int GetDPC
    {
        get
        {
            return 1+heroLevel;
        }
    }
    #endregion

}
