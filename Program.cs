using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public enum Yonler
    {
        Kuzey,
        Guney,
        Dogu,
        Bati
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Haritanın Boyutunu Giriniz");
            int boyut = int.Parse(Console.ReadLine());
            Rover baslangic = new Rover();
            baslangic.X = 0;
            baslangic.Y = 0;
            baslangic.Yon = Yonler.Guney;

            Rover rover = new Rover();
            rover.X = baslangic.X;
            rover.Y = baslangic.Y;
            rover.Yon = baslangic.Yon;

            Console.WriteLine("Komutunuzu Giriniz");
            string komut = Console.ReadLine();
            for (int i = 0; i < komut.Length; i++)
            {
                if (komut[i]=='L')
                {
                    if (rover.Yon == Yonler.Dogu)
                        rover.Yon = Yonler.Kuzey;
                    else if (rover.Yon == Yonler.Bati)
                        rover.Yon = Yonler.Guney;
                    else if (rover.Yon == Yonler.Guney)
                        rover.Yon = Yonler.Dogu;
                    else if (rover.Yon == Yonler.Kuzey)
                        rover.Yon = Yonler.Bati;                                                   
                }
                else if (komut[i]=='R')
                {
                    if (rover.Yon == Yonler.Dogu)
                        rover.Yon = Yonler.Guney;
                    else if (rover.Yon == Yonler.Bati)
                        rover.Yon = Yonler.Kuzey;
                    else if (rover.Yon == Yonler.Guney)
                        rover.Yon = Yonler.Bati;
                    else if (rover.Yon == Yonler.Kuzey)
                        rover.Yon = Yonler.Dogu;
                }
                else if (komut[i]=='M')
                {
                    if (rover.Yon==Yonler.Dogu)
                    {
                        rover.X++;
                        if (rover.X>boyut)
                        {
                            Console.WriteLine("Rover Belirtilen Harita Boyutunun Dışına Çıktı");
                            break;
                        }
                    }
                    else if (rover.Yon==Yonler.Bati)
                    {
                        rover.X--;
                        if (rover.X<0)
                        {
                            Console.WriteLine("Rover Belirtilen Harita Boyutunun Dışına Çıktı");
                            break;
                        }
                    }
                    else if (rover.Yon==Yonler.Guney)
                    {
                        rover.Y--;
                        if (rover.Y<0)
                        {
                            Console.WriteLine("Rover Belirtilen Harita Boyutunun Dışına Çıktı");
                            break;
                        }
                    }
                    else if (rover.Yon==Yonler.Kuzey)
                    {
                        rover.Y++;
                        if (rover.Y>boyut)
                        {
                            Console.WriteLine("Rover Belirtilen Harita Boyutunun Dışına Çıktı");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Yanlış Bir Komut Girdiniz");
                    break;
                }

            }
            if (rover.X>=0&&rover.Y>=0&&rover.X<=boyut&&rover.Y<=boyut)
            {
                Console.WriteLine("Son Konum:X:"+rover.X+"Y:"+rover.Y+"Yön:"+rover.Yon);
            }
            Console.ReadLine();
        }
    }
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Yonler Yon { get; set; }
    }
}
