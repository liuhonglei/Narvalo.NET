﻿namespace Narvalo.GhostScript.Options
{
    using System;
    using System.Collections.Generic;

    public class NoDevice : Device
    {
        public NoDevice() : base() { }

        public override void AddTo(ICollection<string> args)
        {
            if (args == null) {
                throw new ArgumentNullException("args");
            }

            args.Add("-dNODISPLAY");
        }
    }
}
