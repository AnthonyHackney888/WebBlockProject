using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp2
{
    class BasicBlock
    {
   
        public long Index { get; set; }
        //creation of the block or when it was sent for updating purposes 
        public DateTime TimeStamp { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }

        //The contents of the block
        public string Data { get; set; }
        
        public int Nonce { get; set; }


        public BasicBlock(DateTime timeStamp, string previousHash, string data)
        {
            Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Data = Data;
            Hash = CalcHash();
        }

    

        internal string CalcHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] inBytes = Encoding.ASCII.GetBytes($"{TimeStamp}--{PreviousHash ?? ""}--{Data}--{Nonce}");
                byte[] outBytes = sha256.ComputeHash(inBytes);
                return Convert.ToBase64String(outBytes);
            }
        }

        public void Mine(int difficulty)
        {
            string hashZeros = new string('0', difficulty);
            while(Hash == null || Hash.Substring(0, difficulty) != hashZeros)
            {
                Nonce++;
                Hash = CalcHash();
            }
        }
    }
}



