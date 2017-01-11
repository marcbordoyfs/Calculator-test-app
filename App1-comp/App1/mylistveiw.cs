using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MarcCalculator;

namespace App1
{
    class mylistveiw : BaseAdapter<TextButton>
    {
        private List<TextButton> items;
        private Context context;
        string[] splitnums = { "", "", "" }; // num1 num2 char
        int calcmode = 0;

        int somenumber = 0;

        TextView[] screens = new TextView[8];
        TextView modescreen;

        Button Clearall;
        Button clear;
        Button back;
        Button divide;
        Button seven;
        Button eight;
        Button nine;
        Button x;
        Button four;
        Button five;
        Button six;
        Button sub;
        Button one;
        Button two;
        Button three;
        Button plus;
        Button dot;
        Button zero;
        Button equal;
        Button mode;
        Button pre;
        public mylistveiw(Context cont, List<TextButton> item)
        {
            items = item;
            context = cont;
        }
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override TextButton this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
                row = LayoutInflater.From(context).Inflate(Resource.Layout.notmain, null, false);

            screens[0] = row.FindViewById<TextView>(Resource.Id.textView1);
            screens[0].Text = items[position].screen;
            screens[1] = row.FindViewById<TextView>(Resource.Id.textView2);
            screens[1].Text = items[position].screen;
            screens[2] = row.FindViewById<TextView>(Resource.Id.textView3);
            screens[2].Text = items[position].screen;
            screens[3] = row.FindViewById<TextView>(Resource.Id.textView4);
            screens[3].Text = items[position].screen;
            screens[4] = row.FindViewById<TextView>(Resource.Id.textView27);
            screens[4].Text = items[position].screen;
            screens[5] = row.FindViewById<TextView>(Resource.Id.textView32);
            screens[5].Text = items[position].screen;
            screens[6] = row.FindViewById<TextView>(Resource.Id.textView36);
            screens[6].Text = items[position].screen;
            screens[7] = row.FindViewById<TextView>(Resource.Id.textView37);
            screens[7].Text = items[position].screen;

            Clearall = row.FindViewById<Button>(Resource.Id.textClearall);
            Clearall.Text = items[position].clearallname;
            Clearall.Click += Clearall_Click;

            clear = row.FindViewById<Button>(Resource.Id.textclear);
            clear.Text = items[position].clearname;
            clear.Click += Clear_Click;

            back = row.FindViewById<Button>(Resource.Id.textback);
            back.Text = items[position].backname;
            back.Click += backspace_Click;

            divide = row.FindViewById<Button>(Resource.Id.textdiv);
            divide.Text = items[position].dividename;
            divide.Click += whensymbolpressed;

            seven = row.FindViewById<Button>(Resource.Id.text7);
            seven.Text = items[position].seven;
            seven.Click += whenbuttonpressed;
            eight = row.FindViewById<Button>(Resource.Id.text8);
            eight.Text = items[position].eight;
            eight.Click += whenbuttonpressed;
            nine = row.FindViewById<Button>(Resource.Id.text9);
            nine.Text = items[position].nine;
            nine.Click += whenbuttonpressed;

            x = row.FindViewById<Button>(Resource.Id.textmult);
            x.Text = items[position].mult;
            x.Click += whensymbolpressed;

            four = row.FindViewById<Button>(Resource.Id.text4);
            four.Text = items[position].four;
            four.Click += whenbuttonpressed;
            five = row.FindViewById<Button>(Resource.Id.text5);
            five.Text = items[position].five;
            five.Click += whenbuttonpressed;
            six = row.FindViewById<Button>(Resource.Id.text6);
            six.Text = items[position].six;
            six.Click += whenbuttonpressed;

            sub = row.FindViewById<Button>(Resource.Id.textsub);
            sub.Text = items[position].sub;
            sub.Click += whensymbolpressed;

            one = row.FindViewById<Button>(Resource.Id.text1);
            one.Text = items[position].one;
            one.Click += whenbuttonpressed;
            two = row.FindViewById<Button>(Resource.Id.text2);
            two.Text = items[position].two;
            two.Click += whenbuttonpressed;
            three = row.FindViewById<Button>(Resource.Id.text3);
            three.Text = items[position].three;
            three.Click += whenbuttonpressed;

            plus = row.FindViewById<Button>(Resource.Id.textplus);
            plus.Text = items[position].plus;
            plus.Click += whensymbolpressed;

            dot = row.FindViewById<Button>(Resource.Id.textdot);
            dot.Text = items[position].dot;
            dot.Click += whensymbolpressed;

            zero = row.FindViewById<Button>(Resource.Id.text0);
            zero.Text = items[position].zero;
            zero.Click += whenbuttonpressed;
            equal = row.FindViewById<Button>(Resource.Id.textequ);
            equal.Text = items[position].equal;
            equal.Click += Equales_Click;
            pre = row.FindViewById<Button>(Resource.Id.textpre);
            pre.Text = "%";
            pre.Click += whensymbolpressed;

            mode = row.FindViewById<Button>(Resource.Id.Modebutton);
            mode.Text = items[position].mode;
            mode.Click += Mode_Click;
           
