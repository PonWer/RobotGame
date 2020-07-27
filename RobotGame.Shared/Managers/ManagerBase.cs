using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace RobotGame.Shared.Managers
{
    public abstract class ManagerBase : IGameLoop
    {
        readonly CultureInfo _invCulture = CultureInfo.InvariantCulture;
        public string GetResourceFile(string filename)
        {
            string result;
            using (var stream = GetType()
                .Assembly
                .GetManifestResourceStream("RobotGame.Shared.Resources." + filename))
            using (var sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        public abstract void PreRenderUpdate();

        public abstract void PostRenderUpdate();

        protected int GetIntValue(XElement element, string inTagName)
        {
            var value = element.Element(inTagName)?.Value;
            return string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value, _invCulture);
        }

        protected double GetDoubleValue(XElement element, string inTagName)
        {
            var value = element.Element(inTagName)?.Value;
            return string.IsNullOrWhiteSpace(value) ? 0 : double.Parse(value, _invCulture);
        }

        protected string GetStringValue(XElement element, string inTagName)
        {
            return element.Element(inTagName)?.Value;
        }
    }
}
