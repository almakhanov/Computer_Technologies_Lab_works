using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_FarManager_Files
{
    class State
    {
        int index;
        DirectoryInfo dir;
       
        public int MaxIndex;
        #region Get&Set
        public DirectoryInfo Dir
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
                MaxIndex = dir.GetFileSystemInfos().Length;
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
