using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class BasicBlockChain
    {
        public IList<BasicBlock> CreateChain { set; get; }

        public BasicBlockChain(bool validChain)
        {
            InitChain();
            FirstBlock();
        }

        public BasicBlock FirstBlock()
        {
            return new BasicBlock(DateTime.Now, null, "{}");
        }
        public void AddFirstBlock()
        {
            CreateChain.Add(FirstBlock());
        }
        public BasicBlock getRecentBlock()
        {
            return CreateChain[CreateChain.Count - 1];
        }
        public void InitChain()
        {
            CreateChain = new List<BasicBlock>();
        }

        public void AddBlock(BasicBlock block)
        {

            if (isValid() ==true)
            {
                BasicBlock mostRecentBlock = getRecentBlock();
                block.Index = mostRecentBlock.Index + 1;
                block.PreviousHash = mostRecentBlock.Hash;
                block.Hash = block.CalcHash();

                block.Mine(3);
                
                CreateChain.Add(block);
            }
           
        }

        public bool isValid()
        {
            for (int i = 1; i < CreateChain.Count; i++)
            {
                BasicBlock currentB = CreateChain[i];
                BasicBlock previousB = CreateChain[i - 1];
                if (currentB.Hash != currentB.CalcHash())
                {
                    return false;
                }
                if (currentB.PreviousHash!=previousB.Hash)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
