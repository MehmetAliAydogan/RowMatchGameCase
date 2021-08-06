using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    
    private int grid_width;
    private int grid_height;
    private LevelScriptable levelScriptable;

    [System.Serializable]
    public struct ItemPrefab
    {
        public ItemType type;
        public GameObject prefab;
    };

    [System.Serializable]
    public struct ItemPosition
    {
        public int x;
        public int y;
        public ItemType type;
    };

    public ItemPosition[] initialItems;

    public Level level;

    private bool gameFinished = false;

    public ItemPrefab[] itemPrefabs;
    private Dictionary<ItemType, GameObject> itemPrefabDict;
    public GameObject backGroundPrefab;

    private Item pressedItem;
    private Item enteredItem;

    private Item [,] items;
    void Start()
    {
        itemPrefabDict = new Dictionary<ItemType, GameObject>();

        levelScriptable = Resources.Load<LevelScriptable>(PlayerPrefs.GetString("level_name"));

        grid_width = levelScriptable.grid_width;

        grid_height = levelScriptable.grid_height;

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            if(!itemPrefabDict.ContainsKey(itemPrefabs[i].type)){
                itemPrefabDict.Add(itemPrefabs[i].type, itemPrefabs[i].prefab);
            }
        }

        for (int x = 0; x < grid_width; x++)
        {
            for (int y = 0; y < grid_height; y++)
            {
                GameObject background = (GameObject)Instantiate(backGroundPrefab, GetWorldPos(x,y), Quaternion.identity);
                background.transform.parent = transform;
            }
        }

        items = new Item[grid_width, grid_height];
        for (int y = 0; y < grid_height; y++)
        {
            for (int x = 0; x < grid_width ; x++)
            {
                SpawnNewItem(x,y,ItemType.Matchable,levelScriptable.colors[(grid_width*grid_height - grid_width*(y+1))+x]);
            }
        }

    }

    public Vector2 GetWorldPos(int x, int y)
    {
        return new Vector2(transform.position.x - grid_width/2.0f + x, transform.position.y + grid_height/2.0f - y);
    }

    public Item SpawnNewItem(int x, int y, ItemType itemType, ColorType colorType = ColorType.Red){
        GameObject newItem = (GameObject)Instantiate(itemPrefabDict[itemType], GetWorldPos(x,y), Quaternion.identity);
        newItem.transform.parent = transform;

        items[x,y] = newItem.GetComponent<Item>();
        items[x,y].Init(x, y, this, itemType);

        if(items[x,y].ColoredItemComponent != null){
            items[x,y].ColoredItemComponent.SetColor(colorType);
        }

        return items[x,y];
    }

    public bool IsAdjacent(Item item1, Item item2){
        return (item1.X == item2.X && (int)Mathf.Abs(item1.Y - item2.Y) == 1)
            || (item1.Y == item2.Y && (int)Mathf.Abs(item1.X - item2.X) == 1);
    }

    public void SwapItems(Item item1, Item item2){

        if(gameFinished){
            return;
        }

        if(item1.IsMovable() && item2.IsMovable()){
            items [item1.X, item1.Y] = item2;
            items [item2.X, item2.Y] = item1;
            
            int item1X = item1.X;
            int item1Y = item1.Y;

            item1.MovableItemComponent.Move(item2.X, item2.Y, Constants.AnimationDuration);
            item2.MovableItemComponent.Move(item1X, item1Y, Constants.AnimationDuration);

            if(GetHorizontalMatch(item1, item1.X, item1.Y) != null
                || GetHorizontalMatch(item2, item2.X, item2.Y) != null){
                ClearAllValidMatches();
            }

            level.OnMove();

        }
    }

    public void PressItem(Item item){
        pressedItem = item;
    }

    public void EnterItem(Item item){
        enteredItem = item;
    }

    public void ReleaseItem(){

        if(IsAdjacent(pressedItem, enteredItem)){
            SwapItems(pressedItem, enteredItem);
        }
    }

    //Check for horizontal matches
    public List<Item> GetHorizontalMatch(Item item, int newX, int newY){

        List<Item> horizontalItems = new List<Item>();
        List<Item> matchedItems = new List<Item>();

        for (int i = 0; i < grid_width; i++){
            horizontalItems.Add(items[i,newY]);
        }

        if(IsSameColor(horizontalItems)){

            matchedItems.AddRange(horizontalItems);
        }

        if(item.Y != newY){

            for (int i = 0; i < grid_width; i++){

            horizontalItems.Add(items[i,item.Y]);
            }

            if(IsSameColor(horizontalItems)){
            matchedItems.AddRange(horizontalItems);
            }
        }
        //Debug.Log(matchedItems.Count);
        if(matchedItems.Count != 0){
            return matchedItems;
        }

        return null; 
    }

    public bool IsSameColor(List<Item> items){

        ColorType color = items[0].ColoredItemComponent.Color;
        for (int i = 1; i < items.Count; i++)
        {
            if(items[i].ColoredItemComponent.Color != color){
                return false;
            }
        }

        return true;
    }

    public void ClearAllValidMatches()
    {
        for(int y = 0; y < grid_height; y++ ){
            for (int x = 0; x < grid_width; x++)
            {
                if(items[x,y].IsMatchable()){
                    List<Item> match = GetHorizontalMatch(items[x,y], x, y);
                    
                    if(match!=null){

                        for (int i = 0; i < match.Count; i++)
                        {
                            MatchItem(match[i].X, match[i].Y);
                        }
                    }
                }
            }
        }
    }
    public void MatchItem(int x, int y){

        if(items[x,y].IsMatchable() && !items[x,y].MatchableItemComponent.IsBeingMatched){
            items[x,y].MatchableItemComponent.Match();
            SpawnNewItem(x, y, ItemType.Matched);
        }
    }

    public void GameFinished(){
        gameFinished = true;
    }   
}






