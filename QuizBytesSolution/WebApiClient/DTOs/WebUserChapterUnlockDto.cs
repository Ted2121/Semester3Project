﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class WebUserChapterUnlockDto
    {
        public WebUserDto WebUser { get; set; }
        public ChapterDto ChapterDto { get; set; }
    }
}
