﻿using System.Collections.Generic;

namespace Shared.GeneralHelper.ViewModels.ServicesViewModel
{
    public class CustomValidationModel
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
    }
}