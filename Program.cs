// See https://aka.ms/new-console-template for more information
using static System.Console;
using Unit_converter;

float input_value;
while (true)
{
    do
    {
        Clear();
        WriteLine("--- Convert units ---");
        WriteLine("Value you want to convert");
    } while (!float.TryParse(ReadLine(), out input_value));

    WriteLine("Which unit do you wanna convert from?");
    WriteLine("1. m/s");
    WriteLine("2. km/t");
    WriteLine("3. mph");
    WriteLine("4. knots");
    string from_unit = ReadKey(true).KeyChar.ToString();
    Clear();
    WriteLine("Unit to convert to?");
    if (from_unit != "1")
        WriteLine("1. m/s");
    if (from_unit != "2")
        WriteLine("2. km/t");
    if (from_unit != "3")
        WriteLine("3. mph");
    if (from_unit != "4")
        WriteLine("4. knots");
    string to_unit = ReadKey(true).KeyChar.ToString();
    Clear();
    WriteLine(convert_units(input_value, from_unit, to_unit));

    ReadKey();
}

static string convert_units(float input_value, string from_unit, string to_unit)
{
    float result = 0;
    string unit = "";
    switch (from_unit)
    {
        // m/s
        case "1":
            if (to_unit == "1")
                result = input_value;
            else if (to_unit == "2")
                result = ms.to_kmph(input_value);
            else if (to_unit == "3")
                result = ms.to_mph(input_value);
            else if (to_unit == "3")
                result = ms.to_knots(input_value);
            unit = ms.name;
            break;
        // km/t
        case "2":
            if (to_unit == "1")
                result = kmh.to_SI_unit(input_value);
            else if (to_unit == "2")
                result = input_value;
            else if (to_unit == "3")
                result = ms.to_mph(kmh.to_SI_unit(input_value));
            else if (to_unit == "4")
                result = ms.to_knots(kmh.to_SI_unit(input_value));
            unit = kmh.name;
            break;
        // mph
        case "3":
            if (to_unit == "1")
                result = mph.to_SI_unit(input_value);
            else if (to_unit == "2")
                result = ms.to_kmph(mph.to_SI_unit(input_value));
            else if (to_unit == "3")
                result = input_value;
            else if (to_unit == "4")
                result = ms.to_knots(mph.to_SI_unit(input_value));
            unit = mph.name;
            break;
        // knots
        case "4":
            if (to_unit == "1")
                result = knots.to_SI_unit(input_value);
            else if (to_unit == "2")
                result = ms.to_kmph(knots.to_SI_unit(input_value));
            else if (to_unit == "3")
                result = ms.to_mph(knots.to_SI_unit(input_value));
            else if (to_unit == "4")
                result = input_value;
            unit = knots.name;
            break;
    }
    return $"{result} {unit}";
}

