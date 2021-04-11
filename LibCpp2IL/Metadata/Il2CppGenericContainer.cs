using System;
using System.Collections.Generic;
using System.Linq;

namespace LibCpp2IL.Metadata
{
    public class Il2CppGenericContainer
    {
        /* index of the generic type definition or the generic method definition corresponding to this container */
        public int ownerIndex; // either index into Il2CppClass metadata array or Il2CppMethodDefinition array

        //Number of generic arguments
        public int type_argc;

        /* If true, we're a generic method, otherwise a generic type definition. */
        public int is_method;

        /* Our type parameters. */
        public int genericParameterStart;

        public IEnumerable<Il2CppGenericParameter> GenericParameters
        {
            get
            {
                if(type_argc == 0)
                    yield break;
                
                var end = genericParameterStart + type_argc;
                for (var i = genericParameterStart; i < end; i++)
                {
                    var p = LibCpp2IlMain.TheMetadata!.genericParameters[i];
                    p.Index = i;
                    yield return p;
                }
            }
        }
    }
}