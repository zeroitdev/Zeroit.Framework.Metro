// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="Animator.cs" company="Zeroit Dev Technologies">
//    This program is for creating Metro Style controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a click animation.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [Description("This is a click animation control")]
    [DesignerCategory("Code")]
    [ToolboxBitmap(typeof(ClickAnimator))]
    public class ClickAnimator : Component
    {

        #region Private Fields
        /// <summary>
        /// The click control
        /// </summary>
        private Control _ClickControl;

        /// <summary>
        /// The effect timer
        /// </summary>
        [AccessedThroughProperty("Timer")]
        private System.Windows.Forms.Timer _effectTimer;

        /// <summary>
        /// The step
        /// </summary>
        private int _Step;

        /// <summary>
        /// The speed
        /// </summary>
        private int _Speed;

        /// <summary>
        /// The start point
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// The animation color
        /// </summary>
        private Color _AnimationColor;

        /// <summary>
        /// The draw mode
        /// </summary>
        private DrawMode _drawMode = DrawMode.Circle;

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 9;
        /// <summary>
        /// The starting angle
        /// </summary>
        private int startingAngle = 90;
        /// <summary>
        /// The center width
        /// </summary>
        private int centerWidth = 18;
        /// <summary>
        /// The center
        /// </summary>
        Point center;
        #endregion

        #region Enumeration
        /// <summary>
        /// Enum representing the type of drawing animation.
        /// </summary>
        public enum DrawMode
        {
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public DrawMode Shape
        {
            get { return _drawMode; }
            set
            {
                _drawMode = value;

            }
        }

        /// <summary>
        /// Gets or sets the color of the animation.
        /// </summary>
        /// <value>The color of the animation.</value>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "120, 255, 255, 255")]
        [Description("Sets the color of the animation.")]
        public Color AnimationColor
        {
            get
            {
                return this._AnimationColor;
            }
            set
            {
                this._AnimationColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the click control.
        /// </summary>
        /// <value>The click control.</value>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("Set the control to render the animation on.")]
        public Control ClickControl
        {
            get
            {
                return this._ClickControl;
            }
            set
            {
                this.UnRegisterControl();
                this._ClickControl = value;
                this.RegisterControl();
                if (this._ClickControl != null)
                {
                    this._Speed = checked((int)Math.Round((double)this._ClickControl.Width / 10));
                }
            }
        }

        /// <summary>
        /// Gets or sets the animation timer.
        /// </summary>
        /// <value>The timer.</value>
        public virtual System.Windows.Forms.Timer Timer
        {
            [DebuggerNonUserCode]
            get
            {
                return this._effectTimer;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ClickAnimator metroAnimator = this;
                EventHandler eventHandler = new EventHandler(metroAnimator.effectTimer_Tick);
                if (this._effectTimer != null)
                {
                    this._effectTimer.Tick -= eventHandler;
                }
                this._effectTimer = value;
                if (this._effectTimer != null)
                {
                    this._effectTimer.Tick += eventHandler;
                }
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The speed.</value>
        [Browsable(true)]
        [DefaultValue(10)]
        [Description("Sets the animation speed.")]
        public int Speed
        {
            get
            {
                return this._Speed;
            }
            set
            {
                this._Speed = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickAnimator" /> class.
        /// </summary>
        public ClickAnimator()
        {
            this.Timer = new System.Windows.Forms.Timer()
            {
                Interval = 10
            };
            this._Step = 0;
            this._Speed = 10;
            this.startPoint = new Point();
            this._AnimationColor = Color.FromArgb(120, 255, 255, 255);
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Handles the Click event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void control_Click(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
            this.startPoint = this._ClickControl.PointToClient(Cursor.Position);
            this._Step = 0;
        }

        /// <summary>
        /// Handles the Paint event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void control_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            using (SolidBrush solidBrush = new SolidBrush(this._AnimationColor))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rectangle = new Rectangle(checked((int)Math.Round((double)this.startPoint.X - (double)this._Step * ((double)this._Speed / 2))), checked((int)Math.Round((double)this.startPoint.Y - (double)this._Step * ((double)this._Speed / 2))), checked(this._Step * this._Speed), checked(this._Step * this._Speed));

                center = new Point(100 / 2, 100 / 2);
                radius = _ClickControl.Width / 4;


                switch (_drawMode)
                {
                    case DrawMode.Circle:
                        graphics.FillEllipse(solidBrush, rectangle);
                        break;
                    case DrawMode.Rectangle:
                        graphics.FillRectangle(solidBrush, rectangle);
                        break;

                }


            }
            graphics = null;
        }

        /// <summary>
        /// Handles the Tick event of the effectTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void effectTimer_Tick(object sender, EventArgs e)
        {
            this._Step = checked(this._Step + 1);
            if (this._ClickControl != null)
            {
                this._ClickControl.Invalidate();
            }
            if (((double)this.startPoint.X >= (double)this._Step * ((double)this._Speed / 2) || (double)this.startPoint.Y >= (double)this._Step * ((double)this._Speed / 2) || (double)(checked(this._ClickControl.Width + this._Speed)) >= (double)this._Step * ((double)this._Speed / 2) || (double)(checked(this._ClickControl.Height + this._Speed)) >= (double)this._Step * ((double)this._Speed / 2) ? false : true))
            {
                this.Timer.Enabled = false;
                this._Step = 0;
            }
        }

        /// <summary>
        /// Registers the control.
        /// </summary>
        private void RegisterControl()
        {
            if (this._ClickControl != null)
            {
                ClickAnimator metroAnimator = this;
                this._ClickControl.Paint += new PaintEventHandler(metroAnimator.control_Paint);
                ClickAnimator metroAnimator1 = this;
                this._ClickControl.Click += new EventHandler(metroAnimator1.control_Click);
                this.SetDoubleBuffered(this._ClickControl);
            }
        }

        /// <summary>
        /// Sets the double buffered.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        private void SetDoubleBuffered(Control ctrl)
        {
            if (!SystemInformation.TerminalServerSession)
            {
                PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                property.SetValue(ctrl, true, null);
            }
        }

        /// <summary>
        /// Uns the register control.
        /// </summary>
        private void UnRegisterControl()
        {
            if (this._ClickControl != null)
            {
                ClickAnimator metroAnimator = this;
                this._ClickControl.Paint -= new PaintEventHandler(metroAnimator.control_Paint);
                ClickAnimator metroAnimator1 = this;
                this._ClickControl.Click -= new EventHandler(metroAnimator1.control_Click);
            }
        }

        #endregion

    }

}
