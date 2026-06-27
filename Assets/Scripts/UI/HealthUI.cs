using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] hearts;//Array that stores the heart images

    public Sprite fullHeart;//Red full heart sprite

    public Sprite emptyHeart;//Grey empty heart sprite

    public void UpdateHearts(int currentHealth)//Updates the heart images
    {
        for (int i = 0; i < hearts.Length; i++)//Loops through all hearts
        {
            if (i < currentHealth)//Checks if this heart should be full
            {
                hearts[i].sprite = fullHeart;//Sets heart to full
            }
            else
            {
                hearts[i].sprite = emptyHeart;//Sets heart to empty
            }
        }
    }
}
