using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    private int inputLength = 10;
    public string[] input;
    public bool configuringSettings = false;
    public enum Function
    {
        Null,
        AssignKey
    }
    public Function function = Function.Null;
    public int index = -1;
    private string[] temp;
	// Use this for initialization
	void Start () 
    {
        input = new string[inputLength];
        temp = new string[inputLength];
        DefaultSettings();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (function == Function.AssignKey)
        {
            AssignKey(index);
        }
	}
    public void SetTemporaryArray()
    {
        for (int i = 0; i < inputLength; i++)
        {
            temp[i] = input[i];
        }
    }
    private void AssignKey(int index)
    {
        //input[index] = "escape";
        if (Input.GetKeyDown(KeyCode.A))
        {
            input[index] = "a";
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            input[index] = "b";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            input[index] = "c";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            input[index] = "d";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            input[index] = "e";
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            input[index] = "f";
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            input[index] = "g";
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            input[index] = "h";
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            input[index] = "i";
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            input[index] = "j";
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            input[index] = "k";
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            input[index] = "l";
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            input[index] = "m";
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            input[index] = "n";
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            input[index] = "o";
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            input[index] = "p";
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            input[index] = "q";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            input[index] = "r";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            input[index] = "s";
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            input[index] = "t";
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            input[index] = "u";
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            input[index] = "v";
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            input[index] = "w";
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            input[index] = "x";
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            input[index] = "y";
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            input[index] = "z";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            input[index] = "left";
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            input[index] = "up";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            input[index] = "right";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            input[index] = "down";
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            input[index] = "space";
        }*/
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            input[index] = "return";
        }
        configuringSettings = true;
        function = Function.AssignKey;
        for (int i = 0; i < inputLength; i++)
        {
            if ((input[index] == temp[i]))
            {
                configuringSettings = true;
                function = Function.AssignKey;
                break;
            }
            else
            {
                configuringSettings = false;
                function = Function.Null;
            }
        }
    }
    private void DefaultSettings()
    {
        input[0] = "left"; //left movement
        input[1] = "right"; //right movement
        input[2] = "up"; //up movement
        input[3] = "down"; //down movement
        input[4] = "q";
        input[5] = "w";
        input[6] = "e";
        input[7] = "r";
        input[8] = "space"; //interact with objects
        input[9] = "return"; //confirm
    }
}
