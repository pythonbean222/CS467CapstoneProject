using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    // set up property to track cubes, triangles, and spheres collected by the player
    public int NumberOfTriangles {get; private set; }
    public int NumberOfCubes { get; private set; }
    public int NumberOfSpheres { get; private set;}


    // function to increment number of triangles collected
    public void CollectTriangle()
    {
        NumberOfTriangles++;
        Debug.Log("Number of triangles collected: " + NumberOfTriangles);
    }
    
    // function to increment number of cubes collected
    public void CollectCube()
    {
        NumberOfCubes++;
        Debug.Log("Number of cubes collected: " + NumberOfCubes);
    }

    // function to increment number of spheres collected
    public void CollectSphere()
    {
        NumberOfSpheres++;
        Debug.Log("Number of spheres collected: " + NumberOfSpheres);
    }  


}
