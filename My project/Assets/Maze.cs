using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    public string type;
    public Maze[] connections;

    public Maze(string Mtype)
    {
        type = Mtype;
        if (type == "start" || type == "3Way")
        {
            connections = new Maze[3];
        }
        else if (type == "Dead")
        {
            connections = new Maze[1];
        }
        else if (type == "2WayT" || type == "2WayS")
        {
            connections = new Maze[2];
        }
        else if (type == "4Way")
        {
            connections = new Maze[4];
        }
        else
        {
            connections = new Maze[4];
        }
    }
    

    
}
