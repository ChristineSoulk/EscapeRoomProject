using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ObserverManager
{
    public interface ISubscribersNotifier
    {
        void NotifySubscribersForNewRoom();
    }
}
