using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_FarManager
{
    class State
    {
        int index;
        DirectoryInfo folder;
        public int MaxIndex;

        public DirectoryInfo Folder
        {
            get
            {
                return folder;
            }
            set
            {
                folder = value;
                MaxIndex = folder.GetDirectories().Length;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value >= 0 && value < MaxIndex)
                {
                    index = value;
                }
            }//set
        }//end index

    }//end class
}
