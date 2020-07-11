using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class LogInViewModel : ViewModel
    {

        [Required]
        public string UserID { get; set; }
        [Required]
        public string Database { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
