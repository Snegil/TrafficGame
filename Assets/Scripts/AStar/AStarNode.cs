using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode : MonoBehaviour
{
    [SerializeField, Header("Horizontal")]
    float x;
    public float X { get { return x; } set {  x = value; } }
    [SerializeField, Header("Vertical")]
    float y;
    public float Y { get { return y; } set { y = value; } }


    [SerializeField]
    List<AStarNode> neighbours;
    public List<AStarNode> Neighbours { get { return neighbours; } }

    [SerializeField]
    float gCost;
    public float GCost { get { return gCost; } set {  gCost = value; } }

    [SerializeField]
    float hCost;
    public float HCost { get { return hCost; } set {  hCost = value; } }
    
    public float FCost { get { return gCost + hCost; } }

    [SerializeField]
    AStarNode parent;
    public AStarNode Parent { get {  return parent; } set { parent = value; } }

    private void OnDrawGizmosSelected()
    {
        if (neighbours[0] != null)
        {
            for (int i = 0; i < neighbours.Count; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, neighbours[i].transform.position);
            }
        }
    }

}
