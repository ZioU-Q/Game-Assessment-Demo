using UnityEngine;
using UnityEngine.UI;

public class PlayerStartBar:MonoBehaviour
{
    public Image healthImage;
    public Image healImage;

/// <summary>
/// 
/// </summary>
/// <param name="persentage">°Ù·Ö±È£ºCurrent/Max</param>
    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
        
    }

}
