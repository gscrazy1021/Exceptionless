﻿#region Copyright 2014 Exceptionless

// This program is free software: you can redistribute it and/or modify it 
// under the terms of the GNU Affero General Public License as published 
// by the Free Software Foundation, either version 3 of the License, or 
// (at your option) any later version.
// 
//     http://www.gnu.org/licenses/agpl-3.0.html

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Exceptionless.Core.Utility;
using Newtonsoft.Json.Linq;

namespace Exceptionless.Core.Plugins.EventUpgrader {
    public class EventUpgraderContext : ExtensibleObject {
        public EventUpgraderContext(string json, Version version = null, bool isMigration = false) {
            try {
                JObject doc = JObject.Parse(json);
                Documents = new JArray(doc);
            } catch {
                try {
                    JArray docs = JArray.Parse(json);
                    Documents = docs;
                } catch { }
            }

            Version = version;
            IsMigration = isMigration;
        }

        public EventUpgraderContext(JObject doc, Version version = null, bool isMigration = false) {
            Documents = new JArray(doc);
            Version = version;
            IsMigration = isMigration;
        }

        public EventUpgraderContext(JArray docs, Version version = null, bool isMigration = false) {
            Documents = docs;
            Version = version;
            IsMigration = isMigration;
        }

        public JArray Documents { get; set; }
        public Version Version { get; set; }
        public bool IsMigration { get; set; }
    }
}