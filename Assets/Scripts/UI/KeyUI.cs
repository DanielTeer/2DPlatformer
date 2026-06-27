using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public Image keyImage;//Image that shows the key UI

    public Sprite noKeySprite;//Sprite shown when player does not have key

    public Sprite hasKeySprite;//Sprite shown when player has key

    void Start()//Runs once
    {
        ShowNoKey();//Starts UI showing player has no key
    }

    public void ShowNoKey()//Shows the no key sprite
    {
        if (keyImage != null)//Checks if key image exists
        {
            keyImage.sprite = noKeySprite;//Sets key image to no key sprite
        }
    }

    public void ShowHasKey()//Shows the has key sprite
    {
        if (keyImage != null)//Checks if key image exists
        {
            keyImage.sprite = hasKeySprite;//Sets key image to has key sprite
        }
    }
}
