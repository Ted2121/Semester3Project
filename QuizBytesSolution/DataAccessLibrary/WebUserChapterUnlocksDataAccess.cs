﻿using DataAccessDefinitionLibrary.DAO_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessDefinitionLibrary.Data_Access_Models;

namespace SQLAccessImplementationLibrary
{
    public class WebUserChapterUnlocksDataAccess : BaseDataAccess, IWebUserChapterUnlocksDataAccess
    {
        public WebUserChapterUnlocksDataAccess(string connectionstring) : base(connectionstring)
        {
        }
    }
}
