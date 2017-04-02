using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.BooksStore.Domain.Entities
{
    [Table("Book")]
    public class Book
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required(ErrorMessage = "描述不能为空")]
        public string Description { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Required(ErrorMessage = "价格不能为空")]
        [Range(0.01, double.MaxValue, ErrorMessage = "请填写合适的价格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Required(ErrorMessage = "分类不能为空")]
        public string Category { get; set; }
    }
}
