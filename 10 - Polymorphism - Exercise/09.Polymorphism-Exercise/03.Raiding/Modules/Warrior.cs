﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Modules
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;
        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}