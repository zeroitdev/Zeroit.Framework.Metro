// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroNavigationButton.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a metro-style navigation control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("This class enables the rendering of a navigation button.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroNavigationButton), "ZeroitMetroNavigationButton.bmp")]
    [Designer(typeof(ZeroitMetroNavigationButtonDesigner))]
    public class ZeroitMetroNavigationButton : Control
	{
        #region Private Fields

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The arrow direction
        /// </summary>
        private System.Windows.Forms.ArrowDirection _ArrowDirection;

        /// <summary>
        /// The arrow path
        /// </summary>
        private GraphicsPath _ArrowPath;

        /// <summary>
        /// The circle rect
        /// </summary>
        private RectangleF _CircleRect;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The border hover color
        /// </summary>
        private Color _BorderHoverColor;

        /// <summary>
        /// The border pressed color
        /// </summary>
        private Color _BorderPressedColor;

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
        /// The arrow color
        /// </summary>
        private Color _ArrowColor;

        /// <summary>
        /// The arrow hover color
        /// </summary>
        private Color _ArrowHoverColor;

        /// <summary>
        /// The arrow pressed color
        /// </summary>
        private Color _ArrowPressedColor;

        /// <summary>
        /// The disabled color
        /// </summary>
        private Color _DisabledColor;

        /// <summary>
        /// The disabled arrow color
        /// </summary>
        private Color _DisabledArrowColor;

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
        /// Gets or sets the color of the arrow.
        /// </summary>
        /// <value>The color of the arrow.</value>
        [Category("Appearance")]
        [Description("Sets the color of the arrow.")]
        public Color ArrowColor
        {
            get
            {
                return this._ArrowColor;
            }
            set
            {
                if (value != this._ArrowColor)
                {
                    this._ArrowColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the arrow direction.
        /// </summary>
        /// <value>The arrow direction.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the arrow direction.")]
        public System.Windows.Forms.ArrowDirection ArrowDirection
        {
            get
            {
                return this._ArrowDirection;
            }
            set
            {
                if (value != this._ArrowDirection)
                {
                    this._ArrowDirection = value;
                    ZeroitMetroNavigationButton.ArrowDirectionChangedEventHandler arrowDirectionChangedEventHandler = this.ArrowDirectionChanged;
                    if (arrowDirectionChangedEventHandler != null)
                    {
                        arrowDirectionChangedEventHandler(this, new EventArgs());
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the arrow when hovered.
        /// </summary>
        /// <value>The color of the arrow hover.</value>
        [Category("Appearance")]
        [Description("Sets the color of the arrow when hovered.")]
        public Color ArrowHoverColor
        {
            get
            {
                return this._ArrowHoverColor;
            }
            set
            {
                if (value != this._ArrowHoverColor)
                {
                    this._ArrowHoverColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the arrow when pressed.
        /// </summary>
        /// <value>The color of the arrow pressed.</value>
        [Category("Appearance")]
        [Description("Sets the color of the arrow when pressed.")]
        public Color ArrowPressedColor
        {
            get
            {
                return this._ArrowPressedColor;
            }
            set
            {
                if (value != this._ArrowPressedColor)
                {
                    this._ArrowPressedColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable automatic style.
        /// </summary>
        /// <value><c>true</c> if [automatic style]; otherwise, <c>false</c>.</value>
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
        /// Gets or sets the color of the border when hovered.
        /// </summary>
        /// <value>The color of the border hover.</value>
        [Category("Appearance")]
        [Description("Sets the color of the border when hovered.")]
        public Color BorderHoverColor
        {
            get
            {
                return this._BorderHoverColor;
            }
            set
            {
                if (value != this._BorderHoverColor)
                {
                    this._BorderHoverColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border when pressed.
        /// </summary>
        /// <value>The color of the border pressed.</value>
        [Category("Appearance")]
        [Description("Sets the color of the border when pressed.")]
        public Color BorderPressedColor
        {
            get
            {
                return this._BorderPressedColor;
            }
            set
            {
                if (value != this._BorderPressedColor)
                {
                    this._BorderPressedColor = value;
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
        /// Gets or sets the color of the disabled arrow.
        /// </summary>
        /// <value>The color of the disabled arrow.</value>
        [Category("Appearance")]
        [Description("Sets the color of the disabled arrow.")]
        public Color DisabledArrowColor
        {
            get
            {
                return this._DisabledArrowColor;
            }
            set
            {
                if (value != this._DisabledArrowColor)
                {
                    this._DisabledArrowColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the control when not active.
        /// </summary>
        /// <value>The color of the disabled.</value>
        [Category("Appearance")]
        [Description("sets the color of the control when not active.")]
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
        /// Gets or sets the color of the control when pressed.
        /// </summary>
        /// <value>The color of the pressed.</value>
        [Category("Appearance")]
        [Description("Sets the color of the control when pressed.")]
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
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._BorderHoverColor = Design.MetroColors.AccentBlue;
                                this._BorderPressedColor = Design.MetroColors.AccentBlue;
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._HoverColor = Design.MetroColors.LightHover;
                                this._PressedColor = Design.MetroColors.AccentBlue;
                                this._ArrowColor = Design.MetroColors.LightBorder;
                                this._ArrowHoverColor = Design.MetroColors.AccentBlue;
                                this._ArrowPressedColor = Design.MetroColors.LightDefault;
                                this._DisabledColor = Design.MetroColors.LightDisabled;
                                this._DisabledArrowColor = Design.MetroColors.DisabledBorder;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._BorderHoverColor = Design.MetroColors.AccentBlue;
                                this._BorderPressedColor = Design.MetroColors.AccentBlue;
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._HoverColor = Design.MetroColors.DarkHover;
                                this._PressedColor = Design.MetroColors.AccentBlue;
                                this._ArrowColor = Design.MetroColors.LightBorder;
                                this._ArrowHoverColor = Design.MetroColors.AccentBlue;
                                this._ArrowPressedColor = Design.MetroColors.LightDefault;
                                this._DisabledColor = Design.MetroColors.DarkDisabled;
                                this._DisabledArrowColor = Design.MetroColors.DisabledBorder;
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
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroNavigationButton" /> class.
        /// </summary>
        public ZeroitMetroNavigationButton()
        {
            this._Style = Design.Style.Light;
            this._ArrowDirection = System.Windows.Forms.ArrowDirection.Left;
            this._ArrowPath = null;
            this._CircleRect = new RectangleF();
            this._BorderColor = Design.MetroColors.LightBorder;
            this._BorderHoverColor = Design.MetroColors.AccentBlue;
            this._BorderPressedColor = Design.MetroColors.AccentBlue;
            this._DefaultColor = Design.MetroColors.LightDefault;
            this._HoverColor = Design.MetroColors.LightHover;
            this._PressedColor = Design.MetroColors.AccentBlue;
            this._ArrowColor = Design.MetroColors.LightBorder;
            this._ArrowHoverColor = Design.MetroColors.AccentBlue;
            this._ArrowPressedColor = Design.MetroColors.LightDefault;
            this._DisabledColor = Design.MetroColors.LightDisabled;
            this._DisabledArrowColor = Design.MetroColors.DisabledBorder;
            this._MouseState = Helpers.MouseState.None;
            this._AutoStyle = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.BackColor = Color.Transparent;
            this.Size = new System.Drawing.Size(24, 24);
            this._CircleRect = new RectangleF(2.5f, 2.5f, 18f, 18f);
            this._ArrowPath = new GraphicsPath(FillMode.Alternate);
            PointF pointF = new PointF(7.5f, 11.5f);
            GraphicsPath graphicsPath = this._ArrowPath;
            PointF pointF1 = new PointF(11.5f, 15.5f);
            graphicsPath.AddLine(pointF1, pointF);
            GraphicsPath graphicsPath1 = this._ArrowPath;
            pointF1 = new PointF(11.5f, 7.5f);
            graphicsPath1.AddLine(pointF, pointF1);
            this._ArrowPath.StartFigure();
            GraphicsPath graphicsPath2 = this._ArrowPath;
            pointF1 = new PointF(16.5f, 11.5f);
            graphicsPath2.AddLine(pointF, pointF1);
        }

        #endregion

        #region Methods and Overrides
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
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            int num = Math.Min(this.Width, this.Height);
            float single = (float)num / 24f;
            graphics.Transform = new Matrix(single, 0f, 0f, single, (float)(checked(this.Width - num)) / 2f, (float)(checked(this.Height - num)) / 2f);
            using (Pen pen = new Pen(this._BorderColor, 1.5f))
            {
                using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
                {
                    Color color = this._ArrowColor;
                    switch (this._MouseState)
                    {
                        case Helpers.MouseState.None:
                            {
                                pen.Color = this._BorderColor;
                                solidBrush.Color = this._DefaultColor;
                                color = this._ArrowColor;
                                break;
                            }
                        case Helpers.MouseState.Over:
                            {
                                pen.Color = this._BorderHoverColor;
                                solidBrush.Color = this._HoverColor;
                                color = this._ArrowHoverColor;
                                break;
                            }
                        case Helpers.MouseState.Pressed:
                            {
                                pen.Color = this._BorderPressedColor;
                                solidBrush.Color = this._PressedColor;
                                color = this._ArrowPressedColor;
                                break;
                            }
                    }
                    if (!this.Enabled)
                    {
                        pen.Color = this._DisabledArrowColor;
                        solidBrush.Color = this._DisabledColor;
                        color = this._DisabledArrowColor;
                    }
                    graphics.FillEllipse(solidBrush, this._CircleRect);
                    graphics.DrawEllipse(pen, this._CircleRect);
                    System.Windows.Forms.ArrowDirection arrowDirection = this._ArrowDirection;
                    if (arrowDirection == System.Windows.Forms.ArrowDirection.Right)
                    {
                        graphics.MultiplyTransform(new Matrix(-1f, 0f, 0f, 1f, 23f, 0f));
                    }
                    else if (arrowDirection == System.Windows.Forms.ArrowDirection.Up)
                    {
                        graphics.MultiplyTransform(new Matrix(0f, 1f, -1f, 0f, 23f, 0f));
                    }
                    else if (arrowDirection == System.Windows.Forms.ArrowDirection.Down)
                    {
                        graphics.RotateTransform(-90f);
                        graphics.TranslateTransform(-23f, 0f);
                    }
                    pen.Width = 2f;
                    pen.Color = color;
                    graphics.DrawPath(pen, this._ArrowPath);
                }
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Occurs when [arrow direction changed].
        /// </summary>
        [Category("Behavior")]
        [Description("Wird ausgelöst sobald die Pfeilausrichtung verändert wurde.")]
        public event ZeroitMetroNavigationButton.ArrowDirectionChangedEventHandler ArrowDirectionChanged;

        /// <summary>
        /// Delegate ArrowDirectionChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ArrowDirectionChangedEventHandler(object sender, EventArgs e);

        #endregion

    }

}