using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchableItem : MonoBehaviour
{
    public AnimationClip matchAnimation;
    private bool isBeingMatched = false;

    public bool IsBeingMatched {
        get {return isBeingMatched;}
    }

    protected Item item;

    void Awake()
    {
        item = GetComponent<Item>();
    }
    public void Match(){
        item.GetGrid.level.OnItemMatched(item);
        isBeingMatched = true;
        StartCoroutine(MatchCoroutine());
    }
    private IEnumerator MatchCoroutine(){
        Animator animator = GetComponent<Animator>();
        if(animator){
            animator.Play(matchAnimation.name);
            yield return new WaitForSeconds(matchAnimation.length);
            Destroy(gameObject);
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
