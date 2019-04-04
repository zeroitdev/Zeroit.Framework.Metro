// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTrackbar.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a metro-style trackbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("Scroll")]
	[Description("A control for rendering a metro-style tracker.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(TrackBar))]
    [Designer(typeof(ZeroitMetroTrackbarDesigner))]
    public class ZeroitMetroTrackbar : Control
	{

        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The is scrolling
        /// </summary>
        private int _IsScrolling;

        /// <summary>
        /// The SND slider position
        /// </summary>
        private int _SndSliderPos;

        /// <summary>
        /// The slider position
        /// </summary>
        private int _SliderPos;

        /// <summary>
        /// The slider style
        /// </summary>
        private ZeroitMetroTrackbar.MetroSliderStyle _SliderStyle;

        /// <summary>
        /// The single slider
        /// </summary>
        private bool _SingleSlider;

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;

        /// <summary>
        /// The second value
        /// </summary>
        private int _SecondValue;

        /// <summary>
        /// The rail width
        /// </summary>
        private int _RailWidth;

        /// <summary>
        /// The slider width
        /// </summary>
        private int _SliderWidth;

        /// <summary>
        /// The use gradient
        /// </summary>
        private bool _UseGradient;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum;

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;

        /// <summary>
        /// The left color
        /// </summary>
        private Color _LeftColor;

        /// <summary>
        /// The right color
        /// </summary>
        private Color _RightColor;

        /// <summary>
        /// The slider color
        /// </summary>
        private Color _SliderColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The region color
        /// </summary>
        private Color _RegionColor;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _GradientColor;

        /// <summary>
        /// The rounding arc
        /// </summary>
        private int _RoundingArc;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to enable/disable automatic style.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to enable/disable automatic style.")]
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
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.Font Font
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient.</value>
        [Category("Appearance")]
        [Description("Sets the gradient color.")]
        public Color GradientColor
        {
            get
            {
                return this._GradientColor;
            }
            set
            {
                if (value != this._GradientColor)
                {
                    this._GradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the control when hovered.
        /// </summary>
        /// <value>The color of the hover.</value>
        [Category("Appearance")]
        [Description("Sets the color of the control when hovered.")]
        public Color HoverColor
        {
            get
            {
                return this._HoverColor;
            }
            set
            {
                if (value != this._HoverColor)
                {
                    this._HoverColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the left color.
        /// </summary>
        /// <value>The left color.</value>
        [Category("Appearance")]
        [Description("Die linke Farbe des Steuerelements.")]
        public Color LeftColor
        {
            get
            {
                return this._LeftColor;
            }
            set
            {
                if (value != this._LeftColor)
                {
                    this._LeftColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Data")]
        [DefaultValue(100)]
        [Description("Sets the maximum.")]
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
                    if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    if (this._Minimum < this._Maximum)
                    {
                        this._Maximum = value;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Data")]
        [DefaultValue(0)]
        [Description("Sets the minimum value.")]
        public int Minimum
        {
            get
            {
                return this._Minimum;
            }
            set
            {
                if (value != this._Minimum)
                {
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    if (this._Minimum <= this._Maximum)
                    {
                        this._Minimum = value;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the rail.
        /// </summary>
        /// <value>The width of the rail.</value>
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("Sets the width of the rail.")]
        public int RailWidth
        {
            get
            {
                return this._RailWidth;
            }
            set
            {
                if (value != this._RailWidth)
                {
                    this._RailWidth = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the region.
        /// </summary>
        /// <value>The color of the region.</value>
        [Category("Appearance")]
        [Description("Sets the color of the region.")]
        public Color RegionColor
        {
            get
            {
                return this._RegionColor;
            }
            set
            {
                if (value != this._RegionColor)
                {
                    this._RegionColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the right color.
        /// </summary>
        /// <value>The color of the right.</value>
        [Category("Appearance")]
        [Description("Sets the right color.")]
        public Color RightColor
        {
            get
            {
                return this._RightColor;
            }
            set
            {
                if (value != this._RightColor)
                {
                    this._RightColor = value;
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
        [DefaultValue(5)]
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
        /// Gets or sets the second value.
        /// </summary>
        /// <value>The second value.</value>
        [Category("Data")]
        [DefaultValue(30)]
        [Description("Sets the second value.")]
        public int SecondValue
        {
            get
            {
                return this._SecondValue;
            }
            set
            {
                if (value != this._Value)
                {
                    if (this._SecondValue < this._Minimum)
                    {
                        this._SecondValue = this._Minimum;
                    }
                    else if (this._SecondValue > this._Maximum)
                    {
                        this._SecondValue = this._Maximum;
                    }
                    else if (!(!this._SingleSlider & this._SecondValue > this._Value))
                    {
                        this._SecondValue = value;
                    }
                    else
                    {
                        this._SecondValue = this._Value;
                    }
                    this._SndSliderPos = checked((int)Math.Round((double)((float)((float)((double)(checked(this._SecondValue - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum))) * (float)(checked(this.Width - this._SliderWidth))))));
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the selected region.
        /// </summary>
        /// <value>The selected region.</value>
        [Category("Data")]
        [Description("Gets the selected region.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ZeroitMetroTrackbar.TrackbarRegion SelectedRegion
        {
            get
            {
                ZeroitMetroTrackbar.TrackbarRegion trackbarRegion;
                ZeroitMetroTrackbar.TrackbarRegion trackbarRegion1;
                if (this._SingleSlider)
                {
                    trackbarRegion1 = new ZeroitMetroTrackbar.TrackbarRegion(this._Value, this._Value);
                    trackbarRegion = trackbarRegion1;
                }
                else
                {
                    trackbarRegion1 = new ZeroitMetroTrackbar.TrackbarRegion(this._SndSliderPos, this._Value);
                    trackbarRegion = trackbarRegion1;
                }
                return trackbarRegion;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether single slider is enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if [single slider]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether single slider is enabled/disabled.")]
        public bool SingleSlider
        {
            get
            {
                return this._SingleSlider;
            }
            set
            {
                if (value != this._SingleSlider)
                {
                    this._SingleSlider = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the slider.
        /// </summary>
        /// <value>The color of the slider.</value>
        [Category("Appearance")]
        [Description("Sets the color of the slider.")]
        public Color SliderColor
        {
            get
            {
                return this._SliderColor;
            }
            set
            {
                if (value != this._SliderColor)
                {
                    this._SliderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the slider style.
        /// </summary>
        /// <value>The slider style.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the slider style.")]
        public ZeroitMetroTrackbar.MetroSliderStyle SliderStyle
        {
            get
            {
                return this._SliderStyle;
            }
            set
            {
                if (value != this._SliderStyle)
                {
                    this._SliderStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the slider.
        /// </summary>
        /// <value>The width of the slider.</value>
        [Category("Appearance")]
        [DefaultValue(10)]
        [Description("Sets the width of the slider.")]
        public int SliderWidth
        {
            get
            {
                return this._SliderWidth;
            }
            set
            {
                if (value != this._SliderWidth)
                {
                    this._SliderWidth = value;
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
                                this._LeftColor = Design.MetroColors.AccentBlue;
                                this._RightColor = Design.MetroColors.LightSwitchRail;
                                this._SliderColor = Design.MetroColors.LightDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
                                this._GradientColor = Design.MetroColors.ChangeColorBrightness(this._LeftColor, -0.2f);
                                this._RegionColor = Design.MetroColors.AccentLightBlue;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._LeftColor = Design.MetroColors.AccentBlue;
                                this._RightColor = Design.MetroColors.DarkHover;
                                this._SliderColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
                                this._GradientColor = Design.MetroColors.ChangeColorBrightness(this._LeftColor, -0.2f);
                                this._RegionColor = Design.MetroColors.AccentLightBlue;
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
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Data")]
        [DefaultValue(50)]
        [Description("Sets the value.")]
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
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    else if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    else if (!(!this._SingleSlider & this._Value < this._SecondValue))
                    {
                        this._Value = value;
                    }
                    else
                    {
                        this._Value = this._SecondValue;
                    }
                    this._SliderPos = checked((int)Math.Round((double)((float)((float)((double)(checked(this._Value - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum))) * (float)(checked(this.Width - this._SliderWidth))))));
                    this.Invalidate();
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTrackbar" /> class.
        /// </summary>
        public ZeroitMetroTrackbar()
		{
			this._Style = Design.Style.Light;
			this._IsScrolling = 0;
			this._SndSliderPos = 10;
			this._SliderPos = 0;
			this._SliderStyle = ZeroitMetroTrackbar.MetroSliderStyle.Rectangular;
			this._SingleSlider = true;
			this._Value = 50;
			this._SecondValue = 30;
			this._RailWidth = 5;
			this._SliderWidth = 10;
			this._UseGradient = true;
			this._Maximum = 100;
			this._Minimum = 0;
			this._LeftColor = Design.MetroColors.AccentBlue;
			this._RightColor = Design.MetroColors.LightSwitchRail;
			this._SliderColor = Design.MetroColors.LightDefault;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._HoverColor = Design.MetroColors.AccentLightBlue;
			this._RegionColor = Design.MetroColors.AccentLightBlue;
			this._GradientColor = Design.MetroColors.ChangeColorBrightness(this._LeftColor, -0.2f);
			this._RoundingArc = 5;
			this._MouseState = Helpers.MouseState.None;
			this._AutoStyle = true;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			this.BackColor = Color.Transparent;
		}


        /// <summary>
        /// Moves the slider.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void MoveSlider(MouseEventArgs e)
		{
			ZeroitMetroTrackbar.ScrollEventHandler scrollEventHandler;
			if (this._IsScrolling == 1)
			{
				if (!this._SingleSlider)
				{
					this._SliderPos = checked(e.X - this.SliderWidth / 2);
					if (this._SliderPos < this._SndSliderPos)
					{
						this._SliderPos = this._SndSliderPos;
					}
					if (this._SliderPos > checked(this.Width - this.SliderWidth))
					{
						this._SliderPos = checked(this.Width - this.SliderWidth);
					}
					this._Value = checked(Convert.ToInt32((double)this._SliderPos / (double)(checked(this.Width - this.SliderWidth)) * (double)(checked(this._Maximum - this._Minimum))) + this._Minimum);
				}
				else
				{
					this._SliderPos = checked(e.X - this._SliderWidth / 2);
					if (this._SliderPos < 0)
					{
						this._SliderPos = 0;
					}
					if (this._SliderPos > checked(this.Width - this._SliderWidth))
					{
						this._SliderPos = checked(this.Width - this._SliderWidth);
					}
					this._Value = checked(Convert.ToInt32((double)this._SliderPos / (double)(checked(this.Width - this._SliderWidth)) * (double)(checked(this._Maximum - this._Minimum))) + this._Minimum);
				}
				scrollEventHandler = this.Scroll;
				if (scrollEventHandler != null)
				{
					scrollEventHandler(this, new ZeroitMetroTrackbar.TrackbarEventArgs(true, this.Value));
				}
			}
			else if (this._IsScrolling == 2)
			{
				this._SndSliderPos = checked(e.X - this.SliderWidth / 2);
				if (this._SndSliderPos < 0)
				{
					this._SndSliderPos = 0;
				}
				if (this._SndSliderPos > this._SliderPos)
				{
					this._SndSliderPos = this._SliderPos;
				}
				this._SecondValue = checked(Convert.ToInt32((double)this._SndSliderPos / (double)(checked(this.Width - this.SliderWidth)) * (double)(checked(this._Maximum - this._Minimum))) + this._Minimum);
				scrollEventHandler = this.Scroll;
				if (scrollEventHandler != null)
				{
					scrollEventHandler(this, new ZeroitMetroTrackbar.TrackbarEventArgs(false, this._SecondValue));
				}
			}
			this.Invalidate();
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			this.Invalidate();
			base.OnGotFocus(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.None;
			this.Invalidate();
			base.OnLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.None;
			this.Invalidate();
			base.OnLostFocus(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
		{
			this.MoveSlider(e);
			base.OnMouseClick(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			bool flag;
			this._MouseState = Helpers.MouseState.Pressed;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (!this._SingleSlider)
				{
					if (e.X >= this._SliderPos && e.X < checked(this._SliderPos + this.SliderWidth))
					{
						if ((this._SliderPos == checked(this.Width - this.SliderWidth) ? this._SliderPos <= checked(this._SndSliderPos + this.SliderWidth) : false))
						{
							goto Label1;
						}
						flag = true;
						goto Label1;
					}
				Label1:
					flag = false;
					if (flag)
					{
						this._IsScrolling = 1;
					}
					else if ((e.X < this._SndSliderPos || e.X >= checked(this._SndSliderPos + this.SliderWidth) ? false : true))
					{
						this._IsScrolling = 2;
					}
				}
				else
				{
					this._IsScrolling = 1;
				}
			}
			base.OnMouseDown(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			this.Invalidate();
			base.OnMouseEnter(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.None;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
		{
			this.MoveSlider(e);
			base.OnMouseMove(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this._IsScrolling = 0;
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
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			Point point = new Point(0, checked((int)Math.Round((double)this.Height / 2)));
			Point point1 = new Point(this.Width, checked((int)Math.Round((double)this.Height / 2)));
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point1, this._LeftColor, this._GradientColor))
			{
				Rectangle rectangle = new Rectangle(0, checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._RailWidth / 2))) - 1), this._SliderPos, this._RailWidth);
				graphics.FillRectangle(linearGradientBrush, rectangle);
				Color[] colorArray = new Color[] { this._RightColor, this._RightColor };
				linearGradientBrush.LinearColors = colorArray;
				rectangle = new Rectangle(checked(this._SliderPos + this._SliderWidth), checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._RailWidth / 2))) - 1), checked(checked(this.Width - this._SliderWidth) + this._SliderWidth), this._RailWidth);
				graphics.FillRectangle(linearGradientBrush, rectangle);
				if (!this._SingleSlider)
				{
					colorArray = new Color[] { this._RegionColor, this._RegionColor };
					linearGradientBrush.LinearColors = colorArray;
					rectangle = new Rectangle(checked(checked(this._SndSliderPos + this.SliderWidth) - 1), checked((int)Math.Round((double)(checked(this.Height - this._RailWidth)) / 2)), checked(this._SliderPos - this._SndSliderPos), this._RailWidth);
					graphics.FillRectangle(linearGradientBrush, rectangle);
				}
				colorArray = new Color[] { this._SliderColor, this._SliderColor };
				linearGradientBrush.LinearColors = colorArray;
				using (Pen pen = new Pen(this._BorderColor))
				{
					if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
					{
						pen.Color = this._HoverColor;
					}
					switch (this._SliderStyle)
					{
						case ZeroitMetroTrackbar.MetroSliderStyle.Rectangular:
						{
							rectangle = new Rectangle(this._SliderPos, 0, this._SliderWidth, this.Height);
							graphics.FillRectangle(linearGradientBrush, rectangle);
							rectangle = new Rectangle(this._SliderPos, 0, checked(this._SliderWidth - 1), checked(this.Height - 1));
							graphics.DrawRectangle(pen, rectangle);
							if (!this._SingleSlider)
							{
								rectangle = new Rectangle(this._SndSliderPos, 0, this._SliderWidth, this.Height);
								graphics.FillRectangle(linearGradientBrush, rectangle);
								rectangle = new Rectangle(this._SndSliderPos, 0, checked(this._SliderWidth - 1), checked(this.Height - 1));
								graphics.DrawRectangle(pen, rectangle);
							}
							break;
						}
						case ZeroitMetroTrackbar.MetroSliderStyle.Round:
						{
							graphics.SmoothingMode = SmoothingMode.AntiAlias;
							rectangle = new Rectangle(this._SliderPos, checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._SliderWidth / 2))), this._SliderWidth, this._SliderWidth);
							graphics.FillEllipse(linearGradientBrush, rectangle);
							rectangle = new Rectangle(this._SliderPos, checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._SliderWidth / 2))), checked(this._SliderWidth - 1), checked(this._SliderWidth - 1));
							graphics.DrawEllipse(pen, rectangle);
							if (!this._SingleSlider)
							{
								rectangle = new Rectangle(this._SndSliderPos, checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._SliderWidth / 2))), this._SliderWidth, this._SliderWidth);
								graphics.FillEllipse(linearGradientBrush, rectangle);
								rectangle = new Rectangle(this._SndSliderPos, checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._SliderWidth / 2))), checked(this._SliderWidth - 1), checked(this._SliderWidth - 1));
								graphics.DrawEllipse(pen, rectangle);
							}
							break;
						}
						case ZeroitMetroTrackbar.MetroSliderStyle.RoundedRectangle:
						{
							graphics.SmoothingMode = SmoothingMode.AntiAlias;
							rectangle = new Rectangle(this._SliderPos, 0, this._SliderWidth, checked(this.Height - 1));
							Design.Drawing.FillRoundedPath(graphics, linearGradientBrush, rectangle, this._RoundingArc, true, true, true, true);
							Color color = pen.Color;
							rectangle = new Rectangle(this._SliderPos, 0, this._SliderWidth, checked(this.Height - 1));
							Design.Drawing.DrawRoundedPath(graphics, color, 1f, rectangle, this._RoundingArc, true, true, true, true);
							if (!this._SingleSlider)
							{
								rectangle = new Rectangle(this._SndSliderPos, 0, this._SliderWidth, checked(this.Height - 1));
								Design.Drawing.FillRoundedPath(graphics, linearGradientBrush, rectangle, this._RoundingArc, true, true, true, true);
								Color color1 = pen.Color;
								rectangle = new Rectangle(this._SndSliderPos, 0, this._SliderWidth, checked(this.Height - 1));
								Design.Drawing.DrawRoundedPath(graphics, color1, 1f, rectangle, this._RoundingArc, true, true, true, true);
							}
							break;
						}
					}
				}
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
		{
			this.SetSliderPos();
			base.OnSizeChanged(e);
		}

        /// <summary>
        /// Sets the slider position.
        /// </summary>
        private void SetSliderPos()
		{
			this._SliderPos = Convert.ToInt32((double)(checked(this._Value - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum)) * (double)(checked(this.Width - this._SliderWidth)));
			if (!this._SingleSlider)
			{
				this._SndSliderPos = Convert.ToInt32((double)(checked(this._SecondValue - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum)) * (double)(checked(this.Width - this._SliderWidth)));
			}
			this.Invalidate();
		}

        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        public event ZeroitMetroTrackbar.ScrollEventHandler Scroll;

        /// <summary>
        /// Enum MetroSliderStyle
        /// </summary>
        public enum MetroSliderStyle
		{
            /// <summary>
            /// The rectangular
            /// </summary>
            Rectangular,
            /// <summary>
            /// The round
            /// </summary>
            Round,
            /// <summary>
            /// The rounded rectangle
            /// </summary>
            RoundedRectangle
        }

        /// <summary>
        /// Delegate ScrollEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ZeroitMetroTrackbar.TrackbarEventArgs"/> instance containing the event data.</param>
        public delegate void ScrollEventHandler(object sender, ZeroitMetroTrackbar.TrackbarEventArgs e);

        /// <summary>
        /// Class TrackbarEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class TrackbarEventArgs : EventArgs
		{
            /// <summary>
            /// The is primary slider
            /// </summary>
            private bool _IsPrimarySlider;

            /// <summary>
            /// The slider value
            /// </summary>
            private int _SliderValue;

            /// <summary>
            /// Gets a value indicating whether this instance is primary slider.
            /// </summary>
            /// <value><c>true</c> if this instance is primary slider; otherwise, <c>false</c>.</value>
            public bool IsPrimarySlider
			{
				get
				{
					return this._IsPrimarySlider;
				}
			}

            /// <summary>
            /// Gets the slider value.
            /// </summary>
            /// <value>The slider value.</value>
            public int SliderValue
			{
				get
				{
					return this._SliderValue;
				}
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="TrackbarEventArgs"/> class.
            /// </summary>
            /// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
            /// <param name="value">The value.</param>
            public TrackbarEventArgs(bool isPrimary, int value)
			{
				this._IsPrimarySlider = isPrimary;
				this._SliderValue = value;
			}
		}

        /// <summary>
        /// Struct TrackbarRegion
        /// </summary>
        public struct TrackbarRegion
		{
            /// <summary>
            /// The startpoint
            /// </summary>
            private int _Startpoint;

            /// <summary>
            /// The endpoint
            /// </summary>
            private int _Endpoint;

            /// <summary>
            /// Gets the endpoint.
            /// </summary>
            /// <value>The endpoint.</value>
            [Category("Data")]
			[Description("Der Endpunkt der ausgewählten Region.")]
			public int Endpoint
			{
				get
				{
					return this._Endpoint;
				}
			}

            /// <summary>
            /// Gets the startpoint.
            /// </summary>
            /// <value>The startpoint.</value>
            [Category("Data")]
			[Description("Der Startpunkt der ausgewählten Region.")]
			public int Startpoint
			{
				get
				{
					return this._Startpoint;
				}
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="TrackbarRegion"/> struct.
            /// </summary>
            /// <param name="start">The start.</param>
            /// <param name="end">The end.</param>
            public TrackbarRegion(int start, int end)
			{
				this = new ZeroitMetroTrackbar.TrackbarRegion()
				{
					_Startpoint = start,
					_Endpoint = end
				};
			}
		}
	}
}