using System;
using System.IO;

namespace Todo
{
    public static class Constants
    {
        public const string DatabaseFilename = "todo.db";
        public const string  SelectedColor = nameof(SelectedColor);

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
