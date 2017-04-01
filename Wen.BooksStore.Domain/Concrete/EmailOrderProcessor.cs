using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Concrete
{
    /// <summary>
    /// 邮件订单处理器
    /// </summary>
    public class EmailOrderProcessor : IOrderProcessor
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public static class Sender
        {
            /// <summary>
            /// 账号
            /// </summary>
            public static string Account = "943239005@qq.com";

            /// <summary>
            /// 密码
            /// </summary>
            public static string Password = "avzewttdyyppbccj";
        }

        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="contact"></param>
        public void ProcessOrder(Cart cart, Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Email))
            {
                throw new Exception("Email 不能为空！");
            }

            var sb = new StringBuilder();
            foreach (var item in cart.GetCartItems)
            {
                sb.AppendLine($"《{item.Book.Name}》：{item.Book.Price} * {item.Quantity} = {item.Book.Price * item.Quantity}");
            }

            sb.AppendLine($"总额：{cart.GetCartItems.Sum(x => x.Quantity * x.Book.Price)}");
            sb.AppendLine();
            sb.AppendLine($"联系人：{contact.Name} {contact.Address}");

            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            var fromAddr = new MailAddress(Sender.Account);
            var message = new MailMessage { From = fromAddr };

            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(contact.Email);
            //设置抄送人
            message.CC.Add(Sender.Account);
            //设置邮件标题
            message.Subject = "您的订单正在出库...";
            //设置邮件内容
            message.Body = sb.ToString();
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的

            var client = new SmtpClient("smtp.qq.com", 25)
            {
                Credentials = new NetworkCredential(Sender.Account, Sender.Password),
                EnableSsl = true
            };

            //设置发送人的邮箱账号和密码
            //启用ssl,也就是安全发送
            //发送邮件
            client.Send(message);
        }
    }
}
