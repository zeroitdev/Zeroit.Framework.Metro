// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="Balloon.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class ZeroitBalloon.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("Used for drawing a balloon text box.")]
    [DesignerCategory("Code")]
    [ToolboxBitmap(typeof(ZeroitBalloon), "ZeroitBalloon.bmp")]
    [Designer(typeof(ZeroitBalloonDesigner))]
    public class ZeroitBalloon : Control
    {

        #region Private Fields
        //private static List<WeakReference> __ENCList;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The triangle width
        /// </summary>
        private int _TriangleWidth;

        /// <summary>
        /// The triangle position
        /// </summary>
        private int _TrianglePos;

        /// <summary>
        /// The has triangle
        /// </summary>
        private bool _HasTriangle;

        /// <summary>
        /// The is bound to cursor
        /// </summary>
        private bool _IsBoundToCursor;

        /// <summary>
        /// The balloon text
        /// </summary>
        private string _BalloonText;

        /// <summary>
        /// The has animation
        /// </summary>
        private bool _HasAnimation;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _style = Design.Style.Custom;

        /// <summary>
        /// The icon
        /// </summary>
        private Image _Icon;

        /// <summary>
        /// The host control
        /// </summary>
        private Control _HostControl;

        /// <summary>
        /// The control opacity
        /// </summary>
        private float _ControlOpacity;

        /// <summary>
        /// The is fading
        /// </summary>
        private bool _IsFading;

        /// <summary>
        /// The is visible
        /// </summary>
        private bool _IsVisible;

        /// <summary>
        /// The TMR fade
        /// </summary>
        [AccessedThroughProperty("FadeTimer")]
        private System.Windows.Forms.Timer _tmrFade;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to automatically style the control.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Automatically style the control.")]
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
        /// Gets or sets the balloon text.
        /// </summary>
        /// <value>The balloon text.</value>
        [Category("Appearance")]
        [Description("The text to use in the balloon.")]
        public string BalloonText
        {
            get
            {
                return this._BalloonText;
            }
            set
            {
                if (Operators.CompareString(value, this._BalloonText, false) != 0)
                {
                    this._BalloonText = value;
                    using (Graphics graphic = this.CreateGraphics())
                    {
                        SizeF sizeF = graphic.MeasureString(this._BalloonText, this.Font);
                        int num = 50;
                        int num1 = 30;
                        if (sizeF.Width > 50f)
                        {
                            num = checked(checked((int)Math.Round((double)sizeF.Width)) + 4);
                            if (sizeF.Height > 30f)
                            {
                                num1 = checked(checked(checked((int)Math.Round((double)sizeF.Height)) + 4) + (this._HasTriangle ? this._TriangleWidth : 0));
                            }
                        }
                        this.Size = new System.Drawing.Size(num, num1);
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance")]
        [Description("Die Umrandungsfarbe des Steuerelements.")]
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
        /// Gets or sets the cursor that is displayed when the mouse pointer is over the control.
        /// </summary>
        /// <value>The cursor.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.Cursor Cursor
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
        /// Gets or sets which control borders are docked to its parent control and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The dock.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new DockStyle Dock
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has animation.
        /// </summary>
        /// <value><c>true</c> if this instance has animation; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Set to enable animation.")]
        public bool HasAnimation
        {
            get
            {
                return this._HasAnimation;
            }
            set
            {
                if (value != this._HasAnimation)
                {
                    this._HasAnimation = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control has triangle.
        /// </summary>
        /// <value><c>true</c> if this control has triangle; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Set to show the triangle.")]
        public bool HasTriangle
        {
            get
            {
                return this._HasTriangle;
            }
            set
            {
                if (value != this._HasTriangle)
                {
                    this._HasTriangle = value;
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
                return this._Icon;
            }
            set
            {
                if (value != this._Icon)
                {
                    this._Icon = value;
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
                return this._style;
            }
            set
            {
                if (value != this._style)
                {
                    this._style = value;
                    switch (value)
                    {
                        case Design.Style.Light:
                            {
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._BorderColor = Design.MetroColors.PopUpBorder;
                                this.ForeColor = Design.MetroColors.PopUpFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
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
        /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
        /// </summary>
        /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
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
        /// Gets or sets the fade timer.
        /// </summary>
        /// <value>The fade.</value>
        public virtual System.Windows.Forms.Timer FadeTimer
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tmrFade;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ZeroitBalloon metroBalloon = this;
                EventHandler eventHandler = new EventHandler(metroBalloon.FadeEffect);
                if (this._tmrFade != null)
                {
                    this._tmrFade.Tick -= eventHandler;
                }
                this._tmrFade = value;
                if (this._tmrFade != null)
                {
                    this._tmrFade.Tick += eventHandler;
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the triangle.
        /// </summary>
        /// <value>The width of the triangle.</value>
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("Sets the width of the triangle.")]
        public int TriangleWidth
        {
            get
            {
                return this._TriangleWidth;
            }
            set
            {
                if (value != this._TriangleWidth)
                {
                    this._TriangleWidth = value;
                    if (this._HasTriangle)
                    {
                        System.Drawing.Size size = new System.Drawing.Size(this.Width, checked(this.Height + this._TriangleWidth));
                        this.Size = size;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the wait cursor for the current control and all child controls.
        /// </summary>
        /// <value><c>true</c> if use wait cursor; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseWaitCursor
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBalloon" /> class.
        /// </summary>
        public ZeroitBalloon()
        {
            this._BorderColor = Design.MetroColors.PopUpBorder;
            this._DefaultColor = Design.MetroColors.LightDefault;
            this._TriangleWidth = 5;
            this._TrianglePos = 0;
            this._HasTriangle = true;
            this._IsBoundToCursor = true;
            this._BalloonText = string.Empty;
            this._HasAnimation = true;
            this._Icon = null;
            this._HostControl = null;
            this._ControlOpacity = 0f;
            this._IsFading = false;
            this._IsVisible = true;
            this.FadeTimer = new System.Windows.Forms.Timer()
            {
                Interval = 40
            };
            this._AutoStyle = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.ForeColor = Design.MetroColors.PopUpFont;
            //this.Visible = false;
            this.UpdateStyles();
        }
        #endregion

        #region Methods and Overrides

        /// <summary>
        /// Creates the image.
        /// </summary>
        /// <returns>Bitmap.</returns>
        private Bitmap CreateImage()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphic = Graphics.FromImage(bitmap);
            Rectangle rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - (this._HasTriangle ? this._TriangleWidth : 1)));
            using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
            {
                graphic.FillRectangle(solidBrush, rectangle);
            }
            using (Pen pen = new Pen(this._BorderColor))
            {
                graphic.DrawRectangle(pen, rectangle);
                if (this._HasTriangle)
                {
                    this.DrawTriangle(graphic);
                }
            }
            if (this._Icon != null)
            {
                rectangle = new Rectangle(checked(this._Icon.Width + 4), 0, checked(checked(this.Width - 1) - (checked(this._Icon.Width + 4))), checked(this.Height - (this._HasTriangle ? this._TriangleWidth : 1)));
                Graphics graphic1 = graphic;
                Image image = this._Icon;
                Point point = new Point(4, checked(checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._Icon.Height / 2))) - (this._HasTriangle ? this._TriangleWidth : 1)) + 2));
                graphic1.DrawImage(image, point);
            }
            using (SolidBrush solidBrush1 = new SolidBrush(this.ForeColor))
            {
                StringFormat stringFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                using (StringFormat stringFormat1 = stringFormat)
                {
                    graphic.DrawString(this._BalloonText, this.Font, solidBrush1, rectangle, stringFormat1);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Draws the triangle.
        /// </summary>
        /// <param name="e">The e.</param>
        protected void DrawTriangle(Graphics e)
        {
            int num = 1;
            Point[] pointArray = new Point[3];
            Point point = new Point(this._TrianglePos, checked(checked(this.Height - this._TriangleWidth) - num));
            pointArray[0] = point;
            Point point1 = new Point(checked(this._TrianglePos + checked((int)Math.Round((double)this._TriangleWidth / 2))), checked(this.Height - num));
            pointArray[1] = point1;
            Point point2 = new Point(checked(this._TrianglePos + this._TriangleWidth), checked(checked(this.Height - this._TriangleWidth) - num));
            pointArray[2] = point2;
            Point[] pointArray1 = pointArray;
            Graphics graphic = e;
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
            {
                graphic.FillPolygon(solidBrush, pointArray1);
            }
            using (Pen pen = new Pen(this._BorderColor))
            {
                graphic.DrawLine(pen, pointArray1[0], pointArray1[1]);
                graphic.DrawLine(pen, pointArray1[1], pointArray1[2]);
            }
            graphic.SmoothingMode = SmoothingMode.HighSpeed;
            graphic = null;
        }

        /// <summary>
        /// Fades the effect.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FadeEffect(object sender, EventArgs e)
        {
            this._IsFading = true;
            if (this._IsVisible)
            {
                this._ControlOpacity = (float)((double)this._ControlOpacity - 0.1);
                if (this._ControlOpacity <= 0f)
                {
                    this.FadeTimer.Stop();
                    this._IsFading = false;
                    this._IsVisible = false;
                    this.Visible = false;
                    this._ControlOpacity = 0f;
                }
            }
            else
            {
                this.Visible = true;
                this._ControlOpacity = (float)((double)this._ControlOpacity + 0.1);
                if (this._ControlOpacity >= 1f)
                {
                    this.FadeTimer.Stop();
                    this._IsFading = false;
                    this._IsVisible = true;
                    this._ControlOpacity = 1f;
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
        /// Handles the <see cref="E:HostMouseEnter" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnHostMouseEnter(object sender, EventArgs e)
        {
            if (!this._HasAnimation)
            {
                this.Visible = true;
                this._IsVisible = true;
            }
            else if (!this._IsFading)
            {
                if (!this._IsVisible)
                {
                    this.BringToFront();
                    this.FadeTimer.Start();
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:HostMouseLeave" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnHostMouseLeave(object sender, EventArgs e)
        {
            if (!this._HasAnimation)
            {
                this.Visible = false;
                this._IsVisible = false;
            }
            else
            {
                this.FadeTimer.Stop();
                this._IsVisible = true;
                this.FadeTimer.Start();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:HostMouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnHostMouseMove(object sender, MouseEventArgs e)
        {
            if (this._IsBoundToCursor)
            {
                Point location = this._HostControl.Location;
                int x = location.X;
                location = this._HostControl.Location;
                int y = location.Y;
                Control parent = this._HostControl.Parent ?? this._HostControl;
                if (checked(checked(x + e.X) + this.Width) <= parent.Width)
                {
                    location = this._HostControl.Location;
                    x = checked(checked(location.X + e.X) + 5);
                }
                else
                {
                    x = checked(checked(parent.Width - this.Width) - 1);
                }
                y = (checked(checked(y - this.Height) - 1) >= 0 ? checked(checked(y - this.Height) - 1) : 0);
                location = new Point(x, y);
                this.Location = location;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this._IsFading)
            {
                Bitmap bitmap = (Bitmap)this.SetImageOpacity(this.CreateImage(), this._ControlOpacity);
                graphics.DrawImage(bitmap, 0, 0);
            }
            else if ((this._IsVisible /*|| this.DesignMode*/ ? true : false))
            {
                Rectangle rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - (this._HasTriangle ? this._TriangleWidth : 1)));
                using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
                {
                    graphics.FillRectangle(solidBrush, rectangle);
                }
                using (Pen pen = new Pen(this._BorderColor))
                {
                    graphics.DrawRectangle(pen, rectangle);
                    if (this._HasTriangle)
                    {
                        this.DrawTriangle(graphics);
                    }
                }
                if (this._Icon != null)
                {
                    rectangle = new Rectangle(checked(this._Icon.Width + 4), 0, checked(checked(this.Width - 1) - (checked(this._Icon.Width + 4))), checked(this.Height - (this._HasTriangle ? this._TriangleWidth : 1)));
                    Graphics graphic = graphics;
                    Image image = this._Icon;
                    Point point = new Point(4, checked(checked(checked(checked((int)Math.Round((double)this.Height / 2)) - checked((int)Math.Round((double)this._Icon.Height / 2))) - (this._HasTriangle ? this._TriangleWidth : 1)) + 2));
                    graphic.DrawImage(image, point);
                }
                using (SolidBrush solidBrush1 = new SolidBrush(this.ForeColor))
                {
                    StringFormat stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    using (StringFormat stringFormat1 = stringFormat)
                    {
                        graphics.DrawString(this._BalloonText, this.Font, solidBrush1, rectangle, stringFormat1);
                    }
                }
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Sets the image opacity.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Image.</returns>
        private Image SetImageOpacity(Image image, float opacity)
        {
            Image image1;
            try
            {
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                using (Graphics graphic = Graphics.FromImage(bitmap))
                {
                    ColorMatrix colorMatrix = new ColorMatrix()
                    {
                        Matrix33 = opacity
                    };
                    ImageAttributes imageAttribute = new ImageAttributes();
                    imageAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    graphic.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttribute);
                }
                image1 = bitmap;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                image1 = null;
                ProjectData.ClearProjectError();
            }
            return image1;
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Show()
        {
        }

        /// <summary>
        /// Shows the balloon.
        /// </summary>
        /// <param name="sText">The s text.</param>
        /// <param name="cHost">The c host.</param>
        public void ShowBalloon(string sText, Control cHost)
        {
            this.BalloonText = sText;
            this._IsBoundToCursor = true;
            this.Visible = false;
            if (cHost != null)
            {
                this._HostControl = cHost;
                ZeroitBalloon metroBalloon = this;
                cHost.MouseMove += new MouseEventHandler(metroBalloon.OnHostMouseMove);
                ZeroitBalloon metroBalloon1 = this;
                cHost.MouseEnter += new EventHandler(metroBalloon1.OnHostMouseEnter);
                ZeroitBalloon metroBalloon2 = this;
                cHost.MouseLeave += new EventHandler(metroBalloon2.OnHostMouseLeave);
            }
        }

        /// <summary>
        /// Shows the balloon.
        /// </summary>
        /// <param name="sText">The s text.</param>
        /// <param name="cHost">The c host.</param>
        /// <param name="iIcon">The i icon.</param>
        public void ShowBalloon(string sText, Control cHost, Image iIcon)
        {
            this.BalloonText = sText;
            this._IsBoundToCursor = true;
            this._Icon = iIcon;
            this.Visible = false;
            if (cHost != null)
            {
                this._HostControl = cHost;
                ZeroitBalloon metroBalloon = this;
                cHost.MouseMove += new MouseEventHandler(metroBalloon.OnHostMouseMove);
                ZeroitBalloon metroBalloon1 = this;
                cHost.MouseEnter += new EventHandler(metroBalloon1.OnHostMouseEnter);
                ZeroitBalloon metroBalloon2 = this;
                cHost.MouseLeave += new EventHandler(metroBalloon2.OnHostMouseLeave);
            }
        }

        /// <summary>
        /// Shows the balloon.
        /// </summary>
        /// <param name="sText">The s text.</param>
        /// <param name="p">The p.</param>
        public void ShowBalloon(string sText, Point p)
        {
            this.BalloonText = sText;
            this._IsBoundToCursor = false;
            this._IsVisible = true;
            this.Location = p;
        }

        /// <summary>
        /// Shows the balloon.
        /// </summary>
        /// <param name="sText">The s text.</param>
        /// <param name="p">The p.</param>
        /// <param name="iIcon">The i icon.</param>
        public void ShowBalloon(string sText, Point p, Image iIcon)
        {
            this.BalloonText = sText;
            this._Icon = iIcon;
            this._IsBoundToCursor = false;
            this._IsVisible = true;
            this.Location = p;
        }


        #endregion
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitBalloonDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitBalloonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitBalloonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitBalloonSmartTagActionList(this.Component));
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
    /// Class ZeroitBalloonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitBalloonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitBalloon colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBalloonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitBalloonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitBalloon;

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
        /// Gets or sets the balloon text.
        /// </summary>
        /// <value>The balloon text.</value>
        public string BalloonText
        {
            get
            {
                return colUserControl.BalloonText;
            }
            set
            {
                GetPropertyByName("BalloonText").SetValue(colUserControl, value);
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
        /// Gets or sets a value indicating whether this instance has animation.
        /// </summary>
        /// <value><c>true</c> if this instance has animation; otherwise, <c>false</c>.</value>
        public bool HasAnimation
        {
            get
            {
                return colUserControl.HasAnimation;
            }
            set
            {
                GetPropertyByName("HasAnimation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has triangle.
        /// </summary>
        /// <value><c>true</c> if this instance has triangle; otherwise, <c>false</c>.</value>
        public bool HasTriangle
        {
            get
            {
                return colUserControl.HasTriangle;
            }
            set
            {
                GetPropertyByName("HasTriangle").SetValue(colUserControl, value);
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
                GetPropertyByName("Style").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fade timer.
        /// </summary>
        /// <value>The fade timer.</value>
        public virtual System.Windows.Forms.Timer FadeTimer
        {
            get
            {
                return colUserControl.FadeTimer;
            }
            set
            {
                GetPropertyByName("FadeTimer").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the triangle.
        /// </summary>
        /// <value>The width of the triangle.</value>
        public int TriangleWidth
        {
            get
            {
                return colUserControl.TriangleWidth;
            }
            set
            {
                GetPropertyByName("TriangleWidth").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("HasAnimation",
                "Has Animation", "Appearance",
                "Set to show if its."));

            items.Add(new DesignerActionPropertyItem("HasTriangle",
                "Has Triangle", "Appearance",
                "Set to enable triangle."));
            
            items.Add(new DesignerActionPropertyItem("AutoStyle",
                "Auto Style", "Appearance",
                "Sets the auto style."));
            
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));
            
            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border Color", "Appearance",
                "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("DefaultColor",
                "Default Color", "Appearance",
                "Sets the default color."));
            
            items.Add(new DesignerActionPropertyItem("Style",
                "Style", "Appearance",
                "Sets the balloon style."));
            
            items.Add(new DesignerActionPropertyItem("TriangleWidth",
                "Triangle Width", "Appearance",
                "Sets the triangle width."));

            items.Add(new DesignerActionPropertyItem("BalloonText",
                "Balloon Text", "Appearance",
                "Sets the balloon text."));


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
