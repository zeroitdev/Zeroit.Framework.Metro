// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroPanelCategory.cs" company="Zeroit Dev Technologies">
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
    /// Class ZeroitMetroPanelCategory.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [DefaultEvent("Click")]
	[Description("Ein Kategoriepanel-Steuerelement im Metrostil.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(Panel))]
	[Designer(typeof(ZeroitMetroPanelCategoryDesigner))]
    public class ZeroitMetroPanelCategory : Panel
	{

        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The accent color
        /// </summary>
        private Color _AccentColor;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _GradientColor;

        /// <summary>
        /// The line gradient color
        /// </summary>
        private Color _LineGradientColor;

        /// <summary>
        /// The line orientation
        /// </summary>
        private Orientation _LineOrientation;

        /// <summary>
        /// The line thickness
        /// </summary>
        private int _LineThickness;

        /// <summary>
        /// The use gradient
        /// </summary>
        private bool _UseGradient;

        /// <summary>
        /// The use gradient on line
        /// </summary>
        private bool _UseGradientOnLine;

        /// <summary>
        /// The text align
        /// </summary>
        private StringAlignment _TextAlign;

        /// <summary>
        /// The line align
        /// </summary>
        private StringAlignment _LineAlign;

        /// <summary>
        /// The appearance
        /// </summary>
        private ZeroitMetroPanelCategory.PanelAppearance _Appearance;

        /// <summary>
        /// The slope a
        /// </summary>
        private int _SlopeA;

        /// <summary>
        /// The slope b
        /// </summary>
        private int _SlopeB;

        /// <summary>
        /// The rounding arc
        /// </summary>
        private int _RoundingArc;

        /// <summary>
        /// The allow form moving
        /// </summary>
        private bool _AllowFormMoving;

        /// <summary>
        /// The gradient point a
        /// </summary>
        private Point _GradientPointA;

        /// <summary>
        /// The gradient point b
        /// </summary>
        private Point _GradientPointB;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
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
                if (value != this._AccentColor)
                {
                    this._AccentColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow form moving.
        /// </summary>
        /// <value><c>true</c> if allow form moving; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to allow form moving.")]
        public bool AllowFormMoving
        {
            get
            {
                return this._AllowFormMoving;
            }
            set
            {
                if (value != this._AllowFormMoving)
                {
                    this._AllowFormMoving = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>The appearance.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the appearance.")]
        public ZeroitMetroPanelCategory.PanelAppearance Appearance
        {
            get
            {
                return this._Appearance;
            }
            set
            {
                if (value != this._Appearance)
                {
                    this._Appearance = value;
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
        [Description("sets a value indicating whether to enable automatic style.")]
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
                if (value != this._GradientColor)
                {
                    this._GradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient point.
        /// </summary>
        /// <value>The gradient point a.</value>
        [Browsable(false)]
        [Category("Appereance")]
        [Description("Sets the gradient point.")]
        public Point GradientPointA
        {
            get
            {
                return this._GradientPointA;
            }
            set
            {
                if (this._GradientPointA != value)
                {
                    this._GradientPointA = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient point.
        /// </summary>
        /// <value>The gradient point b.</value>
        [Browsable(false)]
        [Category("Appereance")]
        [Description("Sets the gradient point.")]
        public Point GradientPointB
        {
            get
            {
                return this._GradientPointB;
            }
            set
            {
                if (this._GradientPointB != value)
                {
                    this._GradientPointB = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the line align.
        /// </summary>
        /// <value>The line align.</value>
        [Category("Appearance")]
        [DefaultValue(1)]
        [Description("Sets the line align.")]
        public StringAlignment LineAlign
        {
            get
            {
                return this._LineAlign;
            }
            set
            {
                if (value != this._LineAlign)
                {
                    this._LineAlign = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the line gradient.
        /// </summary>
        /// <value>The color of the line gradient.</value>
        [Category("Appearance")]
        [Description("Sets the color of the line gradient.")]
        public Color LineGradientColor
        {
            get
            {
                return this._LineGradientColor;
            }
            set
            {
                if (value != this._LineGradientColor)
                {
                    this._LineGradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the line orientation.
        /// </summary>
        /// <value>The line orientation.</value>
        [Category("Appearance")]
        [DefaultValue(1)]
        [Description("Sets the line orientation.")]
        public Orientation LineOrientation
        {
            get
            {
                return this._LineOrientation;
            }
            set
            {
                if (value != this._LineOrientation)
                {
                    this._LineOrientation = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        /// <value>The line thickness.</value>
        [Category("Appearance")]
        [DefaultValue(2)]
        [Description("Sets the line thickness.")]
        public int LineThickness
        {
            get
            {
                return this._LineThickness;
            }
            set
            {
                if (value != this._LineThickness)
                {
                    this._LineThickness = value;
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
        [DefaultValue(15)]
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
        /// Gets or sets the slope.
        /// </summary>
        /// <value>The slope a.</value>
        [Category("Appearance")]
        [DefaultValue(15)]
        [Description("Sets the slope.")]
        public int SlopeA
        {
            get
            {
                return this._SlopeA;
            }
            set
            {
                if (value != this._SlopeA)
                {
                    this._SlopeA = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the slope.
        /// </summary>
        /// <value>The slope b.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the slope.")]
        public int SlopeB
        {
            get
            {
                return this._SlopeB;
            }
            set
            {
                if (value != this._SlopeB)
                {
                    this._SlopeB = value;
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
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._AccentColor = Design.MetroColors.AccentBlue;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._AccentColor = Design.MetroColors.AccentBlue;
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
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text align.</value>
        [Category("Appearance")]
        [DefaultValue(1)]
        [Description("Sets the text alignment.")]
        public StringAlignment TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                if (value != this._TextAlign)
                {
                    this._TextAlign = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient.
        /// </summary>
        /// <value><c>true</c> if use gradient; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
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
        /// Gets or sets a value indicating whether to use gradient on line.
        /// </summary>
        /// <value><c>true</c> if use gradient on line; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Gibt an, ob für die Linie ein linearer Verlauf verwendet werden soll.")]
        public bool UseGradientOnLine
        {
            get
            {
                return this._UseGradientOnLine;
            }
            set
            {
                if (value != this._UseGradientOnLine)
                {
                    this._UseGradientOnLine = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroPanelCategory" /> class.
        /// </summary>
        public ZeroitMetroPanelCategory()
		{
			this._Style = Design.Style.Light;
			this._DefaultColor = Design.MetroColors.LightDefault;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._AccentColor = Design.MetroColors.AccentBlue;
			this._GradientColor = this._DefaultColor;
			this._LineGradientColor = Design.MetroColors.ChangeColorBrightness(this._AccentColor, -0.2f);
			this._LineOrientation = Orientation.Vertical;
			this._LineThickness = 2;
			this._UseGradient = false;
			this._UseGradientOnLine = true;
			this._TextAlign = StringAlignment.Center;
			this._LineAlign = StringAlignment.Center;
			this._Appearance = ZeroitMetroPanelCategory.PanelAppearance.Category;
			this._SlopeA = 15;
			this._SlopeB = 0;
			this._RoundingArc = 15;
			this._AllowFormMoving = false;
			this._GradientPointA = new Point(0, 0);
			this._GradientPointB = new Point(this.Width, this.Height);
			this._AutoStyle = true;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
		    this.BackColor = Color.Transparent;
			this.UpdateStyles();
		}


        /// <summary>
        /// Gets the sloped rectangle.
        /// </summary>
        /// <param name="bottom">if set to <c>true</c> [bottom].</param>
        /// <returns>Point[].</returns>
        private Point[] GetSlopedRectangle(bool bottom)
		{
			Point[] pointArray;
			Point point;
			Point point1;
			Point point2;
			Point point3;
			Point[] pointArray1;
			if (!bottom)
			{
				pointArray1 = new Point[4];
				point3 = new Point(0, this.SlopeA);
				pointArray1[0] = point3;
				point2 = new Point(checked(this.Width - 1), this.SlopeB);
				pointArray1[1] = point2;
				point1 = new Point(checked(this.Width - 1), checked(this.Height - 1));
				pointArray1[2] = point1;
				point = new Point(0, checked(this.Height - 1));
				pointArray1[3] = point;
				pointArray = pointArray1;
			}
			else
			{
				pointArray1 = new Point[4];
				point = new Point(0, 0);
				pointArray1[0] = point;
				point1 = new Point(checked(this.Width - 1), 0);
				pointArray1[1] = point1;
				point2 = new Point(checked(this.Width - 1), checked(checked(this.Height - 1) - this.SlopeB));
				pointArray1[2] = point2;
				point3 = new Point(0, checked(checked(this.Height - 1) - this.SlopeA));
				pointArray1[3] = point3;
				pointArray = pointArray1;
			}
			return pointArray;
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (this._AllowFormMoving)
				{
					this.Capture = false;
					try
					{
						Message message = Message.Create(this.FindForm().Handle, 161, (IntPtr)2, IntPtr.Zero);
						this.WndProc(ref message);
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
					}
				}
			}
			base.OnMouseDown(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Point point;
			Point point1;
			Rectangle rectangle;
			Graphics graphics = e.Graphics;
			Pen pen = new Pen(this._BorderColor);
			Brush linearGradientBrush = new LinearGradientBrush(this._GradientPointA, this._GradientPointB, this._DefaultColor, (this._UseGradient ? this._GradientColor : this._DefaultColor));
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			switch (this._Appearance)
			{
				case ZeroitMetroPanelCategory.PanelAppearance.Category:
				{
					graphics.SmoothingMode = SmoothingMode.HighSpeed;
					graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
					graphics.DrawRectangle(pen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
					pen.Color = this._AccentColor;
					pen.Width = (float)this._LineThickness;
					switch (this._LineOrientation)
					{
						case Orientation.Horizontal:
						{
							point1 = new Point(0, 0);
							Point point2 = point1;
							point = new Point(this.Width, 0);
							linearGradientBrush = new LinearGradientBrush(point2, point, this._AccentColor, (this._UseGradientOnLine ? this._LineGradientColor : this._AccentColor));
							graphics.FillRectangle(linearGradientBrush, 0, 0, this.Width, this._LineThickness);
							break;
						}
						case Orientation.Vertical:
						{
							point = new Point(0, 0);
							Point point3 = point;
							point1 = new Point(0, this.Height);
							linearGradientBrush = new LinearGradientBrush(point3, point1, this._AccentColor, (this._UseGradientOnLine ? this._LineGradientColor : this._AccentColor));
							graphics.FillRectangle(linearGradientBrush, 0, 0, this._LineThickness, this.Height);
							break;
						}
					}
					break;
				}
				case ZeroitMetroPanelCategory.PanelAppearance.Rounded:
				{
					rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					Design.Drawing.FillRoundedPath(graphics, linearGradientBrush, rectangle, this._RoundingArc, true, true, true, true);
					Color color = pen.Color;
					rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					Design.Drawing.DrawRoundedPath(graphics, color, 1f, rectangle, this._RoundingArc, true, true, true, true);
					break;
				}
				case ZeroitMetroPanelCategory.PanelAppearance.SlopedBottom:
				{
					graphics.FillPolygon(linearGradientBrush, this.GetSlopedRectangle(true));
					graphics.DrawPolygon(pen, this.GetSlopedRectangle(true));
					break;
				}
				case ZeroitMetroPanelCategory.PanelAppearance.SlopedTop:
				{
					graphics.FillPolygon(linearGradientBrush, this.GetSlopedRectangle(false));
					graphics.DrawPolygon(pen, this.GetSlopedRectangle(false));
					break;
				}
			}
			if (linearGradientBrush != null)
			{
				linearGradientBrush.Dispose();
			}
			pen.Dispose();
			using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
			{
				StringFormat stringFormat = new StringFormat()
				{
					Alignment = this._TextAlign,
					LineAlignment = this._LineAlign
				};
				using (StringFormat stringFormat1 = stringFormat)
				{
					if (this._LineOrientation != Orientation.Vertical)
					{
						string text = this.Text;
						System.Drawing.Font font = this.Font;
						rectangle = new Rectangle(0, this._LineThickness, checked(this.Width - 1), checked(this.Height - (checked(this._LineThickness + 1))));
						graphics.DrawString(text, font, solidBrush, rectangle, stringFormat1);
					}
					else
					{
						string str = this.Text;
						System.Drawing.Font font1 = this.Font;
						rectangle = new Rectangle(this._LineThickness, 0, checked(this.Width - (checked(this._LineThickness + 1))), checked(this.Height - 1));
						graphics.DrawString(str, font1, solidBrush, rectangle, stringFormat1);
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
			if (this.DesignMode)
			{
				this._GradientPointB = new Point(this.Width, this.Height);
			}
			base.OnSizeChanged(e);
		}

        /// <summary>
        /// Enum PanelAppearance
        /// </summary>
        public enum PanelAppearance
		{
            /// <summary>
            /// The category
            /// </summary>
            Category,
            /// <summary>
            /// The rounded
            /// </summary>
            Rounded,
            /// <summary>
            /// The sloped bottom
            /// </summary>
            SlopedBottom,
            /// <summary>
            /// The sloped top
            /// </summary>
            SlopedTop
        }
	}
}