using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroUsuariosViewModel
    {
        [Display(Name = "Nº Matrícula")]
        [Required(ErrorMessage = "O campo matrícula é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]*$",ErrorMessage = "O valor da matrícula deve ser numérico!")]
        public String Matricula { get; set; }
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório", AllowEmptyStrings = false)]
        [MinLength(5,ErrorMessage = "O campo nome deve ter no mínimo 5 caracteres!")]
        [MaxLength(80,ErrorMessage = "O campo nome deve ter no máximo 80 caracteres!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage = "O campo nome não pode ter números ou caracteres especiais")]
        public String Nome { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "O campo login é obrigatório", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "O campo login deve ter no mínimo 5 caracteres!")]
        [MaxLength(50, ErrorMessage = "O campo login deve ter no máximo 50 caracteres!")]
        public String Login { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "O campo senha e a confirmação não se correspondem!")]
        public String PasswordConfirm { get; set; }
        [Display(Name = "Nível de Acesso")]
        [Required(ErrorMessage = "Selecione um nível de acesso!")]
        public int SelectedRole { get; set; }
        public SelectList listRoles { get; set; }
        [Display(Name = "Disciplina")]
        public String Subject { get; set; }
    }
}