using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RobotGame.Shared.Managers
{
    public abstract class ManagerBase : IGameLoop
    {
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
    }
}
