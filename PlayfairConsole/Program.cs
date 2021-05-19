using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairConsole
{
    class Program
    {
        public static char[,] matrix = new char[5, 5];
        public static string cipher;
        public static string plaintext;

         static void Encription() {
            cipher = "";
            Console.WriteLine("Kódolni kívánt szöveg:  ");

            int p = 0;
             plaintext = Console.ReadLine();
            plaintext = plaintext.ToLower();

            string nwplain = plaintext.Replace(" ", "");
            plaintext = nwplain;

            int size = plaintext.Length;


            //Azonos betűk cseréje
            plaintext = test(size, plaintext);


            //Ha nem párosszámú betűből áll
            if (size % 2 == 1)
            {
                plaintext = plaintext + "x";
            }
            double q = (double)size / 2;
            
            int s = Convert.ToInt32(Math.Ceiling(q));
            char[,] qw = new char[s, 2];

            //I-k cseréje j-re
            for (int i = 0; i <= size - 1; i = i + 2)
            {
                if (plaintext.Substring(i, 1) == "i")
                {
                    qw[p, 0] = 'j';
                }
                else
                {
                    qw[p, 0] = Convert.ToChar(plaintext.Substring(i, 1));
                }

                if (plaintext.Substring(i + 1, 1) != null)
                {
                    if (plaintext.Substring(i + 1, 1) == "i")
                    {
                        qw[p, 1] = 'j';
                    }
                    else
                    {
                        qw[p, 1] = Convert.ToChar(plaintext.Substring(i + 1, 1));
                    }
                }
                p = p + 1;

                //Párok számát számoljuk
            }
            //Végig megyünk a párokon
            for (int i = 0; i < p; i++)
            {
                string posi = pos(qw[i, 0]);
                string[] str = posi.Split('.');
                int[] first = new int[2];
                int[] second = new int[2];
                //pár első elemének pozíciója 
                first[0] = Convert.ToInt32(str[0]);// x pozíció
                first[1] = Convert.ToInt32(str[1]);// y 
                posi = pos(qw[i, 1]);
                string[] str1 = posi.Split('.');

                //pár második elemének pozíciója
                second[0] = Convert.ToInt32(str1[0]);// x 
                second[1] = Convert.ToInt32(str1[1]);// y 

                if (first[0] == second[0])// Azonos sor esetén 
                {
                    if (first[1] == 4)
                    {
                        first[1] = -1; //- re állítjuk, hogy később ne legyen túlcsordulás
                    }
                    if (second[1] == 4)
                    {
                        second[1] = -1;
                    }
                    cipher = cipher + matrix[(first[0]), (first[1] + 1)];
                    cipher = cipher + matrix[(second[0]), (second[1] + 1)];

                }
                else if (first[1] == second[1])// azonos oszlop 
                {
                    if (first[0] == 4)
                    {
                        first[0] = -1;
                    }
                    if (second[0] == 4)
                    {
                        second[0] = -1;
                    }
                    cipher = cipher + matrix[(first[0] + 1), (first[1])];
                    cipher = cipher + matrix[(second[0] + 1), (second[1])];
                }
                else
                {
                    //Téglalap
                    cipher = cipher + matrix[first[0], second[1]];
                    cipher = cipher + matrix[second[0], first[1]];


                }
            }
            Console.Write("Kódolt szöveg:");

            Console.WriteLine(cipher.ToUpper());
            Console.ReadLine();


        }
        static void Description()
        {
            cipher = "";
            Console.WriteLine("Dekódolni kívánt szöveg:  ");

            int p = 0;
             plaintext = Console.ReadLine();
            plaintext = plaintext.ToLower();

            string nwplain = plaintext.Replace(" ", "");
            plaintext = nwplain;

            int size = plaintext.Length;


            //Azonos betűk cseréje
            plaintext = test(size, plaintext);


            

            //Ha nem párosszámú betűből áll
           /* if (size % 2 == 1)
            {
                plaintext = plaintext + "x";
            }
            */
            double q = (double)size / 2;
            //Ceiling nagyobb rész 
            int s = Convert.ToInt32(Math.Ceiling(q));
            char[,] qw = new char[s, 2];

            
            //I-k cseréje j-re
            for (int i = 0; i <= size - 1; i = i + 2)
            {
                if (plaintext.Substring(i, 1) == "i")
                {
                    qw[p, 0] = 'j';
                }
                else
                {
                    qw[p, 0] = Convert.ToChar(plaintext.Substring(i, 1));
                }

                if (plaintext.Substring(i + 1, 1) != null)
                {
                    if (plaintext.Substring(i + 1, 1) == "i")
                    {
                        qw[p, 1] = 'j';
                    }
                    else
                    {
                        qw[p, 1] = Convert.ToChar(plaintext.Substring(i + 1, 1));
                    }
                }
                p = p + 1;

                //Párok számát számoljuk
            }
            //Végig megyünk a párokon
            for (int i = 0; i < p; i++)
            {
                string posi = pos(qw[i, 0]);
                string[] str = posi.Split('.');
                int[] first = new int[2];
                int[] second = new int[2];
                //pár első elemének pozíciója 
                first[0] = Convert.ToInt32(str[0]);// x pozíció
                first[1] = Convert.ToInt32(str[1]);// y 
                posi = pos(qw[i, 1]);
                string[] str1 = posi.Split('.');

                //pár második elemének pozíciója
                second[0] = Convert.ToInt32(str1[0]);// x 
                second[1] = Convert.ToInt32(str1[1]);// y 

                if (first[0] == second[0])// Azonos sor esetén 
                {
                    if (first[1] == 0)
                    {
                        first[1] = 5; //- re állítjuk, hogy később ne legyen túlcsordulás
                    }
                    if (second[1] == 0)
                    {
                        second[1] = 5;
                    }
                    cipher = cipher + matrix[(first[0]), (first[1] - 1)];
                    cipher = cipher + matrix[(second[0]), (second[1] - 1)];

                }
                else if (first[1] == second[1])// azonos oszlop 
                {
                    if (first[0] == 0)
                    {
                        first[0] = 5;
                    }
                    if (second[0] == 0)
                    {
                        second[0] = 5;
                    }
                    cipher = cipher + matrix[(first[0] - 1), (first[1])];
                    cipher = cipher + matrix[(second[0] - 1), (second[1])];
                }
                else
                {
                    //Téglalap
                    cipher = cipher + matrix[first[0], second[1]];
                    cipher = cipher + matrix[second[0], first[1]];


                }
            }
            Console.Write("Dekódolt szöveg:");

            Console.WriteLine(cipher.ToUpper());
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.Title = "PlayFair - Oravecz Zsolt";
            while (true)
            {
                create_matrix(); // Mátrix létrehozása
                int choosed = 0;
                string menu;
                do
                {
                    choosed = 0;

                    Console.WriteLine("Írj 1-est a kódoláshoz:");
                    Console.WriteLine("Írj 2-est a dekódoláshoz: ");
                    menu = Console.ReadLine();

                } while (!(int.TryParse(menu, out choosed)));
                switch (choosed)
                {
                    case 1:
                        Encription();
                        break;
                    case 2:
                        Description();
                        break;
                    default:
                        Console.WriteLine("Invalid number.");
                        break;
                }

            }

        }// end main



        //Előállítja a mátrix elemeinek pozícióját
        //ponttal elválasztva
        static string pos(char a)
        {
            string w = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (a == matrix[i, j])
                    {
                        w = i.ToString() + "." + j.ToString();
                        break;

                    }

                }
            }
            return (w);
        }

        //Teszt metódus 
        //Páronként azonos betűk cseréjét végzi
        static string test(int size, string pt) 
        {
         

        ch:
            for (int i = 0; i < size-1 ; i = i + 2)
            {
                if (pt.Substring(i, 1) == pt.Substring(i + 1, 1))
                {
                    pt = pt.Remove(i+1,1);
                    //pt[i + 1] = "x";
                    //pt.Remove(i+1, 2);
                    pt = pt.Insert(i+1 /*+ 1*/, "x");
                    
                    goto ch;

                }

            }

            return (pt);
        }


        //Mátrix létrehozó metópdus
        static void create_matrix()
        {
            string k1 = "";
            Console.WriteLine("Írd be a kulcsszót:   ");
            string key = Console.ReadLine();
            string reference = "abcdefghjklmnopqrstuvwxyz";
            int size = key.Length;
            string[] key_array = new string[size];
            for (int i = 0; i < size; i++)
            {
                key_array[i] = key.Substring(i, 1);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        if (key_array[i] == "i")
                        {
                            key_array[i] = "j";
                        }
                        if (key_array[i] == key_array[j])
                        {

                            //Azonos karaktereket töröljük
                            key_array[j] = "1";
                        }
                    }
                }

            }
            for (int i = 0; i < size; i++)
            {
                k1 = k1 + key_array[i].ToString();
            }
            k1 = k1.Replace('i', 'j');
            //k1 = k1.Replace('1', ' ');
            k1 = k1.Replace("1", "");
            foreach (string c in key_array)
            {
                reference = reference.Replace(c, "");

            }
            int counter = 0;
            int p = 0;
            int len = k1.Length;

            //Mátrixba elemek belehelyezése
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    if (counter < size)
                    {
                        if (key_array[counter] != "" && key_array[counter] != "1")
                        {
                            matrix[i, j] = Convert.ToChar(key_array[counter]);

                            counter++;
                        }
                        else
                        {
                            counter++;
                            j--;
                        }
                    }
                    else
                    {
                        //Itt jön az abc-vel való feltöltés
                        counter++;
                        if (counter >= size)
                        {
                            matrix[i, j] = Convert.ToChar(reference.Substring(p, 1));
                            j++;
                            p++;
                        }
                        j--;
                    }
                }

            }
            Console.WriteLine("A PlayFair mátrix: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(" ");

                    Console.Write(matrix[i, j]);

                }
            }
            Console.WriteLine("");

        }
    }
}
