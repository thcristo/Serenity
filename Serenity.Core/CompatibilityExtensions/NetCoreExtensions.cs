using System;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class NetCoreExtensions
    {
        public static TAttribute GetCustomAttribute<TAttribute>(this Type type, bool inherit = true)
            where TAttribute: System.Attribute
        {
            return type.GetTypeInfo().GetCustomAttribute<TAttribute>(inherit);
        }

        public static Attribute[] GetCustomAttributes(this Type type, Type attributeType, bool inherit = true)
        {
            return type.GetTypeInfo().GetCustomAttributes(attributeType, inherit).ToArray();
        }

        public static bool GetIsEnum(this Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

        public static bool GetContainsGenericParameters(this Type type)
        {
            return type.GetTypeInfo().ContainsGenericParameters;
        }

        public static bool GetIsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        public static bool GetIsClass(this Type type)
        {
            return type.GetTypeInfo().IsClass;
        }

        public static bool GetIsInterface(this Type type)
        {
            return type.GetTypeInfo().IsInterface;
        }

        public static bool GetIsGenericTypeDefinition(this Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition;
        }

        public static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().GetGenericArguments();
        }

        public static ConstructorInfo[] GetConstructors(this Type type)
        {
            return type.GetTypeInfo().GetConstructors();
        }

        public static MemberInfo[] GetMember(this Type type, string name)
        {
            return type.GetTypeInfo().GetMember(name);
        }

        public static bool IsAssignableFrom(this Type type, Type other)
        {
            return type.GetTypeInfo().IsAssignableFrom(other);
        }
    }
}