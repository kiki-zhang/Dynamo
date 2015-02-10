﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoCore.DSASM;
using ProtoCore.Lang.Replication;
using ProtoCore.Utils;

namespace ProtoCore.Utils
{
    public static class StringUtils
    {
        public static int CompareString(StackValue s1, StackValue s2, Core core)
        {
            if (!s1.IsString || !s2.IsString)
                return Constants.kInvalidIndex;

            if (s1.Equals(s2))
                return 0;

            string str1 = core.Heap.GetString(s1);
            string str2 = core.Heap.GetString(s2);
            return string.Compare(str1, str2);
        }

        public static string GetStringValue(StackValue sv, Core core)
        {
            ProtoCore.DSASM.Mirror.ExecutionMirror mirror = new DSASM.Mirror.ExecutionMirror(new ProtoCore.DSASM.Executive(core), core);
            return mirror.GetStringValue(sv, core.Heap, 0, true);
        }

        public static StackValue ConvertToString(StackValue sv, Core core, ProtoCore.Runtime.RuntimeMemory rmem)
        {
            StackValue returnSV;
            //TODO: Change Execution mirror class to have static methods, so that an instance does not have to be created
            ProtoCore.DSASM.Mirror.ExecutionMirror mirror = new DSASM.Mirror.ExecutionMirror(new ProtoCore.DSASM.Executive(core), core);
            returnSV = ProtoCore.DSASM.StackValue.BuildString(mirror.GetStringValue(sv, core.Heap,0, true),core.Heap);
            return returnSV;
        }

        public static StackValue ConcatString(StackValue op1, StackValue op2, ProtoCore.Core core)
        {
            var v1 = core.Heap.GetString(op1);
            var v2 = core.Heap.GetString(op2);
            return StackValue.BuildString(v1 + v2, core.Heap);
        }
    }
}
