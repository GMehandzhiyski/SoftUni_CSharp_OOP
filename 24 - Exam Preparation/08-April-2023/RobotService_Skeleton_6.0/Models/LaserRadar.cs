﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LaserRadarInterfaceStandart = 20_082;
        private const int LaserRadarBatteryUsage = 10_000;
        public LaserRadar() :
            base(LaserRadarInterfaceStandart, LaserRadarBatteryUsage)
        {

        }
    }
}
