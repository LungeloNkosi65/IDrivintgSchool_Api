using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Enums
{
  
    public class EnumService
    {
        public enum UserStatus
        {
            Valid=0,
            Invalid=1,
            Null=2
        };

       public enum RegisterResults
        {
            Success=0,
            Fialed=1,
            Exists=2
        };

        public enum CrudResult
        {
            Success=0,
            Fialed=1,
            Exisist=2
        };
    }
}
