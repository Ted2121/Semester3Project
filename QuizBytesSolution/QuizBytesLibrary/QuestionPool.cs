﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{

    public class QuestionPool : IQuestionPool
    {
        
        public IEnumerable<IQuestion> Questions { get; set; }

    }
}
