﻿namespace Narvalo.GhostScript.Options
{
    using System;
    using System.Collections.Generic;

    public class PrinterDevice : OutputDevice
    {
        public PrinterDevice() : base() { }

        public override bool CanDisplay { get { return true; } }

        public override string DeviceName
        {
            get { throw new NotImplementedException(); }
        }

        public override void AddDisplayTo(ICollection<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
