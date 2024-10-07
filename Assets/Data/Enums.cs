using System;

#region Enums

public enum Difficulty
{
    TUTORIAL, EASY, MEDIUM, HARD
}

//public enum MobType
//{
//    NONE, FODDER, TANK, SPEEDSTER, FLYING, MAGE, BOSS
//}
#endregion

#region Flags

[Flags]
public enum FlagTemplate
{
    NONE = 0, ONE = 1, TWO = 2, FOUR = 4, EIGHT = 8
}

#endregion