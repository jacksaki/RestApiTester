using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class CSharpScriptEvaluator
    {
        public async Task<Type> GetResponseTypeAsync(ResponseTypeParameter p)
        {
            if (p?.IsEmpty ?? true)
            {
                return null;
            }
            var script = CSharpScript.Create(p.Source, GetOptions());
            return null;
        }

        private ScriptOptions GetOptions()
        {
            return ScriptOptions.Default
                .AddImports(AppConfig.GetInstance().Imports)
                .AddReferences(AppConfig.GetInstance().Assemblies);
        }
    }
}
