using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    static class Day4
    {
        static public void Part1()
        {
            string[] lines = Util.Input.ReadLines(1136);
            int validPassports = ParsePassports(lines, false);
            Console.WriteLine("Number of valid passports: " + validPassports.ToString());
        }

        static public void Part2()
        {
            string[] lines = Util.Input.ReadLines(1136);
            int validPassports = ParsePassports(lines, true);
            Console.WriteLine("Number of valid passports: " + validPassports.ToString());
        }

        static private int ParsePassports(string[] lines, bool advValidate)
        {
            int validatedPassports = 0;
            string currentFields = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "" || i == (lines.Length - 1))
                {
                    Passport ps = new Passport(currentFields.Split(' '));
                    if (advValidate)
                    {
                        if (ps.Validate2())
                            validatedPassports++;
                    } else
                    {
                        if (ps.Validate())
                            validatedPassports++;
                    }
                    
                    currentFields = "";
                }
                else
                {
                    currentFields = currentFields + lines[i] + ' ';
                }
            }
            return validatedPassports;
        }
    }

    class Passport
    {
        int birthYear = -1;
        int issueYear = -1;
        int expirationYear = -1;
        string height = "";
        string hairColour = "";
        string eyeColour = "";
        string passportID = "";
        string countryID = "";

        public Passport(string[] fields)
        {
            string[] nameValuePair;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] != "")
                {
                    nameValuePair = fields[i].Split(':');
                    switch (nameValuePair[0])
                    {
                        case "byr":
                            if (!Util.String.ContainsLetters(nameValuePair[1]))
                                birthYear = Int32.Parse(nameValuePair[1]);
                            break;
                        case "iyr":
                            if (!Util.String.ContainsLetters(nameValuePair[1]))
                                issueYear = Int32.Parse(nameValuePair[1]);
                            break;
                        case "eyr":
                            if (!Util.String.ContainsLetters(nameValuePair[1]))
                                expirationYear = Int32.Parse(nameValuePair[1]);
                            break;
                        case "hgt":
                            height = nameValuePair[1];
                            break;
                        case "hcl":
                            hairColour = nameValuePair[1];
                            break;
                        case "ecl":
                            eyeColour = nameValuePair[1];
                            break;
                        case "pid":
                            passportID = nameValuePair[1];
                            break;
                        case "cid":
                            countryID = nameValuePair[1];
                            break;
                    }
                }
            }
        }

        public bool Validate()
        {
            return (birthYear != -1 && issueYear != -1 && expirationYear != -1 && height != "" && hairColour != "" && eyeColour != "" && passportID != "");
        }
        public bool Validate2()
        {
            bool allValuesPresent = (birthYear != -1 && issueYear != -1 && expirationYear != -1 && height != "" && hairColour != "" && eyeColour != "" && passportID != "");
            if (!allValuesPresent)
                return false;
            bool byrValid = birthYear >= 1920 && birthYear <= 2002;
            bool iyrValid = issueYear >= 2010 && issueYear <= 2020;
            bool eyrValid = expirationYear >= 2020 && expirationYear <= 2030;
            bool hgtValid = false;
            if (Regex.IsMatch(height, "\\d+[a-z]{2}"))
            {
                int value = Int32.Parse(Regex.Match(height, "\\d+").Value);
                string unit = Regex.Match(height, "[a-z]+").Value;
                if (unit == "in")
                    hgtValid = value >= 59 && value <= 76;
                else if (unit == "cm")
                    hgtValid = value >= 150 && value <= 193;
            }
            bool hclValid = Regex.IsMatch(hairColour, "#[\\da-f]{6}");
            bool eclValid = false;
            string[] validEyeColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            for (int i = 0; i < validEyeColours.Length; i++)
            {
                if (eyeColour == validEyeColours[i])
                {
                    eclValid = true;
                    break;
                }
            }
            bool pidValid = passportID.Length == 9 && !Util.String.ContainsLetters(passportID);
            return byrValid && iyrValid && eyrValid && hgtValid && hclValid && eclValid && pidValid;
        }
    }
}
