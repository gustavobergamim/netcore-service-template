using System;
using static System.String;

namespace ProjetoBase.WebApi.StartupConfig
{
    public static class EnvironmentHelper
    {
        public static bool IsIisHosted()
        {
            var varValue = GetEnvVar("HOSTING_ENV");
            return !IsNullOrEmpty(varValue) && varValue == "IIS";
        }

        public static string GetEnvVar(string varName)
        {
            var varValue = Environment.GetEnvironmentVariable(varName, EnvironmentVariableTarget.Machine);
            if (!IsNullOrEmpty(varValue))
            {
                return varValue;
            }
            varValue = Environment.GetEnvironmentVariable(varName, EnvironmentVariableTarget.Process);
            return varValue;
        }
    }
}
