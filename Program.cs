using System;
using System.IO;
using System.Reflection;

using SearchAThing.Ext;
using static SearchAThing.Ext.Toolkit;

using SearchAThing.Util;
using static SearchAThing.Util.Toolkit;

namespace clone_disk
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"{Assembly.GetExecutingAssembly().GetName().Name} <sd-card> [step]");
                Console.WriteLine($"   sd-card   device (eg. /dev/sdb)");
                Console.WriteLine($"   step      step between byte check ( default=64m ) ; bytes ; valid suffixes m");
                System.Environment.Exit(1);
            }

            var device = args[0];

            var deviceSize = GetDeviceSize(device);
            var step = 64L * 1024 * 1024;
            if (args.Length == 2)
            {
                if (args[1].EndsWith("m"))
                    step = long.Parse(args[1].Substring(0, args[1].Length - 1)) * 1024 * 1024;
                else
                    step = long.Parse(args[1]);
            }

            Console.WriteLine($"step = {step.HumanReadable()}");
            Console.WriteLine($"disk = {device} size = {deviceSize.HumanReadable()}");

            var fs = File.Open(device, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Seek(0, SeekOrigin.Begin);

            var off = 0L;
            var rnd = new Random();

            var ary = new byte[1];
            var aryback = new byte[1];

            while (off < deviceSize)
            {
                Console.WriteLine($"checking offset {off} [{((long)off).HumanReadable()}]");
                try
                {
                    ary[0] = (byte)rnd.Next(255);

                    fs.Seek(off, SeekOrigin.Begin);
                    fs.Write(ary, 0, 1);

                    fs.Seek(off, SeekOrigin.Begin);
                    fs.Read(aryback, 0, 1);

                    if (aryback[0] != ary[0])
                    {
                        Console.WriteLine($"  * fake detected at offset {off} [{off.HumanReadable()}]");
                        break;
                    }

                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                        Mono.Unix.Native.Syscall.sync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  * error access detected at offset {off} [{off.HumanReadable()}]");
                }

                off += step;
            }

            Console.WriteLine($"FINISHED");
        }

        static long GetDeviceSize(string device)
        {
            long res = 0L;
            long blocks = 0L;

            var devName = Path.GetFileName(device);

            var deviceSizeInfo = $"/sys/class/block/{devName}/size";
            Console.Write($"retrieving device size [{deviceSizeInfo}] = ");
            using (var sr = new StreamReader(deviceSizeInfo))
            {
                var line = sr.ReadLine();
                blocks = long.Parse(line);
            }
            res = blocks * 512;
            Console.WriteLine($"{blocks} ( x 512 bytes blocks ) = {res} bytes = {res.HumanReadable()}");

            return res;
        }
    }
}
