using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    private GameObject currentEnemy;

    private TurnState currentState;

    private enum TurnState
    {
        PlayerTurn,
        WaitingForShotResult,
        EnemyTurn
    }


    void OnEnable()
    {
        Actions.OnPlayerShotResolved += HandlePlayerShotResolved;
    }

    void OnDisable()
    {
        Actions.OnPlayerShotResolved -= HandlePlayerShotResolved;
    }

    private void Awake()
    {
        this.currentState = TurnState.PlayerTurn;
        enemySpawner.SpawnEnemy();
        currentEnemy = GameObject.FindWithTag("Enemy");
        currentEnemy.GetComponent<EnemyController>().enabled = false;

    }


    private void Update()
    {
        if (currentEnemy == null)
        {
            enemySpawner.SpawnEnemy();
            currentEnemy = GameObject.FindWithTag("Enemy");
        }
    }

    public void OnPlayerShotStarted()
    {
        if (currentState == TurnState.PlayerTurn)
        {
            this.currentState = TurnState.WaitingForShotResult;
        }
    }

    public void HandlePlayerShotResolved(bool hit)
    {
        if (currentState == TurnState.WaitingForShotResult && !hit)
        {
            this.currentState = TurnState.EnemyTurn;
            if (currentEnemy != null)
            {
                currentEnemy.GetComponent<EnemyController>().enabled = true;
            } 
        }
        else if (currentState == TurnState.WaitingForShotResult && hit)
        {
            this.currentState = TurnState.PlayerTurn;
        }
    }

    public bool IsPlayerTurn()
    {
        if (this.currentState == TurnState.PlayerTurn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }    
}

