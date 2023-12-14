using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    public List<Transform> CalculateRoute(AStarNode startNode, AStarNode endNode)
    {
        List<AStarNode> OpenList = new List<AStarNode>();
        List<AStarNode> ClosedList = new List<AStarNode>();
        OpenList.Add(startNode);
        
        while (OpenList[0] != endNode)
        {
            if (OpenList.Count == 0)
            {
                Debug.LogWarning("NO PATH FOUND");
                return null;
            }
            AStarNode currentNode = OpenList[0];
            OpenList.RemoveAt(0);
            ClosedList.Add(currentNode);
            foreach (AStarNode neighbour in currentNode.Neighbours)
            {
                float calculatedNeighbourGCost = currentNode.GCost + CalculateManhattanDistance(currentNode, neighbour);
                if (OpenList.Contains(neighbour) && calculatedNeighbourGCost < neighbour.GCost)
                {
                    OpenList.Remove(neighbour);
                }
                if (ClosedList.Contains(neighbour) && calculatedNeighbourGCost < neighbour.GCost)
                {
                    ClosedList.Remove(neighbour);
                    Debug.Log("EMERGENCY, THIS SHOULDN'T HAVE HAPPENED. I DON'T KNOW WHERE!");
                }
                if (!OpenList.Contains(neighbour) && !ClosedList.Contains(neighbour))
                {
                    neighbour.GCost = calculatedNeighbourGCost;
                    OpenList.Add(neighbour);
                    float calculatedNeighbourHCost = CalculateManhattanDistance(currentNode, endNode);
                    OpenList = OpenList.OrderBy(o => o.FCost).ToList();
                    neighbour.Parent = currentNode;
                }
            }
        }
        List<Transform> path = new List<Transform>();
        AStarNode curr = endNode;
        
        while (curr.Parent != null) 
        {
            path.Insert(0, curr.transform);
            curr = curr.Parent;
        }
        path.Insert(0, startNode.transform);
        //DebugVisualisePath(path);
        //Reconstruct path from parents

        foreach (AStarNode node in OpenList) 
        {
            node.HCost = 0;
            node.GCost = 0;
            node.Parent = null;
        }
        foreach (AStarNode node in ClosedList) 
        { 
            node.HCost = 0; 
            node.GCost = 0; 
            node.Parent = null;
        }

        return path;
    }

    float CalculateManhattanDistance(AStarNode start, AStarNode end)
    {
        return Mathf.Abs(start.X - end.X) + Mathf.Abs(start.Y - end.Y);
    }

    void DebugVisualisePath(List<Transform> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            lineRenderer.positionCount = path.Count;
            lineRenderer.SetPosition(i, path[i].position);
        }        
    }
}
