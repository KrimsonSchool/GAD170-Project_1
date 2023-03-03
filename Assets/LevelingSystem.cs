using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelingSystem : MonoBehaviour
{
    [HideInInspector] public int Level;
    [HideInInspector] public int Xp;
    [HideInInspector] public int XpTo;
    public TMPro.TextMeshProUGUI LevelText;
    // Start is called before the first frame update
    void Start()
    {
        XpTo = 20;
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = "Level = " + Level + ", XP = " + Xp + " / " + XpTo;

        if (Xp >= XpTo)
        {
            XpTo = Mathf.RoundToInt(XpTo * 1.1f);
            Xp -= XpTo;
            Level += 1;
            FindObjectOfType<StatsSystem>().AssignPoints += 4;
            FindObjectOfType<StatsSystem>().Assign();
        }
    }
}
