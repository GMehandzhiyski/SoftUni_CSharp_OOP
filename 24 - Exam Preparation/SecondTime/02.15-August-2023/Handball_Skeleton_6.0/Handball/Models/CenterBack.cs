﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double centerBackRating = 4;
        public CenterBack(string name)
            : base(name, centerBackRating)
        {
        }
        public override void IncreaseRating()
        {
            Rating += 1;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= 1;
            if (Rating < 1)
            {
                Rating = 1;
            }

        }

    }
}