            modescreen = row.FindViewById<TextView>(Resource.Id.textView19);
            modescreen.Text = "DEC";


            return row;
        }

        private void Mode_Click(object sender, EventArgs e)
        {
            calcmode++;
            if (calcmode == 4)
                calcmode = 0;
            switch (calcmode)
            {
                case 0:
                    modescreen.Text = "DEC";
                    break;
                case 1:
                    modescreen.Text = "BIN";
                    break;
                case 2:
                    modescreen.Text = "HEX";
                    break;
                case 3:
                    modescreen.Text = "OCT";
                    break;
            }
            splitnums[1] = screens[3].Text;
            double two;

            if (double.TryParse(splitnums[1], out two))
            {

                string bits = "";
                int num = 4;

                switch (calcmode)
                {

                    case 0:
                        // "DEC"
                        screens[4].Text = "";
                        screens[5].Text = "";
                        screens[6].Text = "";
                        screens[7].Text = two.ToString();
                        break;
                    case 1:
                        // "BIN"
                        bits = Convert.ToString((int)two, 2);
                        int o;
                        somenumber = (int)two;
                        if (bits.Length < 16)
                        {
                            screens[4].Text = "";
                            screens[5].Text = "";
                            screens[6].Text = "";
                            screens[7].Text = "";
                            o = 16 - bits.Length;
                            for (int i = 0; i < o; i++)
                            {
                                string letter = "0";
                                letter += bits;
                                bits = letter;
                            }
                            for (int i = 0; i < 16; i++)
                            {
                                if (i == 4 || i == 8 || i == 12)
                                    num++;

                                screens[num].Text += bits[i];
                            }
                        }
                        else
                        {
                            o = bits.Length - 16;
                            for (int i = 0; i < 16; i++)
                            {
                                if (i == 4 || i == 8 || i == 12)
                                    num++;

                                screens[num].Text += bits[o];
                                o++;
                            }
                        }

                        break;
                    case 2:
                        // "HEX"
                        screens[5].Text = "";
                        screens[4].Text = "";
                        screens[6].Text = "Ox";
                        bits += Convert.ToString((int)two, 16);
                        screens[7].Text = bits;
                        break;
                    case 3:
                        // "OCT"
                        screens[5].Text = "";
                        screens[4].Text = "";
                        screens[6].Text = "Oct";
                        bits = Convert.ToString((int)two, 8);
                        screens[7].Text = bits;
                        break;
                }

            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (calcmode != 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    screens[i].Text = "";
                }
            }
            else
                screens[3].Text = "";
        }

        private void Clearall_Click(object sender, EventArgs e)
        {
            splitnums[0] = "";
            splitnums[1] = "";
            splitnums[2] = "";
            for (int i = 0; i < 8; i++)
            {
                screens[i].Text = "";
            }
        }
        private void backspace_Click(object sender, EventArgs e)
        {
            if (screens[3].Text != "")
            {
                screens[3].Text = screens[3].Text.Remove(screens[3].Length()-1);
            }
        }

        private void whensymbolpressed(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            if (screens[3].Text == "")
            {
                if (btn.Text == "-")
                {
                    screens[3].Text += btn.Text;
                }

            }
            else if (btn.Text != "%" && btn.Text != "." && (screens[3].Text[screens[3].Length() - 1] == 'x' || screens[3].Text[screens[3].Length() - 1] == '/' || screens[3].Text[screens[3].Length() - 1] == '+' || screens[3].Text[screens[3].Length() - 1] != '-' ))
            {
                if (splitnums[2] == "")
                {
                    splitnums[2] = btn.Text;
                    screens[2].Text = btn.Text;
                    splitnums[0] = screens[3].Text;
                    screens[1].Text = screens[3].Text;
                    screens[3].Text = "";
                }
                else
                {
                    //mite not work
                    splitnums[1] = screens[3].Text;
                    equales();
                    splitnums[0] = screens[3].Text;
                }

            }
            else if (btn.Text == "." && screens[3].Text[screens[3].Length() - 1] != '.')
            {
                screens[3].Text += btn.Text;
            }
            else if (screens[3].Text[screens[3].Length() - 1] != '%'|| btn.Text == "%")
            {
                double one;
                if (double.TryParse(screens[3].Text, out one))
                {
                    one = one / 100;
                    screens[3].Text = one.ToString();
                }
            }

        }

        private void whenbuttonpressed(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            screens[3].Text += btn.Text;
        }

        private void Equales_Click(object sender, EventArgs e)
        {
            splitnums[1] = screens[3].Text;
            equales();
        }

