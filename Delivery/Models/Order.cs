using System.ComponentModel.DataAnnotations;

namespace Delivery.Models
{
    public class Order
    {
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        //[DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Введите почту")]
        //[DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public DateTime orderTime { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }
    }
}
