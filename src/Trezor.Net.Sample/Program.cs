﻿using Hid.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trezor.Manager;
using static Trezor.Manager.TrezorManager;

namespace TrezorTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Go();
                while (true) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static async Task<IHidDevice> Connect()
        {
            var devices = WindowsHidDevice.GetConnectedDeviceInformations();
            var trezors = devices.Where(d => d.VendorId == TrezorManager.TrezorVendorId && TrezorManager.TrezorProductId == 1);

            DeviceInformation trezorDeviceInformation;

            trezorDeviceInformation = trezors.FirstOrDefault(t => t.Product == USBOneName);

            if (trezorDeviceInformation == null)
            {
                throw new Exception("No Trezor is not connected or USB access was not granted to this application.");
            }

            var retVal = new WindowsHidDevice(trezorDeviceInformation);

            await retVal.InitializeAsync();

            return retVal;
        }

        static List<string> addresses = new List<string>();

        private async static Task Go()
        {
            using (var trezorHid = await Connect())
            {
                using (var trezorManager = new TrezorManager(GetPin, trezorHid))
                {
                    await trezorManager.InitializeAsync();

                    var tasks = new List<Task>();

                    for (var i = 0; i < 50; i++)
                    {
                        tasks.Add(DoGetAddress(trezorManager, i));

                    }

                    await Task.WhenAll(tasks);

                    foreach(var asdasd in addresses)
                    {
                        Console.WriteLine(asdasd);
                    }

                    Console.ReadLine();
                }
            }
        }

        private async static Task DoGetAddress(TrezorManager trezorManager, int i)
        {
            addresses.Insert(i, await trezorManager.GetAddressAsync("CRW", 72, false, (uint)i, false, AddressType.Bitcoin));
        }

        public async static Task<string> GetPin()
        {
            Console.WriteLine("Enter PIN based on Trezor values: ");
            return Console.ReadLine().Trim();
        }
    }
}
