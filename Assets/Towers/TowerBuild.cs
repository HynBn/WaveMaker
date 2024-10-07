using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    private Animator animator;


    [SerializeField]
    private SpriteRenderer towerSprite;
    [SerializeField]
    private SpriteRenderer archerSprite;


    // Start is called before the first frame update
    void Start()
    {
        towerSprite.enabled = false;
        if (archerSprite != null)
        {
            archerSprite.enabled = false;
        }
        animator = GetComponent<Animator>();
        animator.Play("TowerBuild");
    }

    public void enbableSprites()
    {
        towerSprite.enabled = true;
        if(archerSprite != null )
        {
            archerSprite.enabled = true;
        }

        Destroy(gameObject);
    }
}
