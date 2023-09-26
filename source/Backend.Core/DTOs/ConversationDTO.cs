﻿using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class ConversationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public Channel Channel { get; set; }
    }
}