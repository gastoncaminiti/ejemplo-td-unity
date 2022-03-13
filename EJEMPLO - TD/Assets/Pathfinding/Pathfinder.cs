using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoodinates = currentSearchNode.coordinates + direction;
            Node neighbor = gridManager.GetNode(neighborCoodinates);
            Node current  = gridManager.GetNode(currentSearchNode.coordinates);
            if (neighbor == null) { continue; }
            neighbors.Add(neighbor);
            neighbor.isExplored = true;
            current.isPath = true;
        }
    }
}
