using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    static class Day4
    {
        static public void Part1()
        {
            string[] lines = Util.Input.ReadLines(1136);
            int validPassports = ParsePassports(lines);
            Console.WriteLine("Number of valid passports: " + validPassports.ToString());
        }

        static private int ParsePassports(string[] lines)
        {
            int validatedPassports = 0;
            string currentFields = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "" || i == (lines.Length - 1))
                {
                    Passport ps = new Passport(currentFields.Split(' '));
                    if (ps.Validate())
                        validatedPassports++;
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

            return allValuesPresent;
        }
    }
}
