using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyPawn pawn;//Enemy pawn script

    void Start()//Runs once
    {
        pawn = GetComponent<EnemyPawn>();//Gets EnemyPawn
    }

    void Update()//Runs every frame
    {
        pawn.Move();//Tells enemy pawn to move
    }
}