using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum GameState
{
    Menu,
    Idle,
    Selected,
    Animating
}

public enum LevelType
{
    TIMER,
    MOVES
}
public enum ItemType
{
    Empty,
    Matchable,
    Matched
}

public enum ColorType
{
    Red,
    Blue,
    Green,
    Yellow

}
public enum SoundClip 
{
    Start,
    Finish,
    Match,
    Highscore,
    GameFinished,
    Move
};