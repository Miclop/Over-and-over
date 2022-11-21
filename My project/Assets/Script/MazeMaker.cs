using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeMaker : MonoBehaviour
{

    private int Numof4Way, Numof3Way, Numof2WayS, Numof2WayT, NumofDead;

    private int NumofNode;

    private Maze[] TheMaze;
    // initialize 
    void Start()
    {
        Numof4Way = 4;
        Numof2WayS = 4;
        Numof2WayT = 4;
        Numof3Way = 6;
        NumofDead = 4;

        NumofNode = Numof4Way + Numof3Way + Numof2WayS + Numof2WayT + NumofDead + 1;

        TheMaze = new Maze[NumofNode];
    }
    
    public void MakeConnections(int LeftNode)
    {
        if (LeftNode == 0) { return; }

        //make connections

        TheMaze[0]=new Maze("Start");
        TheMaze[0].connections[0] = TheMaze[1];
        TheMaze[0].connections[1] = TheMaze[2];
        TheMaze[0].connections[2] = TheMaze[3];

        //recursive call
        MakeConnections(LeftNode - 1);

    }




    
    // Update is called once per frame
    void Update()
    {
        
    }
}
