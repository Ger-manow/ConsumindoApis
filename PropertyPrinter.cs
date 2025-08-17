using System;
using System.Collections;
using System.Reflection;

public static class PropertyPrinter
{
    public static void PrintProperties(object obj, int indent = 0)
    {
        if (obj == null)
        {
            Console.WriteLine($"{new string(' ', indent)}Objeto nulo!");
            return;
        }

        Type type = obj.GetType();

        // Tipos simples: imprime direto
        if (type.IsPrimitive || obj is string || obj is DateTime || obj is decimal)
        {
            Console.WriteLine($"{new string(' ', indent)}{obj}");
            return;
        }

        // Se for coleção, imprime cada item
        if (obj is IEnumerable enumerable && !(obj is string))
        {
            foreach (var item in enumerable)
            {
                PrintProperties(item, indent + 2);
            }
            return;
        }

        PropertyInfo[] properties = type.GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj, null);
            var propType = prop.PropertyType;

            // Tipos simples
            if (propType.IsPrimitive || propType == typeof(string) || propType == typeof(DateTime) || propType == typeof(decimal))
            {
                Console.WriteLine($"{new string(' ', indent)}{prop.Name}: {value}");
            }
            // Coleção (mas não string)
            else if (typeof(IEnumerable).IsAssignableFrom(propType) && propType != typeof(string))
            {
                Console.WriteLine($"{new string(' ', indent)}{prop.Name}:");
                if (value is IEnumerable list)
                {
                    foreach (var item in list)
                    {
                        PrintProperties(item, indent + 2);
                    }
                }
                else
                {
                    Console.WriteLine($"{new string(' ', indent + 2)}(coleção vazia ou nula)");
                }
            }
            // Objeto complexo
            else
            {
                Console.WriteLine($"{new string(' ', indent)}{prop.Name}:");
                PrintProperties(value, indent + 2);
            }
        }
    }
}