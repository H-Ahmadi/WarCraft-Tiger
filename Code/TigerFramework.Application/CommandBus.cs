﻿using System;
using TigerFramework.Core;

namespace TigerFramework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceLocator _serviceLocator;
        public CommandBus(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;
        }

        public void Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandlerDecorator<T>>();
            handler.Handle(command);
            _serviceLocator.Release(handler);
        }
    }
}