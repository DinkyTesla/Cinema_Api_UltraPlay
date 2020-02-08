﻿using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Projection;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Domain.NewProjection
{
    public class NewProjectionRoomValidation : INewProjection
    {
        private readonly IRoomRepository roomRepo;
        private readonly INewProjection newProj;

        public NewProjectionRoomValidation(IRoomRepository roomRepo, INewProjection newProj)
        {
            this.roomRepo = roomRepo;
            this.newProj = newProj;
        }

        public NewSummary New(IProjectionCreation proj)
        {
            IRoom room = roomRepo.GetById(proj.RoomId);

            if (room == null)
            {
                return new NewSummary(false, $"Room with id {proj.RoomId} does not exist");
            }

            return newProj.New(proj);
        }
    }
}