# fake-sd-card-tester

fast sd card tester

## installation and execution

- installation
  - install [dotnet](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial) by choosing your distribution version
  - clone repo
  - `cd clone-disk ; dotnet build`
- execution ( from clone-disk directory )
  - `dotnet bin/Debug/netcoreapp2.0/fake-sd-card-tester.dll`
- notes:
  - disk disk must umounted
  - need to have read write permission to device
  - double check source and destination device **the program not ask for a confirmation after started**
  - after test may need to recreate partition table ( fdisk )

## syntax

```
fake-sd-card-tester <sd-card> [step]
   sd-card   device (eg. /dev/sdb)
   step      step between byte check ( default=64m ) ; bytes ; valid suffixes m
```

## example valid card

```
retrieving device size [/sys/class/block/sdb/size] = 30277632 ( x 512 bytes blocks ) = 15502147584 bytes =   14.4 Gb
step =   64.0 Mb
disk = /dev/sdb size =   14.4 Gb
checking offset 0 [0]
checking offset 67108864 [  64.0 Mb]
checking offset 134217728 [ 128.0 Mb]
checking offset 201326592 [ 192.0 Mb]
checking offset 268435456 [ 256.0 Mb]
checking offset 335544320 [ 320.0 Mb]
checking offset 402653184 [ 384.0 Mb]
checking offset 469762048 [ 448.0 Mb]
checking offset 536870912 [ 512.0 Mb]
checking offset 603979776 [ 576.0 Mb]
checking offset 671088640 [ 640.0 Mb]
checking offset 738197504 [ 704.0 Mb]
checking offset 805306368 [ 768.0 Mb]
checking offset 872415232 [ 832.0 Mb]
checking offset 939524096 [ 896.0 Mb]
checking offset 1006632960 [ 960.0 Mb]
checking offset 1073741824 [   1.0 Gb]
checking offset 1140850688 [   1.1 Gb]
checking offset 1207959552 [   1.1 Gb]
checking offset 1275068416 [   1.2 Gb]
checking offset 1342177280 [   1.3 Gb]
checking offset 1409286144 [   1.3 Gb]
...
checking offset 15166603264 [  14.1 Gb]
checking offset 15233712128 [  14.2 Gb]
checking offset 15300820992 [  14.3 Gb]
checking offset 15367929856 [  14.3 Gb]
checking offset 15435038720 [  14.4 Gb]
FINISHED
```

## example fake

```
retrieving device size [/sys/class/block/sdb/size] = 15122432 ( x 512 bytes blocks ) = 7742685184 bytes =    7.2 Gb
step =   64.0 Mb
disk = /dev/sdb size =    7.2 Gb
checking offset 0 [0]
checking offset 67108864 [  64.0 Mb]
Exception thrown: 'System.IO.IOException' in System.Private.CoreLib.dll
  * error access detected at offset 67108864 [  64.0 Mb]
checking offset 134217728 [ 128.0 Mb]
Exception thrown: 'System.IO.IOException' in System.Private.CoreLib.dll
  * error access detected at offset 134217728 [ 128.0 Mb]
checking offset 201326592 [ 192.0 Mb]
(ctrl+c)
```

going deeper with step 1m

```
retrieving device size [/sys/class/block/sdb/size] = 15122432 ( x 512 bytes blocks ) = 7742685184 bytes =    7.2 Gb
step =    1.0 Mb
disk = /dev/sdb size =    7.2 Gb
checking offset 0 [0]
checking offset 1048576 [   1.0 Mb]
checking offset 2097152 [   2.0 Mb]
checking offset 3145728 [   3.0 Mb]
checking offset 4194304 [   4.0 Mb]
checking offset 5242880 [   5.0 Mb]
checking offset 6291456 [   6.0 Mb]
checking offset 7340032 [   7.0 Mb]
checking offset 8388608 [   8.0 Mb]
checking offset 9437184 [   9.0 Mb]
checking offset 10485760 [  10.0 Mb]
checking offset 11534336 [  11.0 Mb]
checking offset 12582912 [  12.0 Mb]
checking offset 13631488 [  13.0 Mb]
checking offset 14680064 [  14.0 Mb]
checking offset 15728640 [  15.0 Mb]
checking offset 16777216 [  16.0 Mb]
checking offset 17825792 [  17.0 Mb]
checking offset 18874368 [  18.0 Mb]
checking offset 19922944 [  19.0 Mb]
checking offset 20971520 [  20.0 Mb]
checking offset 22020096 [  21.0 Mb]
checking offset 23068672 [  22.0 Mb]
checking offset 24117248 [  23.0 Mb]
checking offset 25165824 [  24.0 Mb]
checking offset 26214400 [  25.0 Mb]
checking offset 27262976 [  26.0 Mb]
checking offset 28311552 [  27.0 Mb]
checking offset 29360128 [  28.0 Mb]
checking offset 30408704 [  29.0 Mb]
checking offset 31457280 [  30.0 Mb]
checking offset 32505856 [  31.0 Mb]
checking offset 33554432 [  32.0 Mb]
checking offset 34603008 [  33.0 Mb]
checking offset 35651584 [  34.0 Mb]
checking offset 36700160 [  35.0 Mb]
checking offset 37748736 [  36.0 Mb]
checking offset 38797312 [  37.0 Mb]
checking offset 39845888 [  38.0 Mb]
checking offset 40894464 [  39.0 Mb]
checking offset 41943040 [  40.0 Mb]
checking offset 42991616 [  41.0 Mb]
checking offset 44040192 [  42.0 Mb]
checking offset 45088768 [  43.0 Mb]
checking offset 46137344 [  44.0 Mb]
checking offset 47185920 [  45.0 Mb]
checking offset 48234496 [  46.0 Mb]
checking offset 49283072 [  47.0 Mb]
checking offset 50331648 [  48.0 Mb]
checking offset 51380224 [  49.0 Mb]
checking offset 52428800 [  50.0 Mb]
checking offset 53477376 [  51.0 Mb]
checking offset 54525952 [  52.0 Mb]
checking offset 55574528 [  53.0 Mb]
checking offset 56623104 [  54.0 Mb]
checking offset 57671680 [  55.0 Mb]
checking offset 58720256 [  56.0 Mb]
checking offset 59768832 [  57.0 Mb]
checking offset 60817408 [  58.0 Mb]
checking offset 61865984 [  59.0 Mb]
checking offset 62914560 [  60.0 Mb]
Exception thrown: 'System.IO.IOException' in System.Private.CoreLib.dll
  * error access detected at offset 62914560 [  60.0 Mb]
checking offset 63963136 [  61.0 Mb]
Exception thrown: 'System.IO.IOException' in System.Private.CoreLib.dll
  * error access detected at offset 63963136 [  61.0 Mb]
checking offset 65011712 [  62.0 Mb]
(ctrl+c)
```
