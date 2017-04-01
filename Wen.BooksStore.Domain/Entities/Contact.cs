using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.BooksStore.Domain.Entities
{
    /// <summary>
    /// 联系信息
    /// </summary>
    public class Contact
    {
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [RegularExpression(@"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\w\w)", ErrorMessage = "输入的邮箱地址不合法")]
        public string Email { get; set; }
    }
}
