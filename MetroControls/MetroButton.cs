// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroButton.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{

    /// <summary>
    /// A class collection for rendering a metro-style button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("Click")]
	[Description("This is a metro style button.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(Button))]
    [Designer(typeof(ZeroitMetroButtonDesigner))]
    public class ZeroitMetroButton : Control
	{

        #region Private Fields
        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The pressed color
        /// </summary>
        private Color _PressedColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The draw borders
        /// </summary>
        private bool _DrawBorders;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The disabled color
        /// </summary>
        private Color _DisabledColor;

        /// <summary>
        /// The alignment
        /// </summary>
        private StringAlignment _alignment;

        /// <summary>
        /// The dialog result
        /// </summary>
        private System.Windows.Forms.DialogResult _DialogResult;

        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;

        /// <summary>
        /// The is round
        /// </summary>
        private bool _IsRound;

        /// <summary>
        /// The rounding arc
        /// </summary>
        private int _RoundingArc;

        /// <summary>
        /// The invert fore color
        /// </summary>
        private bool _InvertForeColor;

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
        /// Gets or sets a value indicating whether to set automatic style.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets the AutoStyle.")]
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
        [Description("This sets the border color.")]
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
        [Description("This sets the default color.")]
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
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>The dialog result.</value>
        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("This sets the dialog result.")]
        public System.Windows.Forms.DialogResult DialogResult
        {
            get
            {
                return this._DialogResult;
            }
            set
            {
                if (this._DialogResult != value)
                {
                    this._DialogResult = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled.
        /// </summary>
        /// <value>The color of the disabled.</value>
        [Category("Appearance")]
        [Description("This sets the disabled color.")]
        public new Color DisabledColor
        {
            get
            {
                return this._DisabledColor;
            }
            set
            {
                if (value != this._DisabledColor)
                {
                    this._DisabledColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw border.
        /// </summary>
        /// <value><c>true</c> if draw border; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Set to draw the border.")]
        public bool DrawBorder
        {
            get
            {
                return this._DrawBorders;
            }
            set
            {
                if (value != this._DrawBorders)
                {
                    this._DrawBorders = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        [Category("Appearance")]
        [Description("Sets the hover color.")]
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
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Sets the icon.")]
        public Image Icon
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (value != this._Image)
                {
                    this._Image = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to invert fore color.
        /// </summary>
        /// <value><c>true</c> if invert fore color; otherwise, <c>false</c>.</value>
        [Category("Appereance")]
        [DefaultValue(false)]
        [Description("Set to invert the forecolor.")]
        public bool InvertForeColor
        {
            get
            {
                return this._InvertForeColor;
            }
            set
            {
                if (this._InvertForeColor != value)
                {
                    this._InvertForeColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is rounded.
        /// </summary>
        /// <value><c>true</c> if this control is rounded; otherwise, <c>false</c>.</value>
        [Category("Appereance")]
        [DefaultValue(false)]
        [Description("Set to enable rounding of the button.")]
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
        /// Gets or sets the color of the pressed.
        /// </summary>
        /// <value>The color of the pressed.</value>
        [Category("Appearance")]
        [Description("Sets the color when the control is pressed.")]
        public Color PressedColor
        {
            get
            {
                return this._PressedColor;
            }
            set
            {
                if (value != this._PressedColor)
                {
                    this._PressedColor = value;
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
        [Description("Sets the rounding value.")]
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
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._HoverColor = Design.MetroColors.LightDefault;
                                this._PressedColor = Design.MetroColors.AccentBlue;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._DisabledColor = Design.MetroColors.LightDisabled;
                                this.ForeColor = Design.MetroColors.LightFont;
                                this._InvertForeColor = false;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._HoverColor = Design.MetroColors.DarkHover;
                                this._PressedColor = Design.MetroColors.AccentBlue;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._DisabledColor = Design.MetroColors.DarkDisabled;
                                this.ForeColor = Design.MetroColors.DarkFont;
                                this._InvertForeColor = false;
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
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category("Appearance")]
        [DefaultValue(1)]
        [Description("Sets the text alignment.")]
        public StringAlignment TextAlignment
        {
            get
            {
                return this._alignment;
            }
            set
            {
                if (value != this._alignment)
                {
                    this._alignment = value;
                    this.Invalidate();
                }
            }
        } /**/
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroButton" /> class.
        /// </summary>
        public ZeroitMetroButton()
		{
			this._DefaultColor = Design.MetroColors.LightDefault;
			this._HoverColor = Design.MetroColors.LightDefault;
			this._PressedColor = Design.MetroColors.AccentBlue;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._DrawBorders = true;
			this._Style = Design.Style.Light;
			this._DisabledColor = Design.MetroColors.LightDisabled;
			this._alignment = StringAlignment.Center;
			this._DialogResult = System.Windows.Forms.DialogResult.None;
			this._Image = null;
			this._IsRound = false;
			this._RoundingArc = 23;
			this._InvertForeColor = false;
			this._AutoStyle = true;
			this._MouseState = Helpers.MouseState.None;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.UpdateStyles();
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
		{
			if (this.FindForm() != null)
			{
				if (this.FindForm().Modal)
				{
					this.FindForm().DialogResult = this._DialogResult;
				}
			}
			base.OnMouseClick(e);
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
			this.Invalidate();
			base.OnMouseUp(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rectangle;
			Graphics graphics = e.Graphics;
			using (Pen pen = new Pen(this._DefaultColor))
			{
				Color color = this._BorderColor;
				bool flag = false;
				switch (this._MouseState)
				{
					case Helpers.MouseState.None:
					{
						pen.Color = this._DefaultColor;
						color = this._BorderColor;
						break;
					}
					case Helpers.MouseState.Over:
					{
						pen.Color = this._HoverColor;
						color = this._PressedColor;
						break;
					}
					case Helpers.MouseState.Pressed:
					{
						pen.Color = this._PressedColor;
						color = this._PressedColor;
						if ((this._Style == Design.Style.Light || this._Style == Design.Style.Dark ? false : true))
						{
							break;
						}
						flag = true;
						break;
					}
				}
				if (!this.Enabled)
				{
					pen.Color = this._DisabledColor;
				}
				if (!this._IsRound)
				{
					graphics.Clear(pen.Color);
				}
				else
				{
					using (SolidBrush solidBrush = new SolidBrush(pen.Color))
					{
						graphics.SmoothingMode = SmoothingMode.AntiAlias;
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						Design.Drawing.FillRoundedPath(graphics, solidBrush, rectangle, this._RoundingArc, true, true, true, true);
					}
				}
				pen.Color = color;
				if (this._DrawBorders)
				{
					if (!this._IsRound)
					{
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						graphics.DrawRectangle(pen, rectangle);
					}
					else
					{
						Color color1 = pen.Color;
						rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
						Design.Drawing.DrawRoundedPath(graphics, color1, 1f, rectangle, this._RoundingArc, true, true, true, true);
					}
				}
				StringFormat stringFormat = new StringFormat()
				{
					Alignment = this._alignment,
					LineAlignment = StringAlignment.Center
				};
				using (StringFormat stringFormat1 = stringFormat)
				{
					using (SolidBrush correctForeColor = new SolidBrush((flag ? Color.White : this.ForeColor)))
					{
						correctForeColor.Color = (this._InvertForeColor & this._MouseState == Helpers.MouseState.Pressed ? Design.MetroColors.InvertColor(correctForeColor.Color) : correctForeColor.Color);
						if (!this.Enabled)
						{
							correctForeColor.Color = Design.MetroColors.GetCorrectForeColor(this._Style, this.ForeColor, this.Enabled);
						}
						if (this._Image == null)
						{
							string text = this.Text;
							System.Drawing.Font font = this.Font;
							rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
							graphics.DrawString(text, font, correctForeColor, rectangle, stringFormat1);
						}
						else
						{
							Image image = this._Image;
							rectangle = new Rectangle(6, checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._Image.Height / 2))), this._Image.Width, this._Image.Height);
							graphics.DrawImage(image, rectangle);
							string str = this.Text;
							System.Drawing.Font font1 = this.Font;
							rectangle = new Rectangle(checked(12 + this._Image.Width), 0, checked(checked(this.Width - 12) - this._Image.Width), checked(this.Height - 1));
							graphics.DrawString(str, font1, correctForeColor, rectangle, stringFormat1);
						}
					}
				}
			}
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
	}


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMetroButtonDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitMetroButtonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMetroButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroButton;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic style].
        /// </summary>
        /// <value><c>true</c> if [automatic style]; otherwise, <c>false</c>.</value>
        public bool AutoStyle
        {
            get
            {
                return colUserControl.AutoStyle;
            }
            set
            {
                GetPropertyByName("AutoStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the default color.
        /// </summary>
        /// <value>The default color.</value>
        public Color DefaultColor
        {
            get
            {
                return colUserControl.DefaultColor;
            }
            set
            {
                GetPropertyByName("DefaultColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled.
        /// </summary>
        /// <value>The color of the disabled.</value>
        public new Color DisabledColor
        {
            get
            {
                return colUserControl.DisabledColor;
            }
            set
            {
                GetPropertyByName("DisabledColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get
            {
                return colUserControl.HoverColor;
            }
            set
            {
                GetPropertyByName("HoverColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pressed.
        /// </summary>
        /// <value>The color of the pressed.</value>
        public Color PressedColor
        {
            get
            {
                return colUserControl.PressedColor;
            }
            set
            {
                GetPropertyByName("PressedColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw border].
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get
            {
                return colUserControl.DrawBorder;
            }
            set
            {
                GetPropertyByName("DrawBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [invert fore color].
        /// </summary>
        /// <value><c>true</c> if [invert fore color]; otherwise, <c>false</c>.</value>
        public bool InvertForeColor
        {
            get
            {
                return colUserControl.InvertForeColor;
            }
            set
            {
                GetPropertyByName("InvertForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is round.
        /// </summary>
        /// <value><c>true</c> if this instance is round; otherwise, <c>false</c>.</value>
        public bool IsRound
        {
            get
            {
                return colUserControl.IsRound;
            }
            set
            {
                GetPropertyByName("IsRound").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the rounding arc.
        /// </summary>
        /// <value>The rounding arc.</value>
        public int RoundingArc
        {
            get
            {
                return colUserControl.RoundingArc;
            }
            set
            {
                GetPropertyByName("RoundingArc").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public Design.Style Style
        {
            get
            {
                return colUserControl.Style;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get
            {
                return colUserControl.TextAlignment;
            }
            set
            {
                GetPropertyByName("TextAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public new string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("AutoStyle",
                "Auto Style", "Appearance",
                "Automatically style the button."));
            
            items.Add(new DesignerActionPropertyItem("DrawBorder",
                "Draw Border", "Appearance",
                "Draws a border around the button."));

            items.Add(new DesignerActionPropertyItem("InvertForeColor",
                "Invert ForeColor", "Appearance",
                "Invert the fore color."));
            
            items.Add(new DesignerActionPropertyItem("IsRound",
                "Is Round", "Appearance",
                "Set to round the button."));
            
            items.Add(new DesignerActionPropertyItem("DefaultColor",
                "Background", "Appearance",
                "Sets the default color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));
            
            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));
            
            items.Add(new DesignerActionPropertyItem("DisabledColor",
                "Disabled Color", "Appearance",
                "Sets the button's disabled color."));


            items.Add(new DesignerActionPropertyItem("HoverColor",
                "Hover Color", "Appearance",
                "Sets the button's hovered color."));

            items.Add(new DesignerActionPropertyItem("PressedColor",
                "Pressed Color", "Appearance",
                "Sets the background color when pressed."));

            items.Add(new DesignerActionPropertyItem("RoundingArc",
                "Rounding Arc", "Appearance",
                "Sets the buttons corner radius."));
            
            items.Add(new DesignerActionPropertyItem("TextAlignment",
                "Text Alignment", "Appearance",
                "Sets the text alignment."));

            items.Add(new DesignerActionPropertyItem("Text",
                "Text", "Appearance",
                "Sets the text."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


}