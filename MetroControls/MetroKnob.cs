// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroKnob.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a metro-style knob.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("A class for creating metro knob.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroKnob))]
    [Designer(typeof(ZeroitMetroKnobDesigner))]
    public class ZeroitMetroKnob : Control
	{
        #region Enum

        /// <summary>
        /// Enum representing the Knob Fill Modes
        /// </summary>
        public enum KnobFillModes
	    {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The linear gradient
            /// </summary>
            LinearGradient,
            /// <summary>
            /// The radial gradient
            /// </summary>
            RadialGradient,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch
        }

        /// <summary>
        /// Enum representing Knob Styles
        /// </summary>
        public enum KnobStyles
	    {
            /// <summary>
            /// The arc
            /// </summary>
            Arc,
            /// <summary>
            /// The arc filled
            /// </summary>
            ArcFilled,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The circle filled
            /// </summary>
            CircleFilled
        }

        #endregion

        #region Events and Delegates

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ZeroitMetroKnob.ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedEventHandler(object sender, EventArgs e);


        #endregion

        #region Private Fields

        /// <summary>
        /// The percentage
        /// </summary>
        private float percentage;

        /// <summary>
        /// The base angle
        /// </summary>
        private float baseAngle;

        /// <summary>
        /// The block angle
        /// </summary>
        private float blockAngle;

        /// <summary>
        /// The line end
        /// </summary>
        private int lineEnd;

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum;

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;

        /// <summary>
        /// The line length
        /// </summary>
        private int _LineLength;

        /// <summary>
        /// The line width
        /// </summary>
        private int _LineWidth;

        /// <summary>
        /// The knob style
        /// </summary>
        private ZeroitMetroKnob.KnobStyles _KnobStyle;

        /// <summary>
        /// The fill mode
        /// </summary>
        private ZeroitMetroKnob.KnobFillModes _FillMode;

        /// <summary>
        /// The hatch style
        /// </summary>
        private System.Drawing.Drawing2D.HatchStyle _HatchStyle;

        /// <summary>
        /// The draw line shadow
        /// </summary>
        private bool _DrawLineShadow;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The line color
        /// </summary>
        private Color _LineColor;

        /// <summary>
        /// The accent color
        /// </summary>
        private Color _AccentColor;

        /// <summary>
        /// The fill color
        /// </summary>
        private Color _FillColor;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _GradientColor;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;

        /// <summary>
        /// The circle pen
        /// </summary>
        private PenParameters circlePen = new PenParameters();
        /// <summary>
        /// The line pen
        /// </summary>
        private PenParameters linePen = new PenParameters();
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the circle properties.
        /// </summary>
        /// <value>The circle pen.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PenParameters CirclePen
        {
            get { return circlePen; }
            set
            {
                circlePen = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the line properties.
        /// </summary>
        /// <value>The line pen.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PenParameters LinePen
        {
            get { return linePen; }
            set
            {
                linePen = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>The color of the accent.</value>
        [Category("Appearance")]
        [Description("Sets the color of the accent.")]
        public Color AccentColor
        {
            get
            {
                return this._AccentColor;
            }
            set
            {
                if (this._AccentColor != value)
                {
                    this._AccentColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatic style.
        /// </summary>
        /// <value><c>true</c> if [automatic style]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to automatic style.")]
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
        /// Gets or sets the blocked angle.
        /// </summary>
        /// <value>The blocked angle.</value>
        [Category("Behavior")]
        [DefaultValue(90)]
        [Description("Sets the blocked angle.")]
        public float BlockedAngle
        {
            get
            {
                return this.blockAngle;
            }
            set
            {
                if (value != this.blockAngle)
                {
                    if (this.blockAngle >= 0f & this.blockAngle < 360f)
                    {
                        this.blockAngle = value;
                        this.Invalidate();
                    }
                }
            }
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
        /// Gets or sets a value indicating whether to draw the line shadow.
        /// </summary>
        /// <value><c>true</c> if [draw line shadow]; otherwise, <c>false</c>.</value>
        [Category("Apperance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw the line shadow.")]
        public bool DrawLineShadow
        {
            get
            {
                return this._DrawLineShadow;
            }
            set
            {
                if (this._DrawLineShadow != value)
                {
                    this._DrawLineShadow = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        [Category("Appearance")]
        [Description("Sets the color of the fill.")]
        public Color FillColor
        {
            get
            {
                return this._FillColor;
            }
            set
            {
                if (this._FillColor != value)
                {
                    this._FillColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the fill mode.
        /// </summary>
        /// <value>The fill mode.</value>
        [Category("Apperance")]
        [DefaultValue(0)]
        [Description("Sets the fill mode.")]
        public ZeroitMetroKnob.KnobFillModes FillMode
        {
            get
            {
                return this._FillMode;
            }
            set
            {
                if (this._FillMode != value)
                {
                    this._FillMode = value;
                    this.Invalidate();
                }
            }
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
        /// Gets or sets the color of the gradient.
        /// </summary>
        /// <value>The color of the gradient.</value>
        [Category("Appearance")]
        [Description("Sets the color of the gradient.")]
        public Color GradientColor
        {
            get
            {
                return this._GradientColor;
            }
            set
            {
                if (this._GradientColor != value)
                {
                    this._GradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the hatch style.
        /// </summary>
        /// <value>The hatch style.</value>
        [Category("Apperance")]
        [DefaultValue(3)]
        [Description("Sets the hatch style.")]
        public System.Drawing.Drawing2D.HatchStyle HatchStyle
        {
            get
            {
                return this._HatchStyle;
            }
            set
            {
                if (this._HatchStyle != value)
                {
                    this._HatchStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the knob style.
        /// </summary>
        /// <value>The knob style.</value>
        [Category("Apperance")]
        [DefaultValue(2)]
        [Description("Sets the knob style.")]
        public ZeroitMetroKnob.KnobStyles KnobStyle
        {
            get
            {
                return this._KnobStyle;
            }
            set
            {
                if (this._KnobStyle != value)
                {
                    this._KnobStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("Appearance")]
        [Description("Sets the color of the line.")]
        public Color LineColor
        {
            get
            {
                return this._LineColor;
            }
            set
            {
                if (this._LineColor != value)
                {
                    this._LineColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the length of the line.
        /// </summary>
        /// <value>The length of the line.</value>
        [Category("Apperance")]
        [DefaultValue(18)]
        [Description("Sets the length of the line.")]
        public int LineLength
        {
            get
            {
                return this._LineLength;
            }
            set
            {
                if (this._LineLength != value)
                {
                    if (value <= 100)
                    {
                        if (value <= 90)
                        {
                            this.lineEnd = 90;
                        }
                        else
                        {
                            this.lineEnd = value;
                        }
                        this._LineLength = value;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Category("Apperance")]
        [DefaultValue(1)]
        [Description("Die Dicke der Linie.")]
        public int LineWidth
        {
            get
            {
                return this._LineWidth;
            }
            set
            {
                if (this._LineWidth != value)
                {
                    this._LineWidth = value;
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
                if (this._Maximum != value)
                {
                    this._Maximum = value;
                    if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    if (this._Minimum > this._Maximum)
                    {
                        this._Minimum = this._Maximum;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Data")]
        [DefaultValue(0)]
        [Description("Sets the minimum.")]
        public int Minimum
        {
            get
            {
                return this._Minimum;
            }
            set
            {
                if (this._Minimum != value)
                {
                    this._Minimum = value;
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    if (this._Maximum < this._Minimum)
                    {
                        this._Maximum = this._Minimum;
                    }
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
                                this._LineColor = Design.MetroColors.LightBorder;
                                this._AccentColor = Design.MetroColors.AccentBlue;
                                this._FillColor = Design.MetroColors.AccentBlue;
                                this._GradientColor = Design.MetroColors.LightDefault;
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._LineColor = Design.MetroColors.LightBorder;
                                this._AccentColor = Design.MetroColors.AccentBlue;
                                this._FillColor = Design.MetroColors.AccentBlue;
                                this._GradientColor = Design.MetroColors.DarkDefault;
                                this._DefaultColor = Design.MetroColors.DarkDefault;
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Data")]
        [DefaultValue(50)]
        [Description("Sets the current value.")]
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (this._Value != value)
                {
                    this._Value = value;
                    if (this._Value < this._Minimum)
                    {
                        this._Value = this._Minimum;
                    }
                    else if (this._Value > this._Maximum)
                    {
                        this._Value = this._Maximum;
                    }
                    this.percentage = (float)((double)(checked(this._Value - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum)));
                    ZeroitMetroKnob.ValueChangedEventHandler valueChangedEventHandler = this.ValueChanged;
                    if (valueChangedEventHandler != null)
                    {
                        valueChangedEventHandler(this, new EventArgs());
                    }
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroKnob" /> class.
        /// </summary>
        public ZeroitMetroKnob()
        {
            this.percentage = 50f;
            this.baseAngle = 90f;
            this.blockAngle = 90f;
            this.lineEnd = 90;
            this._Minimum = 0;
            this._Maximum = 100;
            this._Value = 50;
            this._LineLength = 18;
            this._LineWidth = 1;
            this._KnobStyle = ZeroitMetroKnob.KnobStyles.Circle;
            this._FillMode = ZeroitMetroKnob.KnobFillModes.Solid;
            this._HatchStyle = System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal;
            this._DrawLineShadow = true;
            this._Style = Design.Style.Light;
            this._BorderColor = Design.MetroColors.LightBorder;
            this._LineColor = Design.MetroColors.LightBorder;
            this._AccentColor = Design.MetroColors.AccentBlue;
            this._FillColor = Design.MetroColors.AccentBlue;
            this._GradientColor = Design.MetroColors.LightDefault;
            this._DefaultColor = Design.MetroColors.LightDefault;
            this._AutoStyle = true;
            this._MouseState = Helpers.MouseState.None;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            //this.BackColor = this.FindForm().BackColor;
            this.UpdateStyles();
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Gets the knob brush.
        /// </summary>
        /// <param name="fillMode">The fill mode.</param>
        /// <returns>Brush.</returns>
        private Brush GetKnobBrush(ZeroitMetroKnob.KnobFillModes fillMode)
        {
            Brush solidBrush;
            Point point = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
            Point point1 = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
            switch (fillMode)
            {
                case ZeroitMetroKnob.KnobFillModes.Solid:
                    {
                        solidBrush = new SolidBrush(this._FillColor);
                        break;
                    }
                case ZeroitMetroKnob.KnobFillModes.LinearGradient:
                    {
                        solidBrush = new LinearGradientBrush(point, point1, this._FillColor, this._GradientColor);
                        break;
                    }
                case ZeroitMetroKnob.KnobFillModes.RadialGradient:
                    {
                        using (GraphicsPath graphicsPath = new GraphicsPath())
                        {
                            int width = checked(this.ClientSize.Width - 1);
                            System.Drawing.Size clientSize = this.ClientSize;
                            Rectangle rectangle = new Rectangle(0, 0, width, checked(clientSize.Height - 1));
                            graphicsPath.AddEllipse(rectangle);
                            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath)
                            {
                                CenterColor = this._FillColor,
                                SurroundColors = new Color[] { this._GradientColor }
                            };
                            solidBrush = pathGradientBrush;
                        }
                        break;
                    }
                default:
                    {
                        solidBrush = new HatchBrush(this._HatchStyle, this._FillColor, this.BackColor);
                        break;
                    }
            }
            return solidBrush;
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
                    ZeroitMetroForm metroForm = (ZeroitMetroForm)this.FindForm();
                    this.Style = metroForm.Style;
                    this._Style = metroForm.Style;
                    this.Invalidate();
                }
            }
            else if (this._AutoStyle)
            {
                //Color backColor = this.Parent.BackColor;

                Color backColor = BackColor;

                if (backColor == Color.White)
                {
                    this._Style = Design.Style.Light;
                }
                else if (backColor == Color.FromArgb(40, 40, 40))
                {
                    this._Style = Design.Style.Dark;
                }
                this.Style = this._Style;
                this.Invalidate();
            }
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this._MouseState = Helpers.MouseState.Pressed;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.UpdateAngle(e.X, e.Y);
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
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
            {
                this.UpdateAngle(e.X, e.Y);
            }
            base.OnMouseMove(e);
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
            TransInPaint(e.Graphics);
            System.Drawing.Size size;
            Graphics graphics = e.Graphics;
            float single = this.baseAngle + this.blockAngle / 2f + this.percentage * (360f - this.blockAngle);
            System.Drawing.Size clientSize = this.ClientSize;
            int width = checked(clientSize.Width - 1);
            System.Drawing.Size clientSize1 = this.ClientSize;
            Rectangle rectangle = new Rectangle(0, 0, width, checked(clientSize1.Height - 1));
            clientSize1 = this.ClientSize;
            int num = checked((int)Math.Round((double)clientSize1.Width / 2));
            clientSize = this.ClientSize;
            Point point = new Point(num, checked((int)Math.Round((double)clientSize.Height / 2)));
            Point point1 = new Point(0, 0);
            Point circleIntersectionPoints = Design.Drawing.GetCircleIntersectionPoints(rectangle, point, point1)[0];

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.Clear(Parent.BackColor);


            using (Pen pen = new Pen((this._MouseState == Helpers.MouseState.None ? this._BorderColor : this._AccentColor))
            {
                Width = circlePen.Width,
                EndCap = circlePen.EndCap,
                StartCap = circlePen.EndCap,
                Alignment = circlePen.Alignment,
                DashCap = circlePen.DashCap,
                DashOffset = circlePen.DashOffset,
                DashStyle = circlePen.DashStyle,
                LineJoin = circlePen.LineJoin,

            })
            {


                switch (this._KnobStyle)
                {
                    case ZeroitMetroKnob.KnobStyles.Arc:
                        {
                            graphics.DrawArc(pen, rectangle, this.baseAngle + this.blockAngle / 2f, 360f - this.blockAngle);
                            break;
                        }
                    case ZeroitMetroKnob.KnobStyles.ArcFilled:
                        {
                            Brush knobBrush = this.GetKnobBrush(this._FillMode);
                            graphics.FillEllipse(knobBrush, rectangle);
                            using (SolidBrush solidBrush = new SolidBrush(this.BackColor))
                            {
                                Point point2 = circleIntersectionPoints;
                                clientSize1 = this.ClientSize;
                                int num1 = checked((checked(checked((int)Math.Round((double)clientSize1.Width / 2)) - circleIntersectionPoints.X)) * 2);
                                clientSize = this.ClientSize;
                                size = new System.Drawing.Size(num1, checked((checked(checked((int)Math.Round((double)clientSize.Height / 2)) - circleIntersectionPoints.Y)) * 2));
                                Rectangle rectangle1 = new Rectangle(point2, size);
                                graphics.FillEllipse(solidBrush, rectangle1);
                                rectangle1 = new Rectangle(-1, -1, checked(this.Width + 1), checked(this.Height + 1));
                                graphics.FillPie(solidBrush, rectangle1, (float)(checked(90 - checked((int)Math.Round((double)((float)(this.blockAngle / 2f)))))), this.blockAngle);
                            }
                            knobBrush.Dispose();
                            break;
                        }
                    case ZeroitMetroKnob.KnobStyles.Circle:
                        {
                            graphics.DrawEllipse(pen, rectangle);
                            break;
                        }
                    case ZeroitMetroKnob.KnobStyles.CircleFilled:
                        {
                            using (Brush brush = this.GetKnobBrush(this._FillMode))
                            {
                                graphics.FillEllipse(brush, rectangle);
                            }
                            break;
                        }
                }

                Point[] pointOnLine = new Point[2];
                size = this.ClientSize;
                int num2 = checked((int)Math.Round((double)((float)((float)size.Width * 0.5f))));
                clientSize1 = this.ClientSize;
                int num3 = checked((int)Math.Round((double)((float)((float)clientSize1.Height * 0.5f))));
                clientSize = this.ClientSize;
                int num4 = checked((int)Math.Round((double)((float)((float)clientSize.Width * 0.5f * ((float)Math.Cos((double)single * 3.14159265358979 / 180) + 1f)))));
                System.Drawing.Size size1 = this.ClientSize;
                pointOnLine[0] = Design.Drawing.GetPointOnLine(num2, num3, num4, checked((int)Math.Round((double)((float)((float)size1.Height * 0.5f * ((float)Math.Sin((double)single * 3.14159265358979 / 180) + 1f))))), this.lineEnd);
                System.Drawing.Size clientSize2 = this.ClientSize;
                int num5 = checked((int)Math.Round((double)((float)((float)clientSize2.Width * 0.5f))));
                System.Drawing.Size size2 = this.ClientSize;
                int num6 = checked((int)Math.Round((double)((float)((float)size2.Height * 0.5f))));
                System.Drawing.Size clientSize3 = this.ClientSize;
                int num7 = checked((int)Math.Round((double)((float)((float)clientSize3.Width * 0.5f * ((float)Math.Cos((double)single * 3.14159265358979 / 180) + 1f)))));
                System.Drawing.Size size3 = this.ClientSize;
                pointOnLine[1] = Design.Drawing.GetPointOnLine(num5, num6, num7, checked((int)Math.Round((double)((float)((float)size3.Height * 0.5f * ((float)Math.Sin((double)single * 3.14159265358979 / 180) + 1f))))), checked(this.lineEnd - this._LineLength));
                Point[] pointArray = pointOnLine;

                Pen pen1 = new Pen(this._MouseState == Helpers.MouseState.None ? this._BorderColor : this._AccentColor)
                {
                    Width = LinePen.Width,
                    EndCap = LinePen.EndCap,
                    StartCap = LinePen.StartCap,
                    Alignment = LinePen.Alignment,
                    DashCap = LinePen.DashCap,
                    DashOffset = LinePen.DashOffset,
                    DashStyle = LinePen.DashStyle,
                    LineJoin = LinePen.LineJoin,

                };

                if (this._DrawLineShadow)
                {
                    pen1.Width = (float)(checked(this._LineWidth + 2));
                    pen1.Color = Color.FromArgb(40, 0, 0, 0);
                    graphics.DrawLine(pen1, pointArray[0], pointArray[1]);
                    pen1.Width = (float)this._LineWidth;
                }
                pen1.Color = (this._MouseState == Helpers.MouseState.None ? this._LineColor : this._AccentColor);
                graphics.DrawLine(pen1, pointArray[0], pointArray[1]);
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Width, this.Width);
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Updates the angle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        private void UpdateAngle(int x, int y)
        {
            float single = 360f - this.blockAngle / 2f;
            float single1 = this.blockAngle / 2f;
            double num = (double)y;
            System.Drawing.Size clientSize = this.ClientSize;
            double height = num - (double)clientSize.Height / 2;
            double num1 = (double)x;
            System.Drawing.Size size = this.ClientSize;
            float single2 = Math.Min(single, Math.Max(single1, ((float)(Math.Atan2(height, num1 - (double)size.Width / 2) * 180 / 3.14159265358979) - this.baseAngle + 720f) % 360f));
            this.percentage = (single2 - this.blockAngle / 2f) / (360f - this.blockAngle);
            this._Value = checked(checked((int)Math.Round((double)((float)((float)(checked(this._Maximum - this._Minimum)) * this.percentage)))) + this._Minimum);
            ZeroitMetroKnob.ValueChangedEventHandler valueChangedEventHandler = this.ValueChanged;
            if (valueChangedEventHandler != null)
            {
                valueChangedEventHandler(this, new EventArgs());
            }
            this.Invalidate();
        }

        #endregion




        #region Transparency


        #region Include in Paint

        private void TransInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion


        #endregion



    }

    /// <summary>
    /// Class PenParameters.
    /// </summary>
    public class PenParameters
    {

        /// <summary>
        /// The end cap
        /// </summary>
        private LineCap endCap = LineCap.ArrowAnchor;
        /// <summary>
        /// The start cap
        /// </summary>
        private LineCap startCap = LineCap.DiamondAnchor;
        /// <summary>
        /// The alignment
        /// </summary>
        private PenAlignment alignment = PenAlignment.Center;
        /// <summary>
        /// The dash cap
        /// </summary>
        private DashCap dashCap = DashCap.Flat;
        /// <summary>
        /// The dash offset
        /// </summary>
        private float dashOffset = 0.5f;
        /// <summary>
        /// The dash style
        /// </summary>
        private DashStyle dashStyle = DashStyle.DashDot;
        /// <summary>
        /// The line join
        /// </summary>
        private LineJoin lineJoin = LineJoin.Bevel;
        /// <summary>
        /// The width
        /// </summary>
        private int width = 1;

        /// <summary>
        /// Gets or sets the end cap.
        /// </summary>
        /// <value>The end cap.</value>
        public LineCap EndCap
        {
            get { return endCap; }
            set { endCap = value; }
        }

        /// <summary>
        /// Gets or sets the start cap.
        /// </summary>
        /// <value>The start cap.</value>
        public LineCap StartCap
        {
            get { return startCap; }
            set { startCap = value; }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        public PenAlignment Alignment
        {
            get { return alignment; }
            set { alignment = value; }
        }

        /// <summary>
        /// Gets or sets the dash cap.
        /// </summary>
        /// <value>The dash cap.</value>
        public DashCap DashCap
        {
            get { return dashCap; }
            set { dashCap = value; }
        }

        /// <summary>
        /// Gets or sets the dash offset.
        /// </summary>
        /// <value>The dash offset.</value>
        public float DashOffset
        {
            get { return dashOffset; }
            set { dashOffset = value; }
        }

        /// <summary>
        /// Gets or sets the dash style.
        /// </summary>
        /// <value>The dash style.</value>
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set { dashStyle = value; }
        }

        /// <summary>
        /// Gets or sets the line join.
        /// </summary>
        /// <value>The line join.</value>
        public LineJoin LineJoin
        {
            get { return lineJoin; }
            set { lineJoin = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}