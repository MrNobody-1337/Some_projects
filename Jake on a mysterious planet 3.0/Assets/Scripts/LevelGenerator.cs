using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instanceLevel;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();//blueprints of level pieces
    public Transform levelStartPosition;//starting point of the 1st lvl piece
    public List<LevelPiece> pieces = new List<LevelPiece>();//level pieces in level now

    private void Awake()
    {
        instanceLevel = this;
    }

    private void Start()
    {
        GenerateInitialPieces();
    }

    public void GenerateInitialPieces()
    {
        for(int i=0; i<2; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count);
        LevelPiece pieceAdded = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);//copy of a random lvl prefab
        pieceAdded.transform.SetParent(this.transform, false);
        Vector3 spawnPosition = Vector3.zero;

        if(pieces.Count == 0)
        {
            spawnPosition = levelStartPosition.position;//1st piece
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;//exit point of a last piece -> spawn point for a new one
        }

        pieceAdded.transform.position = spawnPosition;
        pieces.Add(pieceAdded);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }
}
