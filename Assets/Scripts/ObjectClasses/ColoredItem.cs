using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredItem : MonoBehaviour
{

    [System.Serializable]
    public struct ColorSprite
    {
        public ColorType color;
        public Sprite sprite;
    };

    public ColorSprite[] colorSprites;

    private ColorType color;

    public ColorType Color
    {
        get {return color;}
        set{ SetColor(value);}
    }

    private int score;
    public int Score{

        get { return score;}
    }

    public int NumColors{
        get { return colorSprites.Length;}
    }
    private SpriteRenderer sprite;
    private Dictionary<ColorType, Sprite> colorSpriteDict;

    void Awake()
    {
        colorSpriteDict = new Dictionary<ColorType, Sprite>();
        sprite = transform.Find("Item").GetComponent<SpriteRenderer>();

        for (int i = 0; i < colorSprites.Length; i++)
        {
            if(!colorSpriteDict.ContainsKey(colorSprites[i].color)){
                colorSpriteDict.Add(colorSprites[i].color,colorSprites[i].sprite);
            }
        }
    }

    public void SetColor(ColorType newColor){
        color = newColor;

        if(colorSpriteDict.ContainsKey(newColor)){
            sprite.sprite = colorSpriteDict[newColor];
        }

        SetScore();
    }

    public void SetScore(){
        
        ColorType c = color;

        switch(c)
        {
            case ColorType.Red:
            score = 100;
            break;
            case ColorType.Blue:
            score = 200;
            break;
            case ColorType.Yellow:
            score = 250;
            break;
            case ColorType.Green:
            score = 150;
            break;
            default:
            score = 1;
            break;
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
