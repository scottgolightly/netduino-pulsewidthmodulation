using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace NetduinoPulseWidthModulation
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            AnalogInput pot = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            PWM pwm = new PWM(PWMChannels.PWM_PIN_D5, 1000.0, 0.1, false);
            pot.Offset = 0;
            pot.Scale = 100;

            double potValue = 0.0;


            while (true)
            {
                potValue = pot.Read();
                pwm.DutyCycle = potValue;
                pwm.Start();

                Thread.Sleep(10);
            }
        }

    }
}
