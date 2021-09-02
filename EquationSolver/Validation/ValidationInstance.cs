using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EquationSolver.Validation
{
    /// <summary>
    /// Validation Instance of a collection of ValidationObjects pertaining to the validation of a particular equation.
    /// A ValidationObject represents a single validation failure.
    /// </summary>
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

        /// <summary>
        /// Order is not gaurenteed because of the way brackets are handled.
        /// Call this function when the last ValidationObject has been added to order them by position.
        /// </summary>
        public void orderCollection()
        {
            offences = offences.OrderBy(t => t.token.position).ToList();
        }
    }
}
