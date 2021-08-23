using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EquationSolver.Properties;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace EquationSolver
{
    //this singleton class represents the JSON configuration data
    public class Config
    {
        public List<String> operators;
        public List<String> operations;

        public Dictionary<string, Decimal> constants = new Dictionary<string, Decimal>();

        //private static String configPath = @"config.json";
        private static Config instance; //singleton instance
        

        private Config()
        {
            var config = Resources.config;
            string content = File.ReadAllText("../../../config.json");
            JObject data = JObject.Parse(content);

            //operators
            try
            {
                operators = data.SelectToken("operators").ToObject<List<String>>(); //JArray object selected from data and converted to normal array
                operations = data.SelectToken("operations").ToObject<List<String>>();
            }
            catch (Exception e)
            {
                throw new Exception("JSON formatting error", e);
            }

            if(operators.Count != operations.Count)
            {
                throw new Exception("Number of operators do not match the number of operations");
            }
            if(containsNumber(operators)) //a number here may confuse the tokeniser, a number cannot be an operator regardless
            {
                throw new Exception("Numbers cannot be operators");
            }

            //Brackets are always present and so are hard coded and not included in the JSON
            operators.Add("(");
            operators.Add(")");
            //!operators

            //constants
            var jConstants = data["constants"].Children();
            string key;
            Decimal value;
            foreach (var constant in jConstants)
            {
                key = constant[0].ToObject<string>();
                value = constant[1].ToObject<Decimal>();
                constants.Add(key, value);
            }
            //!constants
        }

        public static Config getInstance()
        {
            if (instance == null)
            {
                instance = new Config();
            }
            return instance;
        }

        /// <summary>
        /// Checks if a list contains an element that is a number
        /// </summary>
        /// <param name="">The list to check</param>
        /// <returns>Bool if it contains a number or not</returns>
        private bool containsNumber(List<String> list)
        {
            foreach (String item in list)
            {
                if(int.TryParse(item, out _)) // out _ is a discord, basically means I don't have to declare an int for out, I can just say that it would be ignored (discarded) anyway
                {
                    return true; //kind of ugly, but its efficient because it doesn't check the whole list if it encounters a number early on
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the operators list in the form of a character array
        /// </summary>
        /// <returns>Char operators as array</returns>
        private char[] operatorCharArray()
        {
            throw new NotImplementedException();
        } 

    }
}
