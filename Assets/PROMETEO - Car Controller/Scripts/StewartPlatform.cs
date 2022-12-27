using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using Microsoft.Win32;


public class StewartPlatform : MonoBehaviour
{
    float lastCubePositionx = 0;
    float lastCubePositiony = 0;
    float lastCubePositionz = 0;
    float lastCubeRotationx = 0;
    float lastCubeRotationy = 0;
    float lastCubeRotationz = 0;
    float time;

    // public GameObject gameObject;
    Thread serialReadThread = null;
    public string receivedSring;
    string trama = null;
    string port = "COM6";
    SerialPort serialPort = new SerialPort(AutodetectArduinoPort(), 250000);

    public void serialReadLine()
    {

        while (true)
        {
            receivedSring = serialPort.ReadLine().ToString();
            print(receivedSring + " Recibido");

        }
    }

    void Start()
    {
        serialPort.Open(); //Abrimos una nueva conexion de puerto serie
        serialReadThread = new Thread(new ThreadStart(serialReadLine));
        serialReadThread.IsBackground = true;
        serialReadThread.Start();
        serialPort.ReadTimeout = -1;


        lastCubePositionx = transform.position.x;
        lastCubePositiony = transform.position.y;
        lastCubePositionz = transform.position.z;
        lastCubeRotationx = transform.eulerAngles.x;
        lastCubeRotationy = transform.eulerAngles.y;
        lastCubeRotationz = transform.eulerAngles.z;


    }

    public void SendMessageToArduino(string x, string y, string z, string yaw, string pitch, string roll)
    {
        trama = "MV(" + x + "," + z + "," + y + "," + yaw + "," + pitch + "," + roll + ")";
        // trama = "MV15,15,15,90,45,90";
        // trama = "MVready";
        //trama = "MVready";
        if (serialPort.IsOpen)
        {

            serialPort.WriteLine(trama);
            print(trama);




            // serialPort.BaseStream.Flush();
            // receivedSring = serialPort.ReadLine().ToString();



        }

        trama = "";

        //print(AutodetectArduinoPort());

    }



    private void OnDestroy()
    {
        if (serialReadThread != null)
        {
            if (serialReadThread.IsAlive)
            {
                serialReadThread.Abort();
            }
        }


        if (serialPort != null)
        {
            if (serialPort.IsOpen)
            {
                print("Cerrando puerto serial");
                serialPort.Close();
            }
            serialPort = null;
        }

    }


    void FixedUpdate()
    {

        //Mensaje completo:
        //   if (lastCubePositionx != transform.position.x || lastCubePositiony != transform.position.y || lastCubePositionz != transform.position.z ||
        // lastCubeRotationx != transform.rotation.x || lastCubeRotationy != transform.rotation.y || lastCubeRotationz != transform.rotation.z)
        //  {

        lastCubePositionx = 0;
        lastCubePositiony = 0;
        lastCubePositionz = 0;
        // lastCubePositionx = transform.position.x;
        // lastCubePositiony = transform.position.y;
        // lastCubePositionz = transform.position.z;
       // lastCubeRotationx = restringeValores(transform.eulerAngles.x);
       // lastCubeRotationy = restringeValores(transform.eulerAngles.y);
       // lastCubeRotationz = restringeValores(transform.eulerAngles.z);
        lastCubeRotationx = transform.eulerAngles.x;
        lastCubeRotationy = restringeValores(-transform.eulerAngles.y);
        lastCubeRotationz = restringeValores(-transform.eulerAngles.z);


        if (time >= 0.3f)
        {
            SendMessageToArduino(lastCubePositionx.ToString("0"), lastCubePositiony.ToString("0"), lastCubePositionz.ToString("0"),
                         lastCubeRotationx.ToString("0"), lastCubeRotationz.ToString("0"), lastCubeRotationy.ToString("0"));
            time = 0;
        }

        //  }

        time += Time.deltaTime;








    }

    float restringeValores(float valor)

    {
        /**Funcion que reinicia un valor ciclico, por ejemplo si azimut == 6500, lo cambia a 100*/
        if (valor > 180) valor = valor - 360;
        if (valor < 0) valor = 360 + valor;

        return -valor;
    }

    public static string AutodetectArduinoPort()
    {
        List<string> comports = new List<string>();
        RegistryKey rk1 = Registry.LocalMachine;
        RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
        string temp;
        foreach (string s3 in rk2.GetSubKeyNames())
        {
            RegistryKey rk3 = rk2.OpenSubKey(s3);
            foreach (string s in rk3.GetSubKeyNames())
            {
                if (s.Contains("VID") && s.Contains("PID"))
                {
                    RegistryKey rk4 = rk3.OpenSubKey(s);
                    foreach (string s2 in rk4.GetSubKeyNames())
                    {
                        RegistryKey rk5 = rk4.OpenSubKey(s2);
                        if ((temp = (string)rk5.GetValue("FriendlyName")) != null && temp.Contains("CH340"))
                        {
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (rk6 != null && (temp = (string)rk6.GetValue("PortName")) != null)
                            {
                                comports.Add(temp);
                            }
                        }
                    }
                }
            }
        }

        if (comports.Count > 0)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                if (comports.Contains(s))
                    return s;
            }
        }

        return "COM6";
    }


}
