using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace CardFlipTest
{
    public enum FlipCardSide
    {
        Top,
        Bottom
    }

    public class FlipCardView : ContentView
    {
        private View _top;
        private View _bottom;
        private FlipCardSide _side;
        private Frame _frame;


        public View Top
        {
            get { return _top; }
            set
            {
                if (_top != value)
                {
                    _top = value;
                    UpdateContent();
                }
            }
        }

        public View Bottom
        {
            get { return _bottom; }
            set
            {
                if (_bottom != value)
                {
                    _bottom = value;
                    UpdateContent();
                }
            }
        }

        public FlipCardSide Side
        {
            get { return _side; }

            set { SetSide(value, animate: false); }
        }

        public FlipCardView()
        {
            _frame = new Frame();
            Content = _frame;
        }

        public async Task SetSide(FlipCardSide side, bool animate)
        {
            if (_side == side)
            {
                return;
            }

            _side = side;
            if (!animate)
            {
                UpdateContent();
            }
            else
            {
                await _frame.RotateYTo(-90);
                UpdateContent();
                _frame.RotationY = 90;
                await _frame.RotateYTo(0);
            }
        }

        private void UpdateContent()
        {
            var newView = GetViewForSide(Side);
            _frame.Content = newView;
        }

        public Task Flip(bool animate)
        {
            return SetSide(GetOppositeSide(Side), animate);
        }

        private View GetViewForSide(FlipCardSide side)
        {
            switch (side)
            {
                case FlipCardSide.Top:
                    return Top;
                case FlipCardSide.Bottom:
                    return Bottom;
                default:
                    throw new ArgumentException("Unexpected side");
            }
        }

        private static FlipCardSide GetOppositeSide(FlipCardSide side)
        {
            switch (side)
            {
                case FlipCardSide.Top:
                    return FlipCardSide.Bottom;
                case FlipCardSide.Bottom:
                    return FlipCardSide.Top;
                default:
                    throw new ArgumentException("Unexpected side");
            }
        }
    }
}


