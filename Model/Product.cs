using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Model
{
    public class Product
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public BitmapImage BitmapImage { get; set; }
    }
}
