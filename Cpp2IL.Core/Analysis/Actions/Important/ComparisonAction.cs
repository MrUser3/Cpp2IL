﻿using Cpp2IL.Core.Analysis.Actions.Base;
using Cpp2IL.Core.Analysis.ResultModels;
using Iced.Intel;
using Instruction = Iced.Intel.Instruction;

namespace Cpp2IL.Core.Analysis.Actions.Important
{
    public class ComparisonAction : AbstractComparisonAction<Instruction>
    {
        public ComparisonAction(MethodAnalysis<Instruction> context, Instruction instruction) : base(context, instruction)
        {
            
        }

        protected override bool IsMemoryReferenceAnAbsolutePointer(Instruction instruction) => instruction.Op0Kind == OpKind.Memory && (instruction.Op0Register == Register.None || instruction.Op0Register.GetFullRegister() == Register.RIP);

        protected override string GetRegisterName(Instruction instruction, int opIdx) => Utils.GetRegisterNameNew(instruction.GetOpRegister(opIdx));

        protected override string GetMemoryBaseName(Instruction instruction) => Utils.GetRegisterNameNew(instruction.MemoryBase);

        protected override ulong GetInstructionMemoryOffset(Instruction instruction) => instruction.MemoryDisplacement64;

        protected override ulong GetImmediateValue(Instruction instruction, int operandIdx) => instruction.GetImmediateSafe(operandIdx);

        protected override ComparisonOperandType GetOperandType(Instruction instruction, int operandIdx)
        {
            var opKind = instruction.GetOpKind(operandIdx);

            if (opKind.IsImmediate())
                return ComparisonOperandType.IMMEDIATE_CONSTANT;

            if (opKind == OpKind.Register)
                return ComparisonOperandType.REGISTER_CONTENT;

            return ComparisonOperandType.MEMORY_ADDRESS_OR_OFFSET;
        }
    }
}