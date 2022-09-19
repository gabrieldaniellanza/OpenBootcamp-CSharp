using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Grade { get; set; }

        public bool Certificated { get; set; }

    }
}
