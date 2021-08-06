using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour {
    private int x;
    private int y;

    private int score;
    public int Score{

        get { return score;}
    }

    private ItemType type;

    private Grid grid;

    private MovableItem movableItemComponent;

    public MovableItem MovableItemComponent{

        get { return movableItemComponent;}
    }
    private ColoredItem coloredItemComponent;

    public ColoredItem ColoredItemComponent{

        get { return coloredItemComponent;}
    }

    private MatchableItem matchableItemComponent;

    public MatchableItem MatchableItemComponent{

        get { return matchableItemComponent;}
    }

    public Grid GetGrid
    {
        get {return grid;}
    }

    public int X
    {
        get { return x;}
        set {
            if(IsMovable()){
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y;}
        set {
            if(IsMovable()){
                y = value;
            }
        }
    }


    public ItemType Type
    {
        get {return type;}
    }

    void Awake()
    {
        movableItemComponent = GetComponent<MovableItem>();
        coloredItemComponent = GetComponent<ColoredItem>();
        matchableItemComponent = GetComponent<MatchableItem>();
    }

    public void Init(int _x, int _y, Grid _grid, ItemType _type){
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    void OnMouseEnter()
    {
        grid.EnterItem(this);
    }
    void OnMouseDown()
    {
        grid.PressItem(this);
    }

    void OnMouseUp()
    {
        grid.ReleaseItem();
    }

    public bool IsMovable()
    {
        return movableItemComponent != null;
    }

    public bool IsColored(){
        return coloredItemComponent != null;
    }

    public bool IsMatchable(){
        return matchableItemComponent != null;
    }
}