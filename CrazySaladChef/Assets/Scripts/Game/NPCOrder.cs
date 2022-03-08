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
    comboID mealWantID;
    NPCFeel npcFeel;
    private GameObject _playerGivenOrder = null;
    [SerializeField] GameObject POPUP;
    [SerializeField] Sprite wrongOrderSprite;
    [SerializeField] Sprite correctOrderSprite;
    [SerializeField] EventObject giveBoost;

    private bool hasGivenOrder = false;
    private bool givenWrongOrder = false;

    private float _timer = 0;

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

    public void ReceiveOrder(GameObject player, MealItem item)
    {
        if(item.ID != mealWantID)
        {
            givenWrongOrder = true;

            if (npcFeel == NPCFeel.NEUTRAL)
                npcFeel = NPCFeel.UNHAPPY;

            Instantiate(POPUP);
            POPUP.GetComponent<PopUp>().InitPopUp(wrongOrderSprite, transform);

            return;
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

        
    }

    //Invoked method
    public void TimedDestroy()
    {
        Destroy(gameObject);
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
                Instantiate(POPUP);
                POPUP.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                //destroy after one sec
                Invoke("TimedDestroy", 1f);
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
                Instantiate(POPUP);
                POPUP.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                //destroy after one sec
                Invoke("TimedDestroy", 1f);
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
                Instantiate(POPUP);
                POPUP.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                //destroy after one sec
                Invoke("TimedDestroy", 1f);
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
                Instantiate(POPUP);
                POPUP.GetComponent<PopUp>().InitPopUp(correctOrderSprite, transform);

                //destroy after one sec
                Invoke("TimedDestroy", 1f);
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

        if(_timer <= 0)
        {
            //Lose Points for both players

            //Customer Leaves
            Destroy(gameObject);
        }
    }
}
