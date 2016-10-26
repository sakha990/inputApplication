using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inputApplication
{
    public static class Global
    {
        private static string _workingDirectory = string.Empty;
        private static string _parentCategory = string.Empty;
        private static string _category = string.Empty;
        private static string _templateFileName = string.Empty;
        private static bool _mergeError = false;

        public static string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; }
        }

        public static string ParentCategory
        {
            get { return _parentCategory; }
            set { _parentCategory = value; }
        }
        public static string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public static string TemplateFileName
        {
            get { return _templateFileName; }
            set { _templateFileName = value; }
        }

        public static bool MergeError
        {
            get { return _mergeError; }
            set { _mergeError = value; }
        }

    }
}
