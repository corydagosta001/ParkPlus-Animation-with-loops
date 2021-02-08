using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation.Model
{
    public static class Directions
    {
        public static List<ArrowModel> ArrowList = new List<ArrowModel>();
        public static int speed = 5;
        public static void FillList(object forward, string fMsg, string ua, object backward, string bMsg, string da, object right, string rMsg, string ra, 
            object left, string lMsg, string la)
        {
            ArrowList.Add(addRecords(forward, fMsg, ua));
            ArrowList.Add(addRecords(backward, bMsg, da));
            ArrowList.Add(addRecords(right, rMsg, ra));
            ArrowList.Add(addRecords(left, lMsg, la));
        }

        private static ArrowModel addRecords(object dir, string msg, string image)
        {
            ArrowModel am = new ArrowModel();
            am.Direction = dir;
            am.Instructions = msg;
            am.Image = image;
            return am;
        }
    }
}
