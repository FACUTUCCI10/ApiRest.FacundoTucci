﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Dtos.Analysis.Response
{
    public class GetAnalysisByIdResponseDto
    {
        public int AnalysisId { get; set; }
        public string? name { get; set; }

    }
}
