using System;

class Program{

    static void Main(){

        string encriptedMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        string decodedMessage = DecodeMessage(encriptedMessage);

        Console.WriteLine("Mensagem Decodificada: " + decodedMessage);

        string translatedMessage = TranslateMessage(decodedMessage);

        Console.WriteLine("Mensagem Traduzida: " + translatedMessage);
    }
    static string DecodeMessage(string encriptedMessage){

        string[] binArray = encriptedMessage.Split(' ');
        string decodedMessage = "";

        foreach (string bin in binArray){
            int number = Convert.ToInt32(bin, 2);

            number = InvertLastBits(number);

            number = ChangeBits(number);

            string decodedBin = Convert.ToString(number, 2).PadLeft(8, '0');

            decodedMessage += decodedBin + " ";
        }

        return decodedMessage.Trim();
    }

    static int InvertLastBits(int number){
        int mold = 3;

        int lastBits = number & mold;
        lastBits = number ^ mold;

        number = number & (~mold);
        number = number | lastBits;

        return number;
    }

    static int ChangeBits(int number){
        int firstMold = 240;
        int secondMold = 15;

        int firtBits = (number & firstMold) >> 4;
        int secondBits = (number & secondMold) << 4;

        number = (number & (~firstMold)) | secondBits;
        number = (number & (~secondMold)) | firtBits;

        return number;
    }

    static string TranslateMessage(string decodedMessage){
        string[] binArray = decodedMessage.Split(' ');
        string translatedMessage = "";

        foreach (string bin in binArray){
            int number = Convert.ToInt32(bin, 2);
            char character = Convert.ToChar(number);
            translatedMessage += character;
        }
        
        return translatedMessage;
    }
}