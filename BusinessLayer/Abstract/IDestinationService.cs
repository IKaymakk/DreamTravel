﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        void ChangeDestinationStatus(int id);
        float GetTotalPrice();
        float GetTotalPriceCurrentMonth();
        float GetTotalPriceJanuary();

        public List<Destination> TGetLast4Destinations();

    }
}
