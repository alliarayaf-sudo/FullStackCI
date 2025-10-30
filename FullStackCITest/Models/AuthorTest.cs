using FullStackCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.Models
{
    internal class AuthorTest
    {

        public void Test () {
            Category category = new Category();
            category.Id = 1;
            category.Name = "Test";
            category.Description = "Test";
            Assert.NotNull(category); 
            Assert.NotNull(category.Name);

        }
        


    }
}
