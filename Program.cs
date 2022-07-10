using System;

namespace SchedulerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            DateTime walked_date = DateTime.Now;
            Console.Write("Enter a pattern Xs and Os not zeroes -> ");
            string? output = Console.ReadLine();

            int packed_value = 0;


            if (output is null)
            {
                return;
            }
            if (output.Length > 27)
            {
                return;
            }

            for (int i = output.Length - 1; i >= 0; i--)
            {

                if (output[i].Equals('X'))
                {
                    packed_value = packed_value << 1;
                    packed_value = packed_value | 1;
                }
                else
                {
                    packed_value = packed_value << 1;
                }
            }
            packed_value = packed_value << 5;
            packed_value = packed_value | (Int32)output.Length;

            Console.WriteLine();
            Console.WriteLine("Generated packed value:" + packed_value);
            Console.WriteLine("Generated packed value binary: " + Convert.ToString(packed_value, 2));

            int hit_count = 0;


            // Used to unpack information from int
            int pattern_length = packed_value & 31; //Get length pattern from first 5 bits
            int pattern_data = packed_value >> 5;
            Console.WriteLine();
            while (hit_count <= 27)
            {
                int day_diff = walked_date.Date.Subtract(today.Date).Days;

                int pattern_progress = day_diff % pattern_length;

                int pattern_today = (pattern_data >> pattern_progress) & 1;

                if (pattern_today == 1)
                {
                    Console.WriteLine("Intake on: " + walked_date.ToShortDateString());
                    hit_count++;
                }
                walked_date = walked_date.AddDays(1);
            }

        }
    }
}