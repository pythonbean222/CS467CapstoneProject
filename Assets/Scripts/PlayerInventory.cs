using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

    // set up property to track cubes, triangles, and spheres collected by the player
    public int NumberOfTriangles {get; private set; }
    public int NumberOfCubes { get; private set; }
    public int NumberOfSpheres { get; private set;}

    public UnityEvent<PlayerInventory> OnInventoryChanged;


    // function to increment number of triangles collected
    public void CollectTriangle()
    {
        NumberOfTriangles++;
        Debug.Log("Number of triangles collected: " + NumberOfTriangles);
        OnInventoryChanged.Invoke(this);
    }
    
    // function to increment number of cubes collected
    public void CollectCube()
    {
        NumberOfCubes++;
        Debug.Log("Number of cubes collected: " + NumberOfCubes);
        OnInventoryChanged.Invoke(this);
    }

    // function to increment number of spheres collected
    public void CollectSphere()
    {
        NumberOfSpheres++;
        Debug.Log("Number of spheres collected: " + NumberOfSpheres);
        OnInventoryChanged.Invoke(this);
    }  


}
