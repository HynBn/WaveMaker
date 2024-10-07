using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    //Prefabs
    public GameObject generalButton;

    public GameObject deleteButton;

    public Sprite goblinSprite;

    public Sprite wolfSprite;

    public Sprite slimeSprite;

    public Sprite flyingSprite;

    public Sprite emptySprite;

    public MobData goblinData, wolfData, slimeData, flyingData;

    //Objects
    GameObject startButton;

    GameObject sendButton;

    GameObject backButton;

    GameObject canvas;

    Dictionary<GameObject, int> hash;

    GameObject[] adders;

    List<GameObject> images;

    GameObject[] slots;

    string[] mobs;

    [SerializeField]
    private MobSpawner mobSpawner;

    int currentSlotIndex = 0;

    public int sumCosts = 0;


    // Start is called before the first frame update
    void Start()
    {
        hash = new Dictionary<GameObject, int>();
        images = new List<GameObject>();

        startButton = GameObject.Find("/UI Manager/Canvas/LowerButtonContainer/New_Wave_Button");
        sendButton = GameObject.Find("/UI Manager/Canvas/LowerButtonContainer/Send_Wave_Button");
        backButton = GameObject.Find("/UI Manager/Canvas/LowerButtonContainer/Back_Button");

        canvas = GameObject.Find("/UI Manager/Canvas");

        adders = GameObject.FindGameObjectsWithTag("Adder_Button");

        slots = GameObject.FindGameObjectsWithTag("UI_SLot");

        mobs = new string[slots.Length];
        for(int i = 0; i < slots.Length; i++)
        {
            mobs[i] = "";
        }

        //deactivating menu buttons
        showMenu(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void addMobToList(string mob)
    {
        if (GameData.gold <= 0 || sumCosts >= GameData.gold) return;

        if (currentSlotIndex < slots.Length)
        {
            mobs[currentSlotIndex] = mob;
        }
        

        switch (mob)
        {
            case "goblin":
                if (currentSlotIndex < slots.Length && GameData.gold >= goblinData.UnitCost)
                {
                    sumCosts += goblinData.UnitCost;
                    slots[currentSlotIndex].gameObject.GetComponent<Image>().sprite = goblinSprite;
                    currentSlotIndex++;
                }
                break;
            case "wolf":
                if (currentSlotIndex < slots.Length && GameData.gold >= wolfData.UnitCost)
                {
                    sumCosts += wolfData.UnitCost;
                    slots[currentSlotIndex].gameObject.GetComponent<Image>().sprite = wolfSprite;
                    currentSlotIndex++;
                }
                break;
            case "slime":
                if (currentSlotIndex < slots.Length && GameData.gold >= slimeData.UnitCost)
                {
                    sumCosts += slimeData.UnitCost;
                    slots[currentSlotIndex].gameObject.GetComponent<Image>().sprite = slimeSprite;
                    currentSlotIndex++;
                }
                break;

            case "flying":
                if (currentSlotIndex < slots.Length && GameData.gold >= flyingData.UnitCost)
                {
                    sumCosts += flyingData.UnitCost;
                    slots[currentSlotIndex].gameObject.GetComponent<Image>().sprite = flyingSprite;
                    currentSlotIndex++;
                }
                break;
            default:
                Debug.Log(GameData.gold);
                break;
        }
    }

    public void delete()
    {
        if(currentSlotIndex > 0)
        {
            if (currentSlotIndex != 0)
            {
                currentSlotIndex--;
                sumCosts = 0;
            }
            mobs[currentSlotIndex] = "";
            slots[currentSlotIndex].gameObject.GetComponent<Image>().sprite = emptySprite;  
        }

    }


    public void openMenu()
    {
        startButton.SetActive(false);

        Time.timeScale = 0;

        showMenu(true);
    }


    public void sendWave()
    {
        showMenu(false);
        mobSpawner.LoadMobs(mobs);

        GameData.gold -= sumCosts;
        sumCosts = 0;

        Time.timeScale = 1;

        currentSlotIndex = 0;
        for (int i = 0; i < mobs.Length; i++)
        {
            mobs[i] = "";
            slots[i].gameObject.GetComponent<Image>().sprite = emptySprite;
        }
    }

    public void goBack()
    {
        showMenu(false);
        Time.timeScale = 1;

    }


    private void showMenu(bool shown)
    {
        if(shown)
        {
            startButton.SetActive(false);

            deleteButton.SetActive(true);
            sendButton.SetActive(true);
            backButton.SetActive(true);

            arraySetActive(adders, true);

            arraySetActive(slots, true);

        }
        else
        {
            startButton.SetActive(true);

            deleteButton.SetActive(false);
            sendButton.SetActive(false);
            backButton.SetActive(false);

            arraySetActive(adders, false);

            arraySetActive(slots, false);


        }
    }

    private void arraySetActive(GameObject[] objects, bool active)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(active);
        }
    }
}
