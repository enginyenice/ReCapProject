﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        //Id,CarId,ImagePath,Date
        public int Id { get; set; }

        public int CarID { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}