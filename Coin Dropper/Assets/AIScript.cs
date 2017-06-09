using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

    private List<Vector2> current_ball = new List<Vector2>();   //List of all curently moving ball
    private List<Vector2> running_ball = new List<Vector2>();   //Ball added to be run in the future
    private int[,] map = new int[14, 9];
    private int sum;

    /// <summary>
    /// 0 1 2 3 4 5 6 7 8 9 0 1 2 3   
    /// 
    /// x x x 1 0 0 1 1 0 0 1 x x x         0
    /// x x x 0 1 1 0 0 1 1 0 x x x         1
    /// x x 1 0 0 1 1 0 0 1 1 0 x x         2
    /// x x 0 1 1 0 0 1 1 0 0 1 x x         3
    /// x 1 0 0 1 1 0 0 1 1 0 0 1 x         4
    /// x 0 1 1 0 0 1 1 0 0 1 1 0 x         5
    /// 1 0 0 1 0 1 1 0 0 1 1 0 0 1         6
    /// 0 1 1 0 1 0 0 1 1 0 0 1 1 0         7
    /// score                               8
    /// </summary>

    // 0 = nothing
    // 1 = spoon
    // 2 = ball

    private int[,] pos = new int[14, 8];

	// Use this for initialization
	void Start () {
		
	}

    void Populatemap()
    {
        //get this from the switches
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Calculate(int drop)
    {
        sum = 0;
        current_ball.Add(new Vector2(drop + 3, 0));
        while(current_ball.Count!= 0)
        {
            current_ball = GetRunning(current_ball);
        }
    }

    private List<Vector2> GetRunning(List<Vector2> cur)
    {
        List<Vector2> running = new List<Vector2>();
        for(int i = 0; i < cur.Count; i++)
        {
            int ax = (int)cur[i].x;
            int ay = (int)cur[i].y;
            int j = map[ax, ay];
            if (ay == 8)
                sum += j;
            else if (j == 0)
                running.Add(new Vector2(ax, ay + 1));
            else if (j == 1)
            {
                if (ay == 0 || ay == 2 || ay == 4 || ay == 6)
                {
                    map[ax, ay] = 2;
                }
                else 
                {
                    //Change the orrientation of the map and add ball

                    running.Add(new Vector2(ax, ay + 1));
                }
            }
            else if (j == 2)
            {
                //Adding the ball to the according place
                if (pos[ax, ay] == 0)
                {
                    running.Add(new Vector2(ax + 1, ay + 1));
                }
                else
                {
                    running.Add(new Vector2(ax -1, ay + 1));
                }

                
            }
        }
        return running;
    }

    private Vector2 PlayBall(Vector2 b)
    {
        
    }

    /// <summary>
    /// There are 3 component that a swtich will send to the map
    /// s.x and s.y are coordinate of the top left of the switch
    /// s.w is orientation of the switch
    /// with this 3 component, we can populate the map and the pos
    /// </summary>
    /// <param name="s"></param>
    public void GetSwitch(Vector3 s)
    {

    }
}