        void equales()
        {
            if (screens[3].Text == "")
            {
                return;
            }

            double one;
            double two;


            if (double.TryParse(splitnums[0], out one) && double.TryParse(splitnums[1], out two))
            {
                switch (splitnums[2])
                {
                    case "x":
                        one *= two;
                        somenumber = (int)one;
                        break;
                    case "/":
                        if (two != 0)
                        {
                            one /= two;
                            somenumber = (int)one;
                        }
                        else
                            screens[3].Text = "";
                        break;
                    case "-":
                        one -= two;
                        somenumber = (int)one;
                        break;
                    case "+":
                        one += two;
                        somenumber = (int)one;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < 8; i++)
                {
                    screens[i].Text = "";
                }
                screens[3].Text = one.ToString();
            }

            splitnums[1] = screens[3].Text;

            if (double.TryParse(splitnums[1], out two))
            {

                string bits = "";
                int num = 4;

                switch (calcmode)
                {

                    case 0:
                        // "DEC"
                        screens[4].Text = "";
                        screens[5].Text = "";
                        screens[6].Text = "";
                        screens[7].Text = two.ToString();
                        break;
                    case 1:
                        // "BIN"
                        bits = Convert.ToString((int)two, 2);
                        int o;
                        somenumber = (int)two;
                        if (bits.Length < 16)
                        {
                            screens[4].Text = "";
                            screens[5].Text = "";
                            screens[6].Text = "";
                            screens[7].Text = "";
                            o = 16 - bits.Length;
                            for (int i = 0; i < o; i++)
                            {
                                string letter = "0";
                                letter += bits;
                                bits = letter;
                            }
                            for (int i = 0; i < 16; i++)
                            {
                                if (i == 4 || i == 8 || i == 12)
                                    num++;

                                screens[num].Text += bits[i];
                            }
                        }
                        else
                        {
                            o = bits.Length - 16;
                            for (int i = 0; i < 16; i++)
                            {
                                if (i == 4 || i == 8 || i == 12)
                                    num++;

                                screens[num].Text += bits[o];
                                o++;
                            }
                        }

                        break;
                    case 2:
                        // "HEX"
                        screens[5].Text = "";
                        screens[4].Text = "";
                        screens[6].Text = "Ox";
                        bits += Convert.ToString((int)two, 16);
                        screens[7].Text = bits;
                        break;
                    case 3:
                        // "OCT"
                        screens[5].Text = "";
                        screens[4].Text = "";
                        screens[6].Text = "Oct";
                        bits = Convert.ToString((int)two, 8);
                        screens[7].Text = bits;
                        break;
                }

            }


            splitnums[0] = "";
            splitnums[1] = "";
            splitnums[2] = "";
        }




    }
}


/*
 switch (calcmode)
                {

                    case 0:
                        // "DEC"
                        screens[3].Text = one.ToString();
                        break;
                    case 1:
                        // "BIN"
                        lastnum++;
                        for (int i = 0; i < 16; i++)
                        {
                            if (lastnum - bin > 0)
                            {
                                lastnum -= bin;
                                bin /= 2;
                                bits += "1";
                            }
                            else
                            {
                                bits += "0";
                                bin /= 2;
                            }
                        }

                        for (int i = 0; i < 16; i++)
                        {
                            if (i == 4 || i == 8 || i == 12)
                                num++;

                            screens[num].Text += bits[i];
                        }
                        break;
                    case 2:
                        // "HEX"
                        lastnum++;
                        for (int i = 0; i < 16; i++)
                        {
                            if (lastnum - bin > 0)
                            {
                                lastnum -= bin;
                                bin /= 2;
                                bits += "1";
                            }
                            else
                            {
                                bits += "0";
                                bin /= 2;
                            }
                            if (i == 4 || i == 8 || i == 12)
                                num++;

                            screens[num].Text += bits[i];
                        }

                        bits = "0x";
                        for (int i = 0; i < 4; i++)
                        {
                            num = 0;
                            if (screens[i].Text[0] == '1')
                                num += 8;
                            if (screens[i].Text[1] == '1')
                                num += 4;
                            if (screens[i].Text[2] == '1')
                                num += 2;
                            if (screens[i].Text[3] == '1')
                                num += 1;

                            if (num < 10)
                                bits += num.ToString();
                            else if (num == 10)
                                bits += "A";
                            else if (num == 11)
                                bits += "B";
                            else if (num == 12)
                                bits += "C";
                            else if (num == 13)
                                bits += "D";
                            else if (num == 14)
                                bits += "E";
                            else if (num == 15)
                                bits += "F";
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            screens[i].Text = "";
                        }
                        screens[3].Text = bits;
                        break;
                    case 3:
                        // "OCT"
                        lastnum++;
                        bits = "00";
                        for (int i = 0; i < 16; i++)
                        {
                            if (lastnum - bin > 0)
                            {
                                lastnum -= bin;
                                bin /= 2;
                                bits += "1";
                            }
                            else
                            {
                                bits += "0";
                                bin /= 2;
                            }

                        }

                        string output = "";
                        for (int i = 0; i < 16;)
                        {

                            num = 0;

                            if (bits[i] == '1')
                            {
                                num += 4;
                                i++;
                            }
                            else
                                i++;
                            if (bits[i] == '1')
                            {
                                num += 2;
                                i++;
                            }
                            else
                                i++;
                            if (bits[i] == '1')
                            {
                                num += 1;
                                i++;
                            }
                            else
                                i++;

                            output += num.ToString();
                         //   Convert.ToString();
                        }

                        screens[3].Text = output;
                        break;
                }
     */
