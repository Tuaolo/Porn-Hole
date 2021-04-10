using System.Drawing;

namespace PornHole.Controllers
{
    public interface IFullScreenImageView
    {
        void setController(PornHoleController controller);
        void setVisible(bool isVisible);
        void setImage(string imagePath);
        void setControlsToPlaying();
        void setControlsToPaused();
        void showFromButtons();
        void openAtLocation(Point location);
    }
}
