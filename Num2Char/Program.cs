using System;


class Program
{
    static void Main()
    {
        string num = "零一二三四五六七八九";
        string[] unit = {"", "十", "百", "千", "万", "十", "百", "千", "亿", "十", "百", "千", "兆", "十", "百", "千", "京", "十"};

        while(true)
        {
            bool isendzero = true;
            bool isprezero = false;

            Console.WriteLine("请输入0～999999999999999999(18位，十京)之间的格式正确的数字：");
            string raw = Console.ReadLine();
            int rl = raw.Length;
            string output = "";

            long number;
            if (raw == "0") output = "零";
            else if (rl > 18 || !long.TryParse(raw, out number) || raw[0] == '0')
            {
                Console.WriteLine("输入不正确。");
            }
            else
            {
                for(int i=0; i<rl; i++)
                {
                    int n = int.Parse(raw[rl-i-1].ToString());
                    if (n !=0 )
                    {
                        isendzero = false;
                        isprezero = false;
                        output = num[n] + unit[i] + output;
                    }
                    else
                    {
                        if (isendzero || isprezero)
                        {
                            continue;
                        }
                        else
                        {
                            output = "零" + output;
                        }
                        isprezero = true;
                    }

                }
            Console.WriteLine("你输入的数字为{0}。", output);
            }
            Console.WriteLine("任意键继续，q键退出：");
            if(Console.ReadKey().KeyChar == 'q') break;
        }
    }
}