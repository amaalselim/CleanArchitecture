using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "api";
        public const string rule = root + "/";

        public static class StudentRouting
        {
            public const string Prefix = rule + "student";
            public const string List = Prefix + "/list";
            public const string GetById = Prefix + "/{id}";

        }
    }
}
