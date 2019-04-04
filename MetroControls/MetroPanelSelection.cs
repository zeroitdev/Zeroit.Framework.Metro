// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroPanelSelection.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a panel selection.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [DefaultEvent("Click")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(Panel))]
    [Designer(typeof(ZeroitMetroPanelSelectionDesigner))]
    public class ZeroitMetroPanelSelection : Panel
	{

        #region Private Fields
        /// <summary>
        /// The current state
        /// </summary>
        private ZeroitMetroPanelSelection.MouseState CurrentState;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style = Design.Style.Custom;

        /// <summary>
        /// The check on click
        /// </summary>
        private bool _CheckOnClick;

        /// <summary>
        /// The draw borders
        /// </summary>
        private bool _DrawBorders;

        /// <summary>
        /// The headline
        /// </summary>
        private string _Headline;

        /// <summary>
        /// The sub text
        /// </summary>
        private string _SubText;

        /// <summary>
        /// The headline font
        /// </summary>
        private System.Drawing.Font _HeadlineFont;

        /// <summary>
        /// The sub text font
        /// </summary>
        private System.Drawing.Font _SubTextFont;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// The fore color
        /// </summary>
        private Color[] foreColor = new Color[]
	    {
	        Color.Black,
	        Color.Gray
	    };
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroPanelSelection" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("sets a value indicating whether this control is checked.")]
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to check on click.
        /// </summary>
        /// <value><c>true</c> if check on click; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to check on click.")]
        public bool CheckOnClick
        {
            get
            {
                return this._CheckOnClick;
            }
            set
            {
                this._CheckOnClick = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the color scheme.")]
        [ReadOnly(false)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ZeroitMetroPanelSelection.MainColorScheme ColorScheme
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets a value indicating whether to draw the borders.
        /// </summary>
        /// <value><c>true</c> if [draw borders]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets a value indicating whether to draw the borders.")]
        public bool DrawBorders
        {
            get
            {
                return this._DrawBorders;
            }
        }

        /// <summary>
        /// Gets or sets the headline font.
        /// </summary>
        /// <value>The headline font.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the headline font.")]
        public System.Drawing.Font HeadlineFont
        {
            get
            {
                return this._HeadlineFont;
            }
            set
            {
                this._HeadlineFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">value - null</exception>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the style.")]
        public Design.Style Style
        {
            get
            {
                return this._Style;
            }
            set
            {
                this._Style = value;
                
                switch (value)
                {
                    case Design.Style.Light:
                        this.ColorScheme.HeaderColor = Color.Silver;
                        this.ColorScheme.SubTextColor = Color.Gray;
                        this.ColorScheme._BackgroundColorNormal = Color.White;
                        this.ColorScheme._BorderColor = Color.FromArgb(0, 164, 240);
                        this.ColorScheme._BorderColorN = Color.FromArgb(98, 98, 98);
                        this.ColorScheme._BackgroundColorHover = Color.White;
                        this.ColorScheme._BackgroundColorChecked = Color.FromArgb(101, 101, 101);
                        break;
                    case Design.Style.Dark:
                        this.ColorScheme.HeaderColor = Color.Black;
                        this.ColorScheme.SubTextColor = Color.DarkSlateGray;
                        this.ColorScheme._BackgroundColorNormal = Color.FromArgb(40, 40, 40);
                        this.ColorScheme._BorderColor = Color.FromArgb(0, 164, 240);
                        this.ColorScheme._BorderColorN = Color.FromArgb(98, 98, 98);
                        this.ColorScheme._BackgroundColorHover = Color.FromArgb(40, 40, 40);
                        this.ColorScheme._BackgroundColorChecked = Color.FromArgb(21, 21, 21);
                        break;
                    case Design.Style.Custom:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the sub text font.
        /// </summary>
        /// <value>The sub text font.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the sub text font.")]
        public System.Drawing.Font SubTextFont
        {
            get
            {
                return this._SubTextFont;
            }
            set
            {
                this._SubTextFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the text headline.
        /// </summary>
        /// <value>The text headline.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the text headline.")]
        public string TextHeadline
        {
            get
            {
                return this._Headline;
            }
            set
            {
                this._Headline = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text subline.
        /// </summary>
        /// <value>The text subline.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the text subline.")]
        public string TextSubline
        {
            get
            {
                return this._SubText;
            }
            set
            {
                this._SubText = value;
                this.Invalidate();
            }
        }


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroPanelSelection" /> class.
        /// </summary>
        public ZeroitMetroPanelSelection()
		{
			this.CurrentState = ZeroitMetroPanelSelection.MouseState.None;
			
			this._CheckOnClick = true;
			this._DrawBorders = true;
			this._Headline = "Headline Text";
			this._SubText = "Sub-Text";
			this._HeadlineFont = new System.Drawing.Font("Segoe UI Light", 14f);
			this._SubTextFont = new System.Drawing.Font("Segoe UI", 9f);
			this._Checked = false;
			this.ColorScheme = new ZeroitMetroPanelSelection.MainColorScheme();
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			//this.Style = Design.Style.Light;
			this.Size = new System.Drawing.Size(275, 64);
		}


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.CheckOnClick)
			{
				if (this.Checked)
				{
					this.Checked = false;
				}
				else if (!this.Checked)
				{
					this.Checked = true;
				}
			}
			this.CurrentState = ZeroitMetroPanelSelection.MouseState.Down;
			this.Invalidate();
			base.OnMouseDown(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
		{
			this.CurrentState = ZeroitMetroPanelSelection.MouseState.Over;
			this.Invalidate();
			base.OnMouseEnter(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
		{
			this.CurrentState = ZeroitMetroPanelSelection.MouseState.None;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
		{
			this.CurrentState = ZeroitMetroPanelSelection.MouseState.Over;
			this.Invalidate();
			base.OnMouseUp(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Color color = new Color();
			Graphics graphics = e.Graphics;
			graphics.Clear(this.BackColor);
			Point point = new Point(0, 0);
			Rectangle rectangle = new Rectangle(point, this.Size);
			ColorBlend colorBlend = new ColorBlend();
			if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Down & this.Checked)
			{
				color = this.ColorScheme._BackgroundColorChecked;
			}
			else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Down & !this.Checked)
			{
				color = this.ColorScheme._BackgroundColorNormal;
			}
			else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Over & !this.Checked)
			{
				color = this.ColorScheme._BackgroundColorHover;
			}
			else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Over & this.Checked)
			{
				color = this.ColorScheme._BackgroundColorChecked;
			}
			else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.None & this.Checked)
			{
				color = this.ColorScheme._BackgroundColorChecked;
			}
			else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.None & !this.Checked)
			{
				color = this.ColorScheme._BackgroundColorNormal;
			}
			graphics.FillRectangle(new SolidBrush(color), rectangle);
			string str = this._Headline;
			System.Drawing.Font font = this._HeadlineFont;
			SolidBrush solidBrush = new SolidBrush(this.ColorScheme.HeaderColor);
			point = new Point(8, 5);
			graphics.DrawString(str, font, solidBrush, point);
			string str1 = this._SubText;
			System.Drawing.Font font1 = this._SubTextFont;
			SolidBrush solidBrush1 = new SolidBrush(this.ColorScheme.SubTextColor);
			Rectangle rectangle1 = new Rectangle(12, 35, checked(this.Width - 25), checked(this.Height - 50));
			graphics.DrawString(str1, font1, solidBrush1, rectangle1);
			if (this.DrawBorders)
			{
				if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Down)
				{
					Pen pen = new Pen(this.ColorScheme._BorderColor);
					rectangle1 = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					graphics.DrawRectangle(pen, rectangle1);
				}
				else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.None)
				{
					Pen pen1 = new Pen(this.ColorScheme._BorderColorN);
					rectangle1 = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					graphics.DrawRectangle(pen1, rectangle1);
				}
				else if (this.CurrentState == ZeroitMetroPanelSelection.MouseState.Over)
				{
					Pen pen2 = new Pen(this.ColorScheme._BorderColor);
					rectangle1 = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					graphics.DrawRectangle(pen2, rectangle1);
				}
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Class MainColorScheme.
        /// </summary>
        public class MainColorScheme
		{
            /// <summary>
            /// The border color n
            /// </summary>
            public Color _BorderColorN;

            /// <summary>
            /// The background color hover
            /// </summary>
            public Color _BackgroundColorHover;

            /// <summary>
            /// The background color checked
            /// </summary>
            public Color _BackgroundColorChecked;

            /// <summary>
            /// The background color normal
            /// </summary>
            public Color _BackgroundColorNormal;

            /// <summary>
            /// The border color
            /// </summary>
            public Color _BorderColor;

            /// <summary>
            /// Gets or sets the background color checked.
            /// </summary>
            /// <value>The background color checked.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Hintergrundfarbe bei aktivem Checked-Effekt.")]
			public Color BackgroundColorChecked
			{
				get
				{
					return this._BackgroundColorChecked;
				}
				set
				{
					this._BackgroundColorChecked = value;
				}
			}

            /// <summary>
            /// Gets or sets the background color hover.
            /// </summary>
            /// <value>The background color hover.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Hintergrundfarbe bei aktivem Hover-Effekt.")]
			public Color BackgroundColorHover
			{
				get
				{
					return this._BackgroundColorHover;
				}
				set
				{
					this._BackgroundColorHover = value;
				}
			}

            /// <summary>
            /// Gets or sets the background color normal.
            /// </summary>
            /// <value>The background color normal.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Hintergrundfarbe.")]
			public Color BackgroundColorNormal
			{
				get
				{
					return this._BackgroundColorNormal;
				}
				set
				{
					this._BackgroundColorNormal = value;
				}
			}

            /// <summary>
            /// Gets or sets the color of the effect border.
            /// </summary>
            /// <value>The color of the effect border.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Farbe für die Umrandung.")]
			public Color EffectBorderColor
			{
				get
				{
					return this._BorderColor;
				}
				set
				{
					this._BorderColor = value;
				}
			}

            /// <summary>
            /// Gets or sets the color of the normal border.
            /// </summary>
            /// <value>The color of the normal border.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Farbe der Umradung bei keinem Effekt.")]
			public Color NormalBorderColor
			{
				get
				{
					return this._BorderColorN;
				}
				set
				{
					this._BorderColorN = value;
				}
			}

            /// <summary>
            /// Gets or sets the color of the header.
            /// </summary>
            /// <value>The color of the header.</value>
            public Color HeaderColor { get; set; } = Color.Black;
            /// <summary>
            /// Gets or sets the color of the sub text.
            /// </summary>
            /// <value>The color of the sub text.</value>
            public Color SubTextColor { get; set; } = Color.DarkSlateGray;

            /// <summary>
            /// Initializes a new instance of the <see cref="MainColorScheme"/> class.
            /// </summary>
            public MainColorScheme()
			{
				this._BorderColorN = Color.FromArgb(98, 98, 98);
				this._BackgroundColorHover = Color.White;
				this._BackgroundColorChecked = Color.FromArgb(101, 101, 101);
				this._BackgroundColorNormal = Color.White;
				this._BorderColor = Color.FromArgb(0, 164, 240);
                
			}
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