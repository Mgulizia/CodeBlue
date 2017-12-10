using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlue.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeBlue.Tests.Models
{
    [TestClass]
    public class CommentsTest
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }

        [TestMethod]
        public void ValidateCommentTest()
        {
            var model = new Comments
            {
                Comment = "test",
            };

            var results = Validate(model);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ValidateNullEntryTest()
        {
            var model = new Comments();

            var results = Validate(model);
            Assert.IsNull(model.Comment);
        }

        [TestMethod]
        public void ValidateStringLength()
        {
            var model = new Comments
            {
                PostedById = new string('*', 129)
            };

            var results = Validate(model);
            Assert.AreEqual(1, results.Count);
        }
    }
}
