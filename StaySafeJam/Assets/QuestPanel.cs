using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    public List<string> quests;
    public int currentQuest = 0 ;
    public Text TextUI;
    // Start is called before the first frame update
    void Start()
    {
        quests.Add("Press 2 to drop a hive, make sure it is near flowers");
        quests.Add("You used up your starting honey making that hive so lets make some more");
        quests.Add("Press E on the hive to start honey production");
        quests.Add("Press E again once it is done to collect the honey");
        quests.Add("Use this menu to buy them with 1 2 or 3");
        quests.Add("Use m to go to the main menu");
        TextUI.text = quests[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            currentQuest++;
            nextQuest();
        }
        if (Input.GetKeyDown("k"))
        {
            currentQuest--;
            nextQuest();
        }

    }

    // Update is called once per frame
    void nextQuest()
    {
        
        if (quests.Count > currentQuest)
        {
            TextUI.text = quests[currentQuest];
        }
    }
}
