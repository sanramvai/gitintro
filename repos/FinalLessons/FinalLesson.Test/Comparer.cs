﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalLesson.Test
{
    public class Comparer
    {
        public static Comparer<U> Pet<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }
    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;
        public Comparer(Func<T, T, bool> func)
        {
            comparisonFunction = func;
        }
        public bool Equals(T x, T y)
        {
            return comparisonFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
