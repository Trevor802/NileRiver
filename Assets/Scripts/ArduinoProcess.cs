using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoProcess : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);

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
                int degreeA = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'B')
            {
                int degreeB = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            if (inputStr[0] == 'C')
            {
                int degreeC = int.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
        }
        catch (System.TimeoutException e)
        {

        }
    }
}
