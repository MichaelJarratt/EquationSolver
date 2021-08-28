using System;
using System.Collections.Generic;
using System.Text;

namespace EquationSolver.Validation
{
    //This class acts as a collection of validation failures to be passed to the invoker.
    public class ValidationInstance
    {
        public bool valid = true; //did the entire equation validate?
        public List<ValidationObject> offences = new List<ValidationObject>();

        /// <summary>
        /// Adds an offence to the list and sets the valid flag to false.
        /// </summary>
        /// <param name="validationObject">The office to add to the list</param>
        public void addOffence(ValidationObject validationObject)
        {
            valid = false;
            offences.Add(validationObject);
        }

        /// <summary>
        /// Returns ValidationObject at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>ValidationObject at index</returns>
        public ValidationObject this[int index]
        {
            get => offences[index];
        }
    }
}
