﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Project.Tools.Help
{
    public class FindAssemblyTypes
    {
        public static IEnumerable<Type> FindDerivedTypesFromAssembly(Assembly assembly, Type baseType, bool classOnly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly", "Assembly must be defined");
            }

            if (baseType == null)
            {
                throw new ArgumentNullException("baseType", "Parent Type must be defined");
            }

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (classOnly && !type.IsClass)
                {
                    continue;
                }

                if (baseType.IsInterface)
                {
                    var it = type.GetInterface(baseType.FullName);

                    if (it != null)
                    {
                        yield return type;
                    }
                }
                else if (type.IsSubclassOf(baseType))
                {
                    yield return type;
                }
            }
        }
    }
}

