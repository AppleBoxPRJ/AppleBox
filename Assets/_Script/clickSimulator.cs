using System;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class clickSimulator : MonoBehaviour
{
    // Importa la funzione dall'API di Windows
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

    // Costanti per gli eventi del mouse
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    //public static void Main(string[] args)
    //{
    //    Console.WriteLine("Il programma simulerà un click del mouse tra 3 secondi...");
    //    Console.WriteLine("Sposta il cursore dove vuoi cliccare.");
    //
    //    // Aspetta 3 secondi per darti il tempo di posizionare il mouse
    //    Thread.Sleep(3000);
    //
    //    // Simula il click
    //    SimulateLeftClick();
    //    
    //    Console.WriteLine("Click simulato!");
    //}

    public static void SimulateLeftClick()
    {
        // Non è necessario specificare la posizione, il click avverrà dove si trova il cursore
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}