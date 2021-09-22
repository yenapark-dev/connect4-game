using System;
namespace ConnectFour
{
    interface GameCommand
    {
        public void execute();
        public void load();
    }
}
