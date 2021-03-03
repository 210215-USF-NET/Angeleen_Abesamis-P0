using System;
using System.Collections.Generic;
using System.Text;
using BeautyStoreBL;

namespace BeautyStoreAppUI
{
    public class Admin : IBeautyStoreMenu
    {
        IBeautyStoreBL repo;
        public Admin(IBeautyStoreBL _repo)
        {
            repo = _repo;
        }

    public void Start()
        {
            Console.WriteLine("Admin Menu");
            Console.WriteLine("Options:");
            Console.WriteLine("[0] Store Location");
            Console.WriteLine("[1] Go Back");
        }
    }
}
