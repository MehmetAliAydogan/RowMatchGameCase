using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    
public static class Constants
{
    public static readonly float AnimationDuration =  0.2f;
    public static readonly float MoveAnimationMinDuration = 0.05f;
    public static readonly float WaitBeforePotentialMatchesCheck = 2f;
    public static readonly float OpacityAnimationFrameDelay = 0.05f;
    public static readonly int MatchRedScore = 100;
    public static readonly int MatchBlueScore = 150;

    public static readonly int MatchGreenScore = 200;

    public static readonly int MatchYellowScore = 250;

    public static readonly int SubsequentMatchScore = 1000;
}