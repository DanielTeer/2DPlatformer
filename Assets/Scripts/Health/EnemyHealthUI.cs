using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Image fillImage;//Image that fills or empties for health

    public void UpdateHealth(int currentHealth, int maxHealth)//Updates enemy health bar
    {
        if (fillImage == null)//Checks if fill image is missing
        {
            return;//Stops code
        }

        fillImage.fillAmount = (float)currentHealth / maxHealth;//Sets health bar amount
    }
}
