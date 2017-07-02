﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgilFood.Controllers.Resource;
using AgilFood.Core.Models;

namespace AgilFood.Core
{
    public interface ICardapioRepository
    {
        Task<List<Cardapio>> GetCardapios();
        Task<Cardapio> GetCardapio(int id, bool includeRelated = true);
        void Add(Cardapio cardapio);
        void Remove(Cardapio cardapio);
    }
}
