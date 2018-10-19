using System.Collections.Generic;
using Castle.Core.Internal;

namespace Common
{
    public class SauceLabsCapabilities
    {
        private List<string> _tags;

        public SauceLabsCapabilities()
        {
            _tags = new List<string>();
        }

        public bool IsDebuggingEnabled { get; set; }

        public List<string> Tags
        {
            get => _tags;
            set => _tags = value;
        }

        public string BuildName { get; set; }
    }
}