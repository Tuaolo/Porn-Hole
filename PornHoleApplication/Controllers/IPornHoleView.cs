using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PornHole.Controllers
{
    public interface IPornHoleView
    {
        void setController(PornHoleController controller);
        void setVisible(bool isVisible);
        void setImage(string imagePath);
        void setControlsToPlaying();
        void setControlsToPaused();
        void showFromButtons();
    }
}
