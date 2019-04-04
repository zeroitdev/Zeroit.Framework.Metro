// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroSwitch.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering metro-style switch.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("CheckedChanged")]
	[Description("This is a implements a metro switch")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroSwitch), "ZeroitMetroSwitch.bmp")]
    [Designer(typeof(ZeroitMetroSwitchDesigner))]
    public class ZeroitMetroSwitch : Control
	{
        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The check color
        /// </summary>
        private Color _CheckColor;

        /// <summary>
        /// The switch color
        /// </summary>
        private Color _SwitchColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The switch style
        /// </summary>
        private ZeroitMetroSwitch.MetroSwitchStyle _SwitchStyle;

        /// <summary>
        /// The switch width
        /// </summary>
        private int _SwitchWidth;

        /// <summary>
        /// The rail width
        /// </summary>
        private int _RailWidth;

        /// <summary>
        /// The on off text
        /// </summary>
        private string _OnOffText;

        /// <summary>
        /// The on text
        /// </summary>
        private string _OnText;

        /// <summary>
        /// The off text
        /// </summary>
        private string _OffText;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;
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
                if (this._BorderColor != value)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the check.
        /// </summary>
        /// <value>The color of the check.</value>
        [Category("Appearance")]
        [Description("Sets the color of the check.")]
        public Color CheckColor
        {
            get
            {
                return this._CheckColor;
            }
            set
            {
                if (this._CheckColor != value)
                {
                    this._CheckColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroSwitch" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether this control is checked.")]
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                //if (value != this._Checked)
                //{
                //    this._Checked = value;
                //    this.Invalidate();
                //}
                this._Checked = value;
                this.CheckChanged(this, EventArgs.Empty);
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
                if (this._DefaultColor != value)
                {
                    this._DefaultColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color when hovered.
        /// </summary>
        /// <value>The color of the hover.</value>
        [Category("Appearance")]
        [Description("Sets the color when hovered.")]
        public Color HoverColor
        {
            get
            {
                return this._HoverColor;
            }
            set
            {
                if (this._HoverColor != value)
                {
                    this._HoverColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the on/off text.
        /// </summary>
        /// <value>The on off text.</value>
        [Category("Appearance")]
        [DefaultValue("OFF|ON")]
        [Description("Sets the on/off text")]
        public string OnOffText
        {
            get
            {
                return this._OnOffText;
            }
            set
            {
                if (Operators.CompareString(value, this._OnOffText, false) != 0)
                {
                    if (this._OnOffText.Contains("|"))
                    {
                        this._OnOffText = value;
                        string str = this._OnOffText;
                        char[] chrArray = new char[] { '|' };
                        this._OnText = str.Split(chrArray)[1];
                        string str1 = this._OnOffText;
                        chrArray = new char[] { '|' };
                        this._OffText = str1.Split(chrArray)[0];
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
        [DefaultValue(10)]
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
                                if (this._SwitchStyle != ZeroitMetroSwitch.MetroSwitchStyle.OnOff)
                                {
                                    this._DefaultColor = Design.MetroColors.LightSwitchRail;
                                }
                                else
                                {
                                    this._DefaultColor = Design.MetroColors.LightDefault;
                                }
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._CheckColor = Design.MetroColors.AccentBlue;
                                this._SwitchColor = Design.MetroColors.LightDefault;
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._SwitchColor = Design.MetroColors.DarkDefault;
                                this._DefaultColor = Design.MetroColors.DarkHover;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._CheckColor = Design.MetroColors.AccentBlue;
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
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
        /// Gets or sets the color of the switch.
        /// </summary>
        /// <value>The color of the switch.</value>
        [Category("Appearance")]
        [Description("Sets the color of the switch.")]
        public Color SwitchColor
        {
            get
            {
                return this._SwitchColor;
            }
            set
            {
                if (this._SwitchColor != value)
                {
                    this._SwitchColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the switch style.
        /// </summary>
        /// <value>The switch style.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the switch style.")]
        public ZeroitMetroSwitch.MetroSwitchStyle SwitchStyle
        {
            get
            {
                return this._SwitchStyle;
            }
            set
            {
                if (value != this._SwitchStyle)
                {
                    if (value == ZeroitMetroSwitch.MetroSwitchStyle.Round)
                    {
                        this.Size = new System.Drawing.Size(30, 19);
                    }
                    this._SwitchStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the switch.
        /// </summary>
        /// <value>The width of the switch.</value>
        [Category("Appearance")]
        [DefaultValue(15)]
        [Description("Sets the width of the switch.")]
        public int SwitchWidth
        {
            get
            {
                return this._SwitchWidth;
            }
            set
            {
                if (value != this._SwitchWidth)
                {
                    this._SwitchWidth = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroSwitch" /> class.
        /// </summary>
        public ZeroitMetroSwitch()
		{
			this._Style = Design.Style.Light;
			this._Checked = false;
			this._DefaultColor = Design.MetroColors.LightSwitchRail;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._CheckColor = Design.MetroColors.AccentBlue;
			this._SwitchColor = Design.MetroColors.LightDefault;
			this._HoverColor = Design.MetroColors.AccentLightBlue;
			this._SwitchStyle = ZeroitMetroSwitch.MetroSwitchStyle.Round;
			this._SwitchWidth = 15;
			this._RailWidth = 10;
			this._OnOffText = "OFF|ON";
			this._OnText = "ON";
			this._OffText = "OFF";
			this._AutoStyle = true;
			this._MouseState = Helpers.MouseState.None;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			this.BackColor = Color.Transparent;
		}


        /// <summary>
        /// Draws the switch.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="switchstyle">The switchstyle.</param>
        protected void DrawSwitch(Graphics g, ZeroitMetroSwitch.MetroSwitchStyle switchstyle)
		{
			Rectangle rectangle;
			Rectangle rectangle1;
			Rectangle rectangle2;
			Rectangle rectangle3;
			Rectangle rectangle4;
			switch (switchstyle)
			{
				case ZeroitMetroSwitch.MetroSwitchStyle.Round:
				{
					using (SolidBrush solidBrush = new SolidBrush((this._Checked ? this._DefaultColor : this._CheckColor)))
					{
						rectangle1 = new Rectangle(0, 1, checked(this.Width - 2), 16);
						Design.Drawing.FillRoundedPath(g, solidBrush, rectangle1, 16, true, true, true, true);
						if (this._Checked)
						{
							rectangle1 = new Rectangle(checked(this.Width - 19), 0, 18, 18);
							rectangle2 = rectangle1;
						}
						else
						{
							rectangle = new Rectangle(0, 0, 18, 18);
							rectangle2 = rectangle;
						}
						Rectangle rectangle5 = rectangle2;
						solidBrush.Color = this._SwitchColor;
						g.FillEllipse(solidBrush, rectangle5);
						using (Pen pen = new Pen(this._BorderColor))
						{
							if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
							{
								pen.Color = this._HoverColor;
							}
							g.DrawEllipse(pen, rectangle5);
						}
					}
					break;
				}
				case ZeroitMetroSwitch.MetroSwitchStyle.Rectangular:
				{
					using (SolidBrush solidBrush1 = new SolidBrush(this._DefaultColor))
					{
						if (!this._Checked)
						{
							rectangle = new Rectangle(this._SwitchWidth, checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._RailWidth / 2))) - 1), checked(this.Width - this._SwitchWidth), checked(this._RailWidth + 1));
							rectangle3 = rectangle;
						}
						else
						{
							rectangle1 = new Rectangle(0, checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._RailWidth / 2))) - 1), checked(this.Width - this._SwitchWidth), checked(this._RailWidth + 1));
							rectangle3 = rectangle1;
						}
						Rectangle rectangle6 = rectangle3;
						solidBrush1.Color = (this._Checked ? this._DefaultColor : this._CheckColor);
						g.FillRectangle(solidBrush1, rectangle6);
						if (!this._Checked)
						{
							rectangle1 = new Rectangle(0, 0, this._SwitchWidth, checked(this.Height - 1));
							rectangle4 = rectangle1;
						}
						else
						{
							rectangle = new Rectangle(checked(this.Width - this._SwitchWidth), 0, this._SwitchWidth, this.Height);
							rectangle4 = rectangle;
						}
						rectangle6 = rectangle4;
						solidBrush1.Color = this._SwitchColor;
						g.FillRectangle(solidBrush1, rectangle6);
						using (Pen pen1 = new Pen(this._BorderColor))
						{
							if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
							{
								pen1.Color = this._HoverColor;
							}
							rectangle1 = new Rectangle(rectangle6.X, rectangle6.Y, checked(rectangle6.Width - 1), checked(rectangle6.Height - 1));
							g.DrawRectangle(pen1, rectangle1);
						}
					}
					break;
				}
				case ZeroitMetroSwitch.MetroSwitchStyle.OnOff:
				{
					Color color = Design.MetroColors.ChangeColorBrightness(this._DefaultColor, -0.4f);
					using (SolidBrush solidBrush2 = new SolidBrush((this._Checked ? color : this._DefaultColor)))
					{
						using (Pen pen2 = new Pen(this._BorderColor))
						{
							rectangle1 = new Rectangle(checked((int)Math.Round((double)this.Width / 2)), 0, checked((int)Math.Round((double)this.Width / 2)), checked(this.Height - 1));
							g.FillRectangle(solidBrush2, rectangle1);
							solidBrush2.Color = (this._Checked ? this._DefaultColor : color);
							rectangle1 = new Rectangle(0, 0, checked((int)Math.Round((double)this.Width / 2)), checked(this.Height - 1));
							g.FillRectangle(solidBrush2, rectangle1);
							rectangle1 = new Rectangle(checked((int)Math.Round((double)this.Width / 2)), 0, checked((int)Math.Round((double)this.Width / 2)), checked(this.Height - 1));
							g.DrawRectangle(pen2, rectangle1);
							rectangle1 = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
							g.DrawRectangle(pen2, rectangle1);
						}
						color = Design.MetroColors.ChangeColorBrightness(this.ForeColor, -0.4f);
						solidBrush2.Color = (this._Checked ? color : this._CheckColor);
						if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
						{
							solidBrush2.Color = (this._Checked ? solidBrush2.Color : this._HoverColor);
						}
						StringFormat stringFormat = new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						};
						using (StringFormat stringFormat1 = stringFormat)
						{
							string str = this._OnText;
							System.Drawing.Font font = this.Font;
							rectangle1 = new Rectangle(checked((int)Math.Round((double)this.Width / 2)), 0, checked((int)Math.Round((double)this.Width / 2)), this.Height);
							g.DrawString(str, font, solidBrush2, rectangle1, stringFormat1);
							solidBrush2.Color = (this._Checked ? this._CheckColor : color);
							if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
							{
								solidBrush2.Color = (this._Checked ? this._HoverColor : solidBrush2.Color);
							}
							string str1 = this._OffText;
							System.Drawing.Font font1 = this.Font;
							rectangle1 = new Rectangle(0, 0, checked((int)Math.Round((double)this.Width / 2)), this.Height);
							g.DrawString(str1, font1, solidBrush2, rectangle1, stringFormat1);
						}
					}
					break;
				}
			}
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
		{
            #region Old Code
            //         //this._Checked ^= 1;
            //         this._Checked = true;
            //         //Checked = true;
            //         ZeroitMetroSwitch.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChanged;
            //if (checkedChangedEventHandler != null)
            //{
            //	checkedChangedEventHandler(this, this._Checked);
            //} 
            #endregion

		    _Checked = !_Checked;
		    if (checkedChanged != null)
		    {
		        checkedChanged(this, EventArgs.Empty);
		    }

            this.Invalidate();
			base.OnClick(e);
		}

        #region Event Creation

        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.CheckChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The checked changed
        /// </summary>
        private CheckedChangedEventHandler checkedChanged;

        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>

        public event CheckedChangedEventHandler CheckedChanged
	    {
	        add
	        {
	            this.checkedChanged = this.checkedChanged + value;
	        }
	        remove
	        {
	            this.checkedChanged = this.checkedChanged - value;
	        }
	    }

        /// <summary>
        /// Checks the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void CheckChanged(object sender, EventArgs e)
	    {
	        if (this.checkedChanged == null)
	            return;
	        this.checkedChanged((object)this, e);
	    }

        #endregion

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
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			this._MouseState = Helpers.MouseState.Pressed;
			this.Invalidate();
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
		    
		    Checked = !Checked;
		    Focus();
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
			switch (this._SwitchStyle)
			{
				case ZeroitMetroSwitch.MetroSwitchStyle.Round:
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					this.DrawSwitch(graphics, ZeroitMetroSwitch.MetroSwitchStyle.Round);
					break;
				}
				case ZeroitMetroSwitch.MetroSwitchStyle.Rectangular:
				{
					this.DrawSwitch(graphics, ZeroitMetroSwitch.MetroSwitchStyle.Rectangular);
					break;
				}
				case ZeroitMetroSwitch.MetroSwitchStyle.OnOff:
				{
					this.DrawSwitch(graphics, ZeroitMetroSwitch.MetroSwitchStyle.OnOff);
					break;
				}
			}
			base.OnPaint(e);
		}

        //public event ZeroitMetroSwitch.CheckedChangedEventHandler CheckedChanged;

        //public delegate void CheckedChangedEventHandler(object sender, bool isChecked);

        /// <summary>
        /// Enum MetroSwitchStyle
        /// </summary>
        public enum MetroSwitchStyle
		{
            /// <summary>
            /// The round
            /// </summary>
            Round,
            /// <summary>
            /// The rectangular
            /// </summary>
            Rectangular,
            /// <summary>
            /// The on off
            /// </summary>
            OnOff
        }
	}
    
}