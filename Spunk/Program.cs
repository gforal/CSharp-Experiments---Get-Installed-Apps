using System;
using Microsoft.Win32;

public class Program {
    static void Main(string[] args)
    {
        string[] Keys = { "Microsoft\\Windows\\CurrentVersion\\Uninstall", "WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall" };

        foreach (string Key in Keys) {
            Console.WriteLine(Key);

            RegistryKey RegContext = (Registry.LocalMachine).OpenSubKey("SOFTWARE", false);
            RegistryKey Uninst = RegContext.OpenSubKey(Key, false);
            string[] guids = Uninst.GetSubKeyNames();

            foreach (string guid in guids)
            {
                RegistryKey InstalledApp = Uninst.OpenSubKey(guid, false);

                string DisplayName = InstalledApp.GetValue("DisplayName") as string;

                if (DisplayName != null)
                {

                    Console.WriteLine("Display Name: " + DisplayName);
                    Console.WriteLine("Version: " + InstalledApp.GetValue("DisplayVersion"));
                    Console.WriteLine("Publisher: " + InstalledApp.GetValue("Publisher"));
                    Console.WriteLine("Silent Uninstall: " + InstalledApp.GetValue("UninstallString"));
                    Console.WriteLine("GUID: " + guid);

                    Console.WriteLine("");
                }
                
            }
        }
    }
}
