using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelGenerator.instanceLevel.AddPiece();
        LevelGenerator.instanceLevel.RemoveOldestPiece();
    }
}
