﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class ClassWithStudentDto : ClassesDTO
    {
        public IList<HumansDTO> Students { get; set; } = new List<HumansDTO>();
    }
}
