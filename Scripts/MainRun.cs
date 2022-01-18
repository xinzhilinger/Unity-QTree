using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRun : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public int maxLayer;

    private Bounds bound;
    private Tree tree;

    public List<ObjData> objList;
    public void Awake()
    {
        bound = new Bounds(center,size);
        tree = new Tree(maxLayer, bound);
        foreach (var obj in objList)
        {
            tree.Insert(obj);

        }
    }


    public void OnDrawGizmos()
    {
        if (tree == null) return;
        tree.DrawLine(); 
    }

}
