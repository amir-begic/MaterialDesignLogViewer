﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Services.EncryptionService
{
    public interface IEncryptionService
    {
        string GenerateSaltedHash(string input);
    }
}
