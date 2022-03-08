using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//how is the customer feeling about wait/order
public enum NPCFeel
{
    NEUTRAL, UNHAPPY, HAPPY, UPSET
}

public class NPCOrder : MonoBehaviour
{
    [SerializeField]comboID mealWantID;
    NPCFeel npcFeel;
    //used for timer
    [SerializeField] GameObject POPUP;
    [SerializeField] Sprite wrongOrderSprite;
    [SerializeField] Sprite correctOrderSprite;
    [SerializeField] EventObject giveBoost;

    private bool hasGivenOrder = false;
    private bool givenWrongOrder = false;
    private bool waitedtoLong = false;

    private float _timer = 0;

    public bool WaitedLong { get { return waitedtoLong; } }

    [SerializeField][Range(1, 500)] private int _potentialScore = 100;

    //Random Range (x = min, y = max)
    [SerializeField] private Vector2 _randomWaitTime;
    private float _waitTime = 0.0f;
    [SerializeField] private float wrongOrderTimeMultiplier = 1.2f;

    private void Start()
    {
        npcFeel = NPCFeel.NEUTRAL;
        _waitTime = Random.Range(_randomWaitTime.x, _randomWaitTime.y);

        _timer = _waitTime;

        //random range corresponding to enum variables
        int pick = Random.Range(1, 5);
        mealWantID = (comboID)pick;
    }

    public bool GaveOrder()
    {
        return hasGivenOrder;
    }

    public comboID GiveOrder()
    {
        hasGivenOrder = true;
        return mealWantID;
    }

    public bool ReceiveOrder(GameObject player, MealItem item)
    {

        if(item.ID != mealWantID)
        {
            givenWrongOrder = true;

            if (npcFeel == NPCFeel.NEUTRAL)
                npcFeel = NPCFeel.UNHAPPY;

            GameObject popGO = Instantiate(POPUP);
            popGO.GetComponent<PopUp>().InitPopUp(wrongOrderSprite, transform);

            return false;
        }
        else
        {
            if (player.CompareTag("PlayerOne"))
            {
                CheckFeelConditions(1);
            }

            if (player.CompareTag("PlayerTwo"))
            {
                CheckFeelConditions(2);
            }
        }

        return true;
    }


    private void CheckFeelConditions(int playerNum)
    {
        switch (npcFeel)
        {
            case NPCFeel.NEUTRAL:
                npcFeel = NPCFeel.HAPPY;

                //give full points if happy
                if(playerNum == 1)
                {
                    GameManager.Instance.PlayerOnePoints = _potentialScore;
                }
                else
                {
                    GameManager.Instance.PlayerTwoPoints = _potentialScore;
                }

                //Spawn Boost
                giveBoost.TriggerEvent();


                //Create popup
                GameObject popGO = Instantiate(POPUP);
                popGO.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

        
    
                return;

            case NPCFeel.UNHAPPY:
                //give half points
                if (playerNum == 1)
                {
                    GameManager.Instance.PlayerOnePoints = _potentialScore / 2;
                }
                else
                {
                    GameManager.Instance.PlayerTwoPoints = _potentialScore / 2;
                }

                //Create popup
                GameObject popGO2 = Instantiate(POPUP);
                popGO2.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                //destroy after one sec
              
                return;

            case NPCFeel.UPSET:
                //give half points
                if (playerNum == 1)
                {
                    GameManager.Instance.PlayerOnePoints = _potentialScore / 2;
                }
                else
                {
                    GameManager.Instance.PlayerTwoPoints = _potentialScore / 2;
                }

                //Create popup
                GameObject popGO3 = Instantiate(POPUP);
                popGO3.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

          
                return;
            case NPCFeel.HAPPY:
                //Not really needed but I will add just in case
                npcFeel = NPCFeel.HAPPY;

                //give full points if happy
                if (playerNum == 1)
                {
                    GameManager.Instance.PlayerOnePoints = _potentialScore;
                }
                else
                {
                    GameManager.Instance.PlayerTwoPoints = _potentialScore;
                }

                //Spawn Boost
                giveBoost.TriggerEvent();


                //Create popup
                GameObject popGO4 = Instantiate(POPUP);
                popGO4.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                return;
        }
    }

    public void Update()
    {
        if (givenWrongOrder)
        {
            //Speed Timer is wrong order has been given
            _timer -= Time.deltaTime * wrongOrderTimeMultiplier;
        }
        else
        {
            _timer -= Time.deltaTime;
        }

        if(_timer <= _waitTime / 2)
        {
            //This customer should be upset now
            npcFeel = NPCFeel.UPSET;
        }

        if(_timer <= 0 && !waitedtoLong)
        {
            //Lose Points for both players
            GameManager.Instance.PlayerOnePoints = -200;
            GameManager.Instance.PlayerTwoPoints = -200;

            //waited to long
            waitedtoLong = true;
        }
    }
}
