using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class BoarderControl
    {
		private List<BaseEntity> numbers;

        public BoarderControl()
        {
            numbers = new List<BaseEntity>();
         }
        public List<BaseEntity> Numbers
		{
			get { return numbers; }
			set {  numbers = value; }
		}

        public void AddNumber(BaseEntity entyti)
        { 
         numbers.Add(entyti);
        }

      
	}
}
