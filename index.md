## 1. Introduction

The Um interface monitoring system was developed to make real-time measurement of received signal strength of GSM-R networks; extensive experiments were implemented along the Beijing–Shanghai high-speed railway.

### a. Platform

The hardware and software architecture of Um interface monitoring system is shown in the following. The system’s CPU module is RTD’s CME137686LX-W including a 333 MHz AMD Geode LX processor with 128 kB L1 cache and 128 kB L2 cache, and the GSM-R module is COM161 55RER-1 using Triorail’s engine TRM:3a. The system’s power supply, CPU and GSM-R modules are connected through PC/104 bus, and other peripherals through its specific interface. The software is independently developed by our research group, which uses Microsoft .NET Compact Framework written in C#, and it can run on various operating systems including Windows XP/Mobile/CE.

![Um monitoring system: hardware](https://github.com/yongsen/gsmr_monitoring/blob/master/picture/nEO_IMG_DSC05143.jpg)
![Um monitoring system: software](https://github.com/yongsen/gsmr_monitoring/blob/master/picture/SDC11215.JPG)

### b. Algorithm

The dynamic estimation algorithm is implemented on this platform and provides basic information to up-layer applications as shown in the following figure. The raw data of RSS is collected by GSM-R device, which is composed of the information of current cell and 6 neighbor cells. Then it is processed by the dynamic estimation algorithm to provide current network status and conduct next signal sampling. The system also provides RSS prediction based on the weighted averaging of signal samples, and gives warning information when the communication performance is lower than certain threshold. Since the system records the RSS of current and neighbor cells, the data can be used to make handover analysis and network optimization. Except the physical layer information, the system can also give quality of service of the link layer, including data traffic and voice service.

### c. Implementation

The received signal strength measurements, which is implemented by the Um monitoring system, were carried out along the Beijing–Shanghai high-speed railway. Since the velocity of train is up to 300 km/h  and the sampling interval is 500 ms limited by the length of measurement multi-frame, it requires repeated data collection to evaluate the estimation algorithm. Some measurement results can be found in the `data/` foldor, and the long-term and short-term fading are separated after on-line propagation estimation.

## 2. Files

1. **bin**: the .exe file of the software

2. **data**: the collected data including .xml and .xlsx

3. **picture**: the hardware and software of the system

4. [Manual](http://yongsen.github.io/files/Yongsen2011manual.pdf): the user's manual for the software in Chinese


## 3. How to

Make sure .NET Compact Framework 2.0 or above is installed in the OS system.

### a. For users

1. run the .exe file of _/bin/CellInfo.exe_

2. configure the serial port

3. click the _run_ button

4. more detailed information can be find in _[Manual.pdf](http://yongsen.github.io/files/Yongsen2011manual.pdf)_

### b. For developers

1. open the _CellInfo.csproj_ in Visual Studio

2. try to make changes to different modules written in C#
