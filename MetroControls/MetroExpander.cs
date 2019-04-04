// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroExpander.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering an expander.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroExpander), "ZeroitMetroExpander.bmp")]
	public class ZeroitMetroExpander : Panel
	{
        #region Private Fields

        /// <summary>
        /// The current state
        /// </summary>
        private ZeroitMetroExpander.MouseState CurrentState;

        /// <summary>
        /// The expanded size
        /// </summary>
        private System.Drawing.Size _ExpandedSize;

        /// <summary>
        /// The none size
        /// </summary>
        private System.Drawing.Size _NoneSize;

        /// <summary>
        /// The state
        /// </summary>
        private ZeroitMetroExpander.eState _State;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether to draw interect area.
        /// </summary>
        /// <value><c>true</c> if draw interect area; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Category("Developing")]
        [ComVisible(false)]
        [Description("Sets a value indicating whether to draw interect area")]
        private bool DrawInterectArea
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the size to be expanded.
        /// </summary>
        /// <value>The size of the expanded.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the size to be expanded.")]
        public System.Drawing.Size ExpandedSize
        {
            get
            {
                return this._ExpandedSize;
            }
            set
            {
                this._ExpandedSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the size when not expanded.
        /// </summary>
        /// <value>The size when not expanded.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the size when not expanded.")]
        public System.Drawing.Size NoneSize
        {
            get
            {
                return this._NoneSize;
            }
            set
            {
                this._NoneSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("Sets the state.")]
        public ZeroitMetroExpander.eState State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (value != ZeroitMetroExpander.eState.Expanded)
                {
                    this.Size = this._NoneSize;
                    this._State = ZeroitMetroExpander.eState.None;
                }
                else
                {
                    this.Size = this._ExpandedSize;
                    this._State = ZeroitMetroExpander.eState.Expanded;
                }
                this._State = value;
            }
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroExpander" /> class.
        /// </summary>
        public ZeroitMetroExpander()
		{
			this.CurrentState = ZeroitMetroExpander.MouseState.None;
			this._State = ZeroitMetroExpander.eState.None;
			this.DrawInterectArea = false;
			this.Size = new System.Drawing.Size(150, 15);
			this._NoneSize = new System.Drawing.Size(150, 15);
			this._ExpandedSize = new System.Drawing.Size(300, 150);
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
		}



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			Rectangle rectangle = new Rectangle(2, 2, Width, Height);
			if (!rectangle.Contains(e.Location))
			{
				this.CurrentState = ZeroitMetroExpander.MouseState.None;
			}
			else
			{
				this.CurrentState = ZeroitMetroExpander.MouseState.Over;
			}
			this.Invalidate();
			base.OnMouseDown(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
		{
			this.CurrentState = ZeroitMetroExpander.MouseState.None;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
		{
			Rectangle rectangle = new Rectangle(checked(this.Width - 14), 2, 10, 10);
			if (!rectangle.Contains(e.Location))
			{
				this.CurrentState = ZeroitMetroExpander.MouseState.None;
			}
			else
			{
				this.CurrentState = ZeroitMetroExpander.MouseState.Over;
			}
			this.Invalidate();
			base.OnMouseMove(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
		{
			Rectangle rectangle = new Rectangle(checked(this.Width - 14), 2, 10, 10);
			if (!rectangle.Contains(e.Location))
			{
				this.CurrentState = ZeroitMetroExpander.MouseState.None;
			}
			else
			{
				if (this._State != ZeroitMetroExpander.eState.None)
				{
					this.Size = this._NoneSize;
					this._State = ZeroitMetroExpander.eState.None;
				}
				else
				{
					this.Size = this._ExpandedSize;
					this._State = ZeroitMetroExpander.eState.Expanded;
				}
				this.CurrentState = ZeroitMetroExpander.MouseState.Over;
			}
			this.Invalidate();
			base.OnMouseUp(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Point point;
			Point point1;
			Point point2;
			Point[] pointArray;
			Rectangle rectangle = new Rectangle(checked(this.Width - 14), 2, 10, 10);
			Graphics graphics = e.Graphics;
			Rectangle rectangle1 = new Rectangle(0, 5, checked(this.Width - 16), 5);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(this.BackColor);
			if (this._State != ZeroitMetroExpander.eState.None)
			{
				pointArray = new Point[3];
				point2 = new Point(checked(this.Width - 12), 8);
				pointArray[0] = point2;
				point1 = new Point(checked(this.Width - 6), 8);
				pointArray[1] = point1;
				point = new Point(checked(this.Width - 9), 5);
				pointArray[2] = point;
				Point[] pointArray1 = pointArray;
				if (this.CurrentState == ZeroitMetroExpander.MouseState.None)
				{
					Brush solidBrush = new SolidBrush(Color.FromArgb(98, 98, 98));
					graphics.FillPolygon(solidBrush, pointArray1);
					graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(98, 98, 98))), pointArray1);
				}
				else if (this.CurrentState == ZeroitMetroExpander.MouseState.Over)
				{
					graphics.FillPolygon(new SolidBrush(this.BackColor), pointArray1);
					graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(0, 164, 240))), pointArray1);
				}
			}
			else
			{
				pointArray = new Point[3];
				point = new Point(checked(this.Width - 12), 5);
				pointArray[0] = point;
				point1 = new Point(checked(this.Width - 6), 5);
				pointArray[1] = point1;
				point2 = new Point(checked(this.Width - 9), 8);
				pointArray[2] = point2;
				Point[] pointArray2 = pointArray;
				if (this.CurrentState == ZeroitMetroExpander.MouseState.None)
				{
					Brush brush = new SolidBrush(Color.FromArgb(98, 98, 98));
					graphics.FillPolygon(brush, pointArray2);
					graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(98, 98, 98))), pointArray2);
				}
				else if (this.CurrentState == ZeroitMetroExpander.MouseState.Over)
				{
					graphics.FillPolygon(new SolidBrush(this.BackColor), pointArray2);
					graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(0, 164, 240))), pointArray2);
				}
			}
			graphics.DrawImageUnscaledAndClipped(Properties.Resources.PointRow, rectangle1);
			if (this.DrawInterectArea)
			{
				graphics.DrawRectangle(Pens.Red, rectangle);
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Enum eState
        /// </summary>
        public enum eState
		{
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The expanded
            /// </summary>
            Expanded
        }

        /// <summary>
        /// Enum MouseState
        /// </summary>
        private enum MouseState
		{
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The over
            /// </summary>
            Over,
            /// <summary>
            /// Down
            /// </summary>
            Down
        }
	}
}