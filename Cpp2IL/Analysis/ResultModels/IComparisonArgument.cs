﻿using Mono.Cecil.Cil;

namespace Cpp2IL.Analysis.ResultModels
{
    public interface IComparisonArgument
    {
        public string GetPseudocodeRepresentation();

        public Instruction[] GetILToLoad(MethodAnalysis context, ILProcessor processor);
    }
}