using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.Usuarios
{
    public class ResetPasswordViewModel
    {
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Mínimo 8 carácteres, al menos una letra mayúscula, una letra minúscula y un número:")]
        [Required(ErrorMessage = "Password nuevo es requerido", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Mínimo 8 carácteres, al menos una letra mayúscula, una letra minúscula y un número:")]
        [Compare("NewPassword", ErrorMessage = "Nueva contraseña y Confirmar contraseña no son iguales.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string resetCode { get; set; }
    }
}