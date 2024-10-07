using UnityEngine;
public abstract class Mob : MonoBehaviour, Attackable
{

    #region Serialized Fields

    //private float movementSpeed, effectiveRange, attackSpeed;
    //private int unitCost, damagePoints, healthPoints,goldGivenOnKill;
    //public MobType type;

    [SerializeField]
    protected MobData mobData;

    protected float effectiveRange, movementSpeed, attackSpeed;
 
    protected int healthPoints, resistance, evasionChance;
   
    protected bool isFlying, isMagic, isRanged;

    protected StatRange attackStrength;
    protected int unitCost;
    protected int goldGivenOnKill;

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int UnitCost { get => unitCost; set => unitCost = value; }
    public int GoldGivenOnKill { get => goldGivenOnKill; set => goldGivenOnKill = value; }

    /*protected bool isFighting;
protected Soldier opponentSoldier = null;*/

    /*public void SetIsFighting(bool value)
    {
        isFighting = value;
    }
    public Soldier GetOpponent()
    {
        return opponentSoldier;
    }
    public void SetOpponent(Soldier soldier)
    {
        opponentSoldier = soldier;
    }*/
    #endregion Serialized Fields

    #region Built-Ins / MonoBehaviours

    // TODO: Put Unity built-in event methods here.
    // Such as Awake, Start, Update.
    // But also OnEnable, OnDestroy, OnTrigger and such.

    void Awake()
    {
        // base.SetUp();
    }

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    #endregion Built-Ins / MonoBehaviours

    #region GetSets / Properties

    #endregion GetSets / Properties

    #region Game Mechanics / Methods

    public void Initialize()
    {
        //effectiveRange = mobData.EffectiveRange;
        movementSpeed = Random.Range(mobData.MovementSpeed.min, mobData.MovementSpeed.max);
        //attackSpeed = Random.Range(mobData.AttackSpeed.min, mobData.AttackSpeed.max); //Divide by hundred for more reasonable number
        healthPoints = Random.Range(mobData.HealthPoints.min, mobData.HealthPoints.max);
        unitCost = mobData.UnitCost;
        goldGivenOnKill = mobData.GoldGivenOnKill;
        isFlying = mobData.IsFlying;
        //attackStrength = mobData.AttackStrength;
        resistance = mobData.Resistance;
        evasionChance = mobData.EvasionChance;
    }

    public abstract void Attacked(int damage, bool isMagic, bool isRanged);

    public abstract void TakeDamage(int damage);

    public abstract void UnitDeath();

    protected void UpdateGameData()
    {
        GameData.enemyGold += goldGivenOnKill;
        GameData.life--;
        Debug.Log(GameData.enemyGold);
    }

    /*public void Attack(Soldier target)
    {
        Attackable enemyUnit = target.gameObject.GetComponent<Attackable>();
        enemyUnit.Attacked(Random.Range(attackStrength.min, attackStrength.max), isMagic, isRanged);

    }*/
    /*public abstract void OnUnitCollision(Collider2D collision);

    public abstract void InitiateCombat(Soldier soldier);*/

    #endregion Game Mechanics / Methods
}