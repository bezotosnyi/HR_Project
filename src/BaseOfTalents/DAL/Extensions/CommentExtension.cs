﻿using DAL.DTO;
using Domain.Entities;

namespace DAL.Extensions
{
    public static class CommentExtension
    {
        public static void Update(this Comment destination, CommentDTO source)
        {
            destination.Message = source.Message;
            destination.State = source.State;
        }
    }
}
