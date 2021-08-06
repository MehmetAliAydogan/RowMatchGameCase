using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableItem : MonoBehaviour
{

    private Item item;
    private IEnumerator moveCoroutine;

    void Awake()
    {
        item = GetComponent<Item> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int newX, int newY,float time)
    {
       if(moveCoroutine != null){
           StopCoroutine(moveCoroutine);
       }

       moveCoroutine = MoveCoroutine(newX, newY, time);
       StartCoroutine(moveCoroutine);
    }

    private IEnumerator MoveCoroutine(int newX, int newY,float time){
        
        item.X = newX;
        item.Y = newY;

        Vector2 startPos = transform.position;
        Vector2 endPos = item.GetGrid.GetWorldPos(newX, newY);

        for(float t = 0; t<= 1 * time; t += Time.deltaTime){
            item.transform.position = Vector2.Lerp(startPos, endPos, t / time);
            yield return 0;
        }

        item.transform.position = endPos;
    }
}
