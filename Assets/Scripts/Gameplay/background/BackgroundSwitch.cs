using Unity.VisualScripting;
using UnityEngine;

public class BackgroundSwitch : MonoBehaviour
{

    public SpriteRenderer Hud_bg;

    public Sprite BG1;
    public Sprite BG2;
    public Sprite BG3;
    public Sprite BG4;
    public Sprite BG5;

    public GameManager gameManager;

    public void ChangeBackground()
    {
        switch (gameManager.CurrentLevelId)
        {
            case 1:
                Hud_bg.sprite = BG1;
                break;

            case 3:
                Hud_bg.sprite = BG2;
                break;

            case 6:
                Hud_bg.sprite = BG3;
                break;
            case 9:
                Hud_bg.sprite = BG4;
                break;
            case 12:
                Hud_bg.sprite = BG5;
                break;
        }

    }


}
