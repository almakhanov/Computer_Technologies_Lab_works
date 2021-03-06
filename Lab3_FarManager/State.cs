﻿using System;
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
        FileInfo file;
        public int MaxIndex;
        #region Get&Set
        public DirectoryInfo Folder
        {
            get
            {
                return folder;
            }
            set
            {
                folder = value;
                MaxIndex = folder.GetDirectories().Length + folder.GetFiles().Length;
            }
        }

        public FileInfo File
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
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
                if(value >= 0 && value < MaxIndex)
                {
                    index = value;
                }
            }//set
        }//end index
        #endregion



    }//end class
}
