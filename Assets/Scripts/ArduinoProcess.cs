using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoProcess : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);
    private int degreeA;
    private int degreeB;
    private int degreeC;
    private int degreeD;
    private int degreeE;
    private int degreeF;

    // Start is called before the first frame update
    void Start()
    {
        if (!sp.IsOpen)
            sp.Open();
        sp.ReadTimeout = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            string inputStr = sp.ReadLine();
            if (inputStr[0] == 'A')
            {
                degreeA = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'B')
            {
                degreeB = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'C')
            {
                degreeC = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'D')
            {
                degreeD = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'E')
            {
                degreeE = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'F')
            {
                degreeF = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
        }
        catch (System.TimeoutException e)
        {

        }
    }

    public int GetDegree(char angle)
    {
        switch (angle)
        {
            case 'A':
                return degreeA;
            case 'B':
                return degreeB;
            case 'C':
                return degreeC;
            case 'D':
                return degreeD;
            case 'E':
                return degreeE;
            case 'F':
                return degreeF;
        }
        return 0;
    }
}
