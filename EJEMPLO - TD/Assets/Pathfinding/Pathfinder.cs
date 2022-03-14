using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    public Vector2Int StartCoordinates { get { return startCoordinates; } }

    [SerializeField] Vector2Int endCoordinates;
    public Vector2Int EndCoordinates { get { return endCoordinates; } }

    [SerializeField] Node starNode;
    [SerializeField] Node endNode;
    [SerializeField] Node currentSearchNode;

    Dictionary<Vector2Int, Node> exploredNodes = new Dictionary<Vector2Int, Node>();
    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            starNode = gridManager.GetNode(startCoordinates);
            endNode = gridManager.GetNode(endCoordinates);
        }
    }

    private void Start()
    {

        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinates);
    }

    public List<Node> GetNewPath(Vector2Int coodinates)
    {
        gridManager.ResetNodes();
        BreadthFirstSeach(coodinates);
        return BuildPath();
    }
    
    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoodinates = currentSearchNode.coordinates + direction;
            Node neighbor = gridManager.GetNode(neighborCoodinates);
            Node current = gridManager.GetNode(currentSearchNode.coordinates);
            if (neighbor == null) { continue; }
            neighbors.Add(neighbor);
            neighbor.isExplored = true;
        }

        foreach (Node neighbor in neighbors)
        {
            if (!exploredNodes.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                exploredNodes.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSeach(Vector2Int coodinates)
    {
        starNode.isWalkable = true;
        endNode.isWalkable = true;

        frontier.Clear();
        exploredNodes.Clear();

        frontier.Enqueue(gridManager.Grid[coodinates]);
        exploredNodes.Add(coodinates, gridManager.Grid[coodinates]);

        while (frontier.Count > 0)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == endCoordinates)
            {
                break;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (gridManager.Grid.ContainsKey(coordinates))
        {
            bool previousState = gridManager.Grid[coordinates].isWalkable;
            gridManager.Grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            gridManager.Grid[coordinates].isWalkable = previousState;

            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }

    public void NotifyEnemies()
    {
        BroadcastMessage("FindPath", false , SendMessageOptions.DontRequireReceiver);
    }
}
