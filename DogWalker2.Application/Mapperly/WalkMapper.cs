﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogWalker2.Application.Dogs.DTOs;
using DogWalker2.Domain;
using Riok.Mapperly.Abstractions;
using DogWalker2.Domain.Walks;

namespace DogWalker2.Application.Mapperly
{
    [Mapper]
    public partial class WalkMapper
    {
        public partial Walk WalkDTOtoWalk(WalkDTO walkDTO);
    }
}
