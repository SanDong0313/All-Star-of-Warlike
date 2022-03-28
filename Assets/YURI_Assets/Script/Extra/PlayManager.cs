using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour 
{
    public static string now_cat = "A_Choose";
    public static bool move_to_now_cat = false;
    public static int level_number = 1;
    public static bool Top_Camera_Mode = true;
    public static bool menu_show = true;
    public static int cat_gold = 1000;

    public static int[] Cat1 = new int[4];  //   Life,Now_Magazin,Standard_Magazine,Capacity
    public static int[] Cat2 = new int[4];
    public static int[] Cat3 = new int[4];
    public static int[] Cat4 = new int[4];

    public Image[] Life = new Image[4];
    public Text[] Magazine = new Text[4];
    public Text[] Capacity = new Text[4];
    public Text gold;

    public GameObject[] Create_Pos;
    public GameObject Enemy_Soldier;

	void Start () 
    {
        Cat1[0] = 100;
        Cat1[1] = 36;
        Cat1[2] = 36;
        Cat1[3] = 999;

        Cat2[0] = 100;
        Cat2[1] = 7;
        Cat2[2] = 7;
        Cat2[3] = 140;

        Cat3[0] = 100;
        Cat3[1] = 1;
        Cat3[2] = 1;
        Cat3[3] = 8;

        Cat4[0] = 100;
        Cat4[1] = 18;
        Cat4[2] = 18;
        Cat4[3] = 300;
	}
	
	void Update () 
    {
        switch (now_cat)
        {
            case "A_Choose":
                {
                    Life[0].fillAmount = Cat1[0] / 100;
                    Magazine[0].text = Cat1[1].ToString();
                    Capacity[0].text = Cat1[3].ToString();
                    break;
                }
            case "B_Choose":
                {
                    Life[0].fillAmount = Cat2[0] / 100;
                    Magazine[0].text = Cat2[1].ToString();
                    Capacity[0].text = Cat2[3].ToString();
                    break;
                }
            case "AB_Choose":
                {
                    Life[0].fillAmount = Cat3[0] / 100;
                    Magazine[0].text = Cat3[1].ToString();
                    Capacity[0].text = Cat3[3].ToString();
                    break;
                }
            case "O_Choose":
                {
                    Life[0].fillAmount = Cat4[0] / 100;
                    Magazine[0].text = Cat4[1].ToString();
                    Capacity[0].text = Cat4[3].ToString();
                    break;
                }
        }

        gold.text = cat_gold.ToString();

        if (level_number == 1)
        {
            
        }
	}
}
