// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroProgressbar.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a metro-style progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("ProgressChanged")]
	[Description("This is a control that executes the functions of progress bar.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ProgressBar))]
    [Designer(typeof(ZeroitMetroProgressbarDesigner))]
    public class ZeroitMetroProgressbar : Control
	{

        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The orientation
        /// </summary>
        private System.Windows.Forms.Orientation _Orientation;

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum;

        /// <summary>
        /// The progress color
        /// </summary>
        private Color _ProgressColor;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _gradientColor;

        /// <summary>
        /// The draw border
        /// </summary>
        private bool _DrawBorder;

        /// <summary>
        /// The show value as text
        /// </summary>
        private bool _ShowValueAsText;

        /// <summary>
        /// The use gradient
        /// </summary>
        private bool _UseGradient;

        /// <summary>
        /// The special symbol
        /// </summary>
        private string _SpecialSymbol;

        /// <summary>
        /// The is round
        /// </summary>
        private bool _IsRound;

        /// <summary>
        /// The rounding arc
        /// </summary>
        private int _RoundingArc;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to enable automatic style.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to enable automatic style.")]
        public bool AutoStyle
        {
            get
            {
                return this._AutoStyle;
            }
            set
            {
                if (this._AutoStyle != value)
                {
                    this._AutoStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance")]
        [Description("Sets the color of the border.")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                if (value != this._BorderColor)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <value>The context menu strip.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the default color.
        /// </summary>
        /// <value>The default color.</value>
        [Category("Appearance")]
        [Description("Sets the default color.")]
        public Color DefaultColor
        {
            get
            {
                return this._DefaultColor;
            }
            set
            {
                if (value != this._DefaultColor)
                {
                    this._DefaultColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw border.
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        [Category("Appereance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw border.")]
        public bool DrawBorder
        {
            get
            {
                return this._DrawBorder;
            }
            set
            {
                if (this._DrawBorder != value)
                {
                    this._DrawBorder = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the gradient.
        /// </summary>
        /// <value>The color of the gradient.</value>
        [Category("Appearance")]
        [Description("Sets the color of the gradient.")]
        public Color GradientColor
        {
            get
            {
                return this._gradientColor;
            }
            set
            {
                if (value != this._gradientColor)
                {
                    this._gradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is rounded.
        /// </summary>
        /// <value><c>true</c> if this control is rounded; otherwise, <c>false</c>.</value>
        [Category("Appereance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether this control is rounded.")]
        public bool IsRound
        {
            get
            {
                return this._IsRound;
            }
            set
            {
                if (this._IsRound != value)
                {
                    this._IsRound = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Data")]
        [DefaultValue(100)]
        [Description("Sets the maximum value.")]
        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                if (value != this._Maximum)
                {
                    this._Maximum = value;
                    if (this._Value > this.Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the orientation.")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this._Orientation;
            }
            set
            {
                if (value != this._Orientation)
                {
                    int height = this.Height;
                    this.Height = this.Width;
                    this.Width = height;
                    this._Orientation = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        [Category("Appearance")]
        [Description("Sets the color of the progress.")]
        public Color ProgressColor
        {
            get
            {
                return this._ProgressColor;
            }
            set
            {
                if (value != this._ProgressColor)
                {
                    this._ProgressColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.RightToLeft RightToLeft
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the rounding arc.
        /// </summary>
        /// <value>The rounding arc.</value>
        [Browsable(true)]
        [Category("Appereance")]
        [Description("Sets the rounding arc.")]
        public int RoundingArc
        {
            get
            {
                return this._RoundingArc;
            }
            set
            {
                if (this._RoundingArc != value)
                {
                    this._RoundingArc = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show value as text.
        /// </summary>
        /// <value><c>true</c> if show value as text; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to show value as text.")]
        public bool ShowValueAsText
        {
            get
            {
                return this._ShowValueAsText;
            }
            set
            {
                if (value != this._ShowValueAsText)
                {
                    this._ShowValueAsText = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the special symbol.
        /// </summary>
        /// <value>The special symbol.</value>
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Sets the special symbol.")]
        public string SpecialSymbol
        {
            get
            {
                return this._SpecialSymbol;
            }
            set
            {
                if (Operators.CompareString(value, this._SpecialSymbol, false) != 0)
                {
                    this._SpecialSymbol = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the style.")]
        [RefreshProperties(RefreshProperties.All)]
        public Design.Style Style
        {
            get
            {
                return this._Style;
            }
            set
            {
                if (value != this._Style)
                {
                    this._Style = value;
                    switch (value)
                    {
                        case Design.Style.Light:
                            {
                                this._ProgressColor = Design.MetroColors.AccentBlue;
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._gradientColor = Design.MetroColors.ChangeColorBrightness(this._ProgressColor, -0.2f);
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._ProgressColor = Design.MetroColors.AccentBlue;
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._gradientColor = Design.MetroColors.ChangeColorBrightness(this._ProgressColor, -0.2f);
                                this.ForeColor = Design.MetroColors.DarkFont;
                                break;
                            }
                        default:
                            {
                                this._AutoStyle = false;
                                break;
                            }
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient.
        /// </summary>
        /// <value><c>true</c> if use gradient; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to use gradient.")]
        public bool UseGradient
        {
            get
            {
                return this._UseGradient;
            }
            set
            {
                if (value != this._UseGradient)
                {
                    this._UseGradient = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Data")]
        [DefaultValue(50)]
        [Description("Sets the initial value.")]
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (value != this._Value)
                {
                    if (value <= this._Maximum)
                    {
                        this._Value = value;
                    }
                    else
                    {
                        this._Value = this._Maximum;
                    }
                    ZeroitMetroProgressbar.ProgressChangedEventHandler progressChangedEventHandler = this.ProgressChanged;
                    if (progressChangedEventHandler != null)
                    {
                        progressChangedEventHandler(this, this._Value);
                    }
                    this.Invalidate();
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroProgressbar" /> class.
        /// </summary>
        public ZeroitMetroProgressbar()
		{
			this._Style = Design.Style.Light;
			this._Orientation = System.Windows.Forms.Orientation.Horizontal;
			this._Value = 50;
			this._Maximum = 100;
			this._ProgressColor = Design.MetroColors.AccentBlue;
			this._DefaultColor = Design.MetroColors.LightDefault;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._gradientColor = Design.MetroColors.ChangeColorBrightness(this._ProgressColor, -0.2f);
			this._DrawBorder = true;
			this._ShowValueAsText = false;
			this._UseGradient = true;
			this._SpecialSymbol = "%";
			this._IsRound = false;
			this._RoundingArc = this.Height;
			this._AutoStyle = true;
			this.Size = new System.Drawing.Size(200, 25);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
		}


        /// <summary>
        /// Gets the progress.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <returns>System.Int32.</returns>
        private int GetProgress(System.Windows.Forms.Orientation orientation)
		{
			int num;
			num = (orientation != System.Windows.Forms.Orientation.Horizontal ? checked(checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)(checked(this.Height - 2)))) + 1) : checked(checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)(checked(this.Width - 2)))) + 1));
			return num;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e)
		{
			if (this.FindForm() is ZeroitMetroForm)
			{
				if (this._AutoStyle)
				{
					this.Style = ((ZeroitMetroForm)this.FindForm()).Style;
					this.Invalidate();
				}
			}
			base.OnBackColorChanged(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rectangle;
			Graphics graphics = e.Graphics;
			if (!this._IsRound)
			{
				graphics.Clear(this._DefaultColor);
			}
			else
			{
				using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					Design.Drawing.FillRoundedPath(graphics, solidBrush, rectangle, this._RoundingArc, true, true, true, true);
				}
			}
			Point point = new Point(0, checked((int)Math.Round((double)this.Height / 2)));
			Point point1 = new Point(this.Width, checked((int)Math.Round((double)this.Height / 2)));
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point1, this._ProgressColor, this._gradientColor);
			if (this._Orientation == System.Windows.Forms.Orientation.Vertical)
			{
				point1 = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
				point = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
				linearGradientBrush = new LinearGradientBrush(point1, point, this._ProgressColor, this._gradientColor);
			}
			using (linearGradientBrush)
			{
				if (!this._UseGradient)
				{
					Color[] colorArray = new Color[] { this._ProgressColor, this._ProgressColor };
					linearGradientBrush.LinearColors = colorArray;
				}
				int progress = this.GetProgress(this._Orientation);
				if (progress > 0)
				{
					if (!this._IsRound)
					{
						switch (this._Orientation)
						{
							case System.Windows.Forms.Orientation.Horizontal:
							{
								rectangle = new Rectangle(0, 0, progress, checked(this.Height - 1));
								graphics.FillRectangle(linearGradientBrush, rectangle);
								break;
							}
							case System.Windows.Forms.Orientation.Vertical:
							{
								rectangle = new Rectangle(0, 1, this.Width, progress);
								graphics.FillRectangle(linearGradientBrush, rectangle);
								break;
							}
						}
					}
					else
					{
						switch (this._Orientation)
						{
							case System.Windows.Forms.Orientation.Horizontal:
							{
								rectangle = new Rectangle(0, 0, progress, checked(this.Height - 1));
								Design.Drawing.FillRoundedPath(graphics, linearGradientBrush, rectangle, this._RoundingArc, true, true, true, true);
								break;
							}
							case System.Windows.Forms.Orientation.Vertical:
							{
								rectangle = new Rectangle(0, 1, this.Width, progress);
								Design.Drawing.FillRoundedPath(graphics, linearGradientBrush, rectangle, this._RoundingArc, true, true, true, true);
								break;
							}
						}
					}
				}
			}
			if (this._DrawBorder)
			{
				using (Pen pen = new Pen(this._BorderColor))
				{
					if (!this._IsRound)
					{
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						graphics.DrawRectangle(pen, rectangle);
					}
					else
					{
						Color color = pen.Color;
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						Design.Drawing.DrawRoundedPath(graphics, color, 1f, rectangle, this._RoundingArc, true, true, true, true);
					}
				}
			}
			if (this._ShowValueAsText)
			{
				StringFormat stringFormat = new StringFormat()
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				};
				using (StringFormat stringFormat1 = stringFormat)
				{
					using (SolidBrush solidBrush1 = new SolidBrush(Design.MetroColors.GetCorrectForeColor(this._Style, this.ForeColor, this.Enabled)))
					{
						string str = string.Concat(this._Value.ToString(), this._SpecialSymbol);
						System.Drawing.Font font = this.Font;
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						graphics.DrawString(str, font, solidBrush1, rectangle, stringFormat1);
					}
				}
			}
			linearGradientBrush.Dispose();
			base.OnPaint(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
		{
			if (this.DesignMode)
			{
				this._RoundingArc = this.Height;
			}
			base.OnResize(e);
		}

        /// <summary>
        /// Occurs when [progress changed].
        /// </summary>
        public event ZeroitMetroProgressbar.ProgressChangedEventHandler ProgressChanged;

        /// <summary>
        /// Delegate ProgressChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="Value">The value.</param>
        public delegate void ProgressChangedEventHandler(object sender, int Value);
	}

}