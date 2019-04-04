// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroForm.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic.CompilerServices;

using System.Collections;

using System.Runtime.InteropServices;



namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class ZeroitMetroForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [Description("Ein Windows.Forms-Steuerelement im Metro Stil.")]
    public class ZeroitMetroForm : System.Windows.Forms.Form
    {

        #region Private Fields

        /// <summary>
        /// The aero enabled
        /// </summary>
        private bool _aeroEnabled;

        /// <summary>
        /// The accent color
        /// </summary>
        private Color _AccentColor;

        /// <summary>
        /// The draw borders
        /// </summary>
        private bool _DrawBorders;

        /// <summary>
        /// The allow resize
        /// </summary>
        private bool _AllowResize;

        /// <summary>
        /// The state
        /// </summary>
        private ZeroitMetroForm.FormState _State;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The resize border width
        /// </summary>
        private int _ResizeBorderWidth;

        /// <summary>
        /// The text rectangle
        /// </summary>
        private Rectangle _TextRectangle;

        /// <summary>
        /// The resize dir
        /// </summary>
        private ZeroitMetroForm.ResizeDirection _resizeDir;

        /// <summary>
        /// The hide border when maximized
        /// </summary>
        private bool _HideBorderWhenMaximized;

        /// <summary>
        /// The align text to control box
        /// </summary>
        private bool _AlignTextToControlBox;

        /// <summary>
        /// The main control box
        /// </summary>
        private ZeroitMetroControlBox _MainControlBox;

        /// <summary>
        /// The is active
        /// </summary>
        private bool _IsActive;

        /// <summary>
        /// The use gradient back color
        /// </summary>
        private bool _UseGradientBackColor;

        /// <summary>
        /// The gradient brush
        /// </summary>
        private LinearGradientBrush _GradientBrush;

        /// <summary>
        /// The form border style
        /// </summary>
        private System.Windows.Forms.FormBorderStyle _FormBorderStyle;

        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        private const int WM_NCLBUTTONDOWN = 161;

        /// <summary>
        /// The htborder
        /// </summary>
        private const int HTBORDER = 18;

        /// <summary>
        /// The htbottom
        /// </summary>
        private const int HTBOTTOM = 15;

        /// <summary>
        /// The htbottomleft
        /// </summary>
        private const int HTBOTTOMLEFT = 16;

        /// <summary>
        /// The htbottomright
        /// </summary>
        private const int HTBOTTOMRIGHT = 17;

        /// <summary>
        /// The htcaption
        /// </summary>
        private const int HTCAPTION = 2;

        /// <summary>
        /// The htleft
        /// </summary>
        private const int HTLEFT = 10;

        /// <summary>
        /// The htright
        /// </summary>
        private const int HTRIGHT = 11;

        /// <summary>
        /// The httop
        /// </summary>
        private const int HTTOP = 12;

        /// <summary>
        /// The httopleft
        /// </summary>
        private const int HTTOPLEFT = 13;

        /// <summary>
        /// The httopright
        /// </summary>
        private const int HTTOPRIGHT = 14;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>The color of the accent.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "0, 122, 204")]
        [Description("Sets the color of the accent.")]
        [RefreshProperties(RefreshProperties.All)]
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
                    Color color = this._AccentColor;
                    if (color == Color.FromArgb(0, 122, 204))
                    {
                        this._State = ZeroitMetroForm.FormState.Normal;
                    }
                    else if (color == Color.FromArgb(104, 33, 122))
                    {
                        this._State = ZeroitMetroForm.FormState.Finished;
                    }
                    else if (color != Color.FromArgb(202, 81, 0))
                    {
                        this._State = ZeroitMetroForm.FormState.Custom;
                    }
                    else
                    {
                        this._State = ZeroitMetroForm.FormState.Busy;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to align text to control box.
        /// </summary>
        /// <value><c>true</c> if align text to control box; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to align text to control box.")]
        public bool AlignTextToControlBox
        {
            get
            {
                return this._AlignTextToControlBox;
            }
            set
            {
                if (this._AlignTextToControlBox != value)
                {
                    this._AlignTextToControlBox = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow resize.
        /// </summary>
        /// <value><c>true</c> if allow resize; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to allow resize.")]
        public bool AllowResize
        {
            get
            {
                return this._AllowResize;
            }
            set
            {
                if (this._AllowResize != value)
                {
                    this._AllowResize = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a control box is displayed in the caption bar of the form.
        /// </summary>
        /// <value><c>true</c> if [control box]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool ControlBox
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw borders.
        /// </summary>
        /// <value><c>true</c> if draw borders; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw borders.")]
        public bool DrawBorders
        {
            get
            {
                return this._DrawBorders;
            }
            set
            {
                if (this._DrawBorders != value)
                {
                    this._DrawBorders = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border style of the form.
        /// </summary>
        /// <value>The form border style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.FormBorderStyle FormBorderStyle
        {
            get
            {
                return this._FormBorderStyle;
            }
            set
            {
                this.FindForm().FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }

        /// <summary>
        /// Gets or sets the gradient brush.
        /// </summary>
        /// <value>The gradient brush.</value>
        [Browsable(false)]
        [Category("Appearance")]
        [Description("Sets the gradient brush.")]
        public LinearGradientBrush GradientBrush
        {
            get
            {
                return this._GradientBrush;
            }
            set
            {
                if (value != this._GradientBrush)
                {
                    this._GradientBrush = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control has aero enabled.
        /// </summary>
        /// <value><c>true</c> if has aero; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Gets a value indicating whether the control has aero enabled.")]
        public bool HasAero
        {
            get
            {
                return this._aeroEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this control has focus.
        /// </summary>
        /// <value><c>true</c> if this control has focus; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Gets a value indicating whether this control has focus.")]
        public bool HasFocus
        {
            get
            {
                return this._IsActive;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a Help button should be displayed in the caption box of the form.
        /// </summary>
        /// <value><c>true</c> if help button; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool HelpButton
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to hide border when maximized.
        /// </summary>
        /// <value><c>true</c> if hide border when maximized; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to hide border when maximized.")]
        public bool HideBorderWhenMaximized
        {
            get
            {
                return this._HideBorderWhenMaximized;
            }
            set
            {
                if (this._HideBorderWhenMaximized != value)
                {
                    this._HideBorderWhenMaximized = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the main control box.
        /// </summary>
        /// <value>The main control box.</value>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Sets the main control box.")]
        public ZeroitMetroControlBox MainControlBox
        {
            get
            {
                return this._MainControlBox;
            }
            set
            {
                if (value != this._MainControlBox)
                {
                    this._MainControlBox = value;
                    this.RelocateMainControlBox();
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Maximize button is displayed in the caption bar of the form.
        /// </summary>
        /// <value><c>true</c> if [maximize box]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MaximizeBox
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Minimize button is displayed in the caption bar of the form.
        /// </summary>
        /// <value><c>true</c> if minimize box; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MinimizeBox
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the width of the resize border.
        /// </summary>
        /// <value>The width of the resize border.</value>
        [Category("Behavior")]
        [DefaultValue(6)]
        [Description("Sets the width of the resize border.")]
        public int ResizeBorderWidth
        {
            get
            {
                return this._ResizeBorderWidth;
            }
            set
            {
                if (this._ResizeBorderWidth != value)
                {
                    this._ResizeBorderWidth = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the resize direction.
        /// </summary>
        /// <value>The resize direction.</value>
        [Browsable(false)]
        [Category("Behavior")]
        [Description("Sets the resize direction.")]
        private ZeroitMetroForm.ResizeDirection ResizeDirect
        {
            get
            {
                return this._resizeDir;
            }
            set
            {
                this._resizeDir = value;
                switch (value)
                {
                    case ZeroitMetroForm.ResizeDirection.Left:
                        {
                            this.Cursor = Cursors.SizeWE;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.TopLeft:
                        {
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.Top:
                        {
                            this.Cursor = Cursors.SizeNS;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.TopRight:
                        {
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.Right:
                        {
                            this.Cursor = Cursors.SizeWE;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.BottomRight:
                        {
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.Bottom:
                        {
                            this.Cursor = Cursors.SizeNS;
                            break;
                        }
                    case ZeroitMetroForm.ResizeDirection.BottomLeft:
                        {
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        }
                    default:
                        {
                            this.Cursor = Cursors.Default;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the state of the form.")]
        [RefreshProperties(RefreshProperties.All)]
        public ZeroitMetroForm.FormState State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (value != this._State)
                {
                    this._State = value;
                    if (this._Style == Design.Style.Light)
                    {
                        switch (this._State)
                        {
                            case ZeroitMetroForm.FormState.Normal:
                                {
                                    this._AccentColor = Color.FromArgb(0, 122, 204);
                                    break;
                                }
                            case ZeroitMetroForm.FormState.Finished:
                                {
                                    this._AccentColor = Color.FromArgb(104, 33, 122);
                                    break;
                                }
                            case ZeroitMetroForm.FormState.Busy:
                                {
                                    this._AccentColor = Color.FromArgb(202, 81, 0);
                                    break;
                                }
                        }
                    }
                    else if (this._Style == Design.Style.Dark)
                    {
                        switch (this._State)
                        {
                            case ZeroitMetroForm.FormState.Normal:
                                {
                                    this._AccentColor = Color.FromArgb(0, 122, 204);
                                    break;
                                }
                            case ZeroitMetroForm.FormState.Finished:
                                {
                                    this._AccentColor = Color.FromArgb(104, 33, 122);
                                    break;
                                }
                            case ZeroitMetroForm.FormState.Busy:
                                {
                                    this._AccentColor = Color.FromArgb(202, 81, 0);
                                    break;
                                }
                        }
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
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
                if (this._Style != value)
                {
                    this._Style = value;
                    switch (this._State)
                    {
                        case ZeroitMetroForm.FormState.Normal:
                            {
                                this._AccentColor = Color.FromArgb(0, 122, 204);
                                break;
                            }
                        case ZeroitMetroForm.FormState.Finished:
                            {
                                this._AccentColor = Color.FromArgb(104, 33, 122);
                                break;
                            }
                        case ZeroitMetroForm.FormState.Busy:
                            {
                                this._AccentColor = Color.FromArgb(202, 81, 0);
                                break;
                            }
                    }
                    if (value == Design.Style.Light)
                    {
                        this.BackColor = Color.White;
                        this.ForeColor = Color.Black;
                    }
                    else if (this._Style == Design.Style.Dark)
                    {
                        this.BackColor = Color.FromArgb(40, 40, 40);
                        this.ForeColor = SystemColors.ControlDark;
                    }
                    this.StyleSpecialControls(this);
                    EventHandler<ZeroitMetroForm.MetroFormEventArgs> eventHandler = this.FormStyleChanged;
                    if (eventHandler != null)
                    {
                        eventHandler(this, new ZeroitMetroForm.MetroFormEventArgs(value));
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient back color.
        /// </summary>
        /// <value><c>true</c> if use gradient back color; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to use gradient back color.")]
        public bool UseGradientBackColor
        {
            get
            {
                return this._UseGradientBackColor;
            }
            set
            {
                if (value != this._UseGradientBackColor)
                {
                    this._UseGradientBackColor = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroForm" /> class.
        /// </summary>
        public ZeroitMetroForm()
        {

            this._AccentColor = Color.FromArgb(0, 122, 204);
            this._DrawBorders = true;
            this._AllowResize = true;
            this._State = ZeroitMetroForm.FormState.Normal;
            this._Style = Design.Style.Light;
            this._ResizeBorderWidth = 6;
            this._TextRectangle = new Rectangle(32, 7, checked(this.Width - 1), checked(this.Height - 1));
            this._resizeDir = ZeroitMetroForm.ResizeDirection.None;
            this._HideBorderWhenMaximized = true;
            this._AlignTextToControlBox = true;
            this._MainControlBox = null;
            this._IsActive = false;
            this._UseGradientBackColor = false;
            Point point = new Point(0, 0);
            Point point1 = new Point(this.Width, this.Height);
            this._GradientBrush = new LinearGradientBrush(point, point1, Color.FromArgb(184, 43, 86), Color.FromArgb(94, 59, 149));
            this._FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParam;
                this.CheckAeroEnabled();
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                if (this._aeroEnabled)
                {
                    createParam = createParams;
                }
                else
                {
                    createParams.ClassStyle = createParams.ClassStyle | 131072;
                    createParam = createParams;
                }
                return createParam;
            }
        }

        /// <summary>
        /// Checks the aero enabled.
        /// </summary>
        private void CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                this._aeroEnabled = false;
            }
            else
            {
                int num = 0;
                ZeroitMetroForm.NativeMethods.DwmIsCompositionEnabled(ref num);
                this._aeroEnabled = num == 1;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            this._IsActive = true;
            this.Invalidate();
            base.OnActivated(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Deactivate" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDeactivate(EventArgs e)
        {
            this._IsActive = false;
            this.Invalidate();
            base.OnDeactivate(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this._AllowResize && e.Button == System.Windows.Forms.MouseButtons.Left & this.WindowState != FormWindowState.Maximized)
            {
                this.ResizeForm(this.ResizeDirect);
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Capture = false;
                Message message = Message.Create(this.Handle, 161, (IntPtr)2, IntPtr.Zero);
                this.WndProc(ref message);
            }
            if (this._AllowResize)
            {
                if (e.Location.X < this._ResizeBorderWidth & e.Location.Y < this._ResizeBorderWidth)
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.TopLeft;
                }
                else if (e.Location.X < this._ResizeBorderWidth & e.Location.Y > checked(this.Height - this._ResizeBorderWidth))
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.BottomLeft;
                }
                else if (e.Location.X > checked(this.Width - this._ResizeBorderWidth) & e.Location.Y > checked(this.Height - this._ResizeBorderWidth))
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.BottomRight;
                }
                else if (e.Location.X > checked(this.Width - this._ResizeBorderWidth) & e.Location.Y < this._ResizeBorderWidth)
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.TopRight;
                }
                else if (e.Location.X < this._ResizeBorderWidth)
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.Left;
                }
                else if (e.Location.X > checked(this.Width - this._ResizeBorderWidth))
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.Right;
                }
                else if (e.Location.Y < this._ResizeBorderWidth)
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.Top;
                }
                else if (e.Location.Y <= checked(this.Height - this._ResizeBorderWidth))
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.None;
                }
                else
                {
                    this.ResizeDirect = ZeroitMetroForm.ResizeDirection.Bottom;
                }
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle;
            Rectangle rectangle1;
            Graphics graphics = e.Graphics;
            if (this._UseGradientBackColor)
            {
                graphics.FillRectangle(this._GradientBrush, this.ClientRectangle);
            }
            using (Pen pen = new Pen(this._AccentColor))
            {
                if (this._DrawBorders)
                {
                    if (this.WindowState != FormWindowState.Maximized)
                    {
                        rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
                        graphics.DrawRectangle(pen, rectangle);
                    }
                    else if (!this._HideBorderWhenMaximized)
                    {
                        rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            using (SolidBrush solidBrush = new SolidBrush((this._IsActive ? this.ForeColor : Design.MetroColors.ChangeColorBrightness(this.ForeColor, -0.2f))))
            {
                if (this.ShowIcon)
                {
                    rectangle = new Rectangle(32, 7, checked(this.Width - 1), checked(this.Height - 1));
                    rectangle1 = rectangle;
                }
                else
                {
                    Rectangle rectangle2 = new Rectangle(8, 7, checked(this.Width - 1), checked(this.Height - 1));
                    rectangle1 = rectangle2;
                }
                this._TextRectangle = rectangle1;
                Rectangle rectangle3 = new Rectangle(8, 6, 16, 16);
                if (this._MainControlBox != null)
                {
                    if (this._AlignTextToControlBox)
                    {
                        Point location = this._TextRectangle.Location;
                        int x = location.X;
                        System.Drawing.Size size = this.MainControlBox.Size;
                        Point point = new Point(x, checked(checked((int)Math.Round((double)size.Height / 2)) - 4));
                        this._TextRectangle.Location = point;
                        point = rectangle3.Location;
                        int num = point.X;
                        size = this.MainControlBox.Size;
                        location = new Point(num, checked(checked((int)Math.Round((double)size.Height / 2)) - 4));
                        rectangle3.Location = location;
                    }
                }
                if (this.ShowIcon)
                {
                    graphics.DrawImage(Design.Drawing.ExtractIcon(this.Icon, 16), rectangle3);
                }
                graphics.DrawString(this.Text, this.Font, solidBrush, this._TextRectangle, StringFormat.GenericDefault);
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            if (this._MainControlBox != null)
            {
                this.RelocateMainControlBox();
            }
            if (this._Style == Design.Style.Dark)
            {
                this.Style = Design.Style.Light;
                this.Style = Design.Style.Dark;
            }
            else if (this.Style == Design.Style.Light)
            {
                this.Style = Design.Style.Dark;
                this.Style = Design.Style.Light;
            }
            base.OnShown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._MainControlBox != null)
            {
                this.RelocateMainControlBox();
            }
            this._GradientBrush.Dispose();
            Point point = new Point(0, 0);
            Point point1 = new Point(this.Width, this.Height);
            this._GradientBrush = new LinearGradientBrush(point, point1, Color.FromArgb(184, 43, 86), Color.FromArgb(94, 59, 149));
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Relocates the main control box.
        /// </summary>
        public void RelocateMainControlBox()
        {
            if (this._MainControlBox != null)
            {
                ZeroitMetroControlBox metroControlBox = this._MainControlBox;
                int width = this.Width;
                System.Drawing.Size size = this._MainControlBox.Size;
                Point point = new Point(checked(checked(width - size.Width) - 1), 1);
                metroControlBox.Location = point;
            }
        }

        /// <summary>
        /// Resizes the form.
        /// </summary>
        /// <param name="direction">The direction.</param>
        private void ResizeForm(ZeroitMetroForm.ResizeDirection direction)
        {
            int num = -1;
            switch (direction)
            {
                case ZeroitMetroForm.ResizeDirection.Left:
                    {
                        num = 10;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.TopLeft:
                    {
                        num = 13;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.Top:
                    {
                        num = 12;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.TopRight:
                    {
                        num = 14;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.Right:
                    {
                        num = 11;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.BottomRight:
                    {
                        num = 17;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.Bottom:
                    {
                        num = 15;
                        break;
                    }
                case ZeroitMetroForm.ResizeDirection.BottomLeft:
                    {
                        num = 16;
                        break;
                    }
            }
            if (num != -1)
            {
                ZeroitMetroForm.ReleaseCapture();
                ZeroitMetroForm.SendMessage(this.Handle, 161, num, 0);
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Styles the special controls.
        /// </summary>
        /// <param name="ct">The ct.</param>
        private void StyleSpecialControls(Control ct)
        {
            IEnumerator enumerator = null;
            bool flag;
            try
            {
                try
                {
                    enumerator = ct.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control current = (Control)enumerator.Current;
                        if (current is ZeroitMetroListbox)
                        {
                            ZeroitMetroListbox style = (ZeroitMetroListbox)current;
                            if (style.AutoStyle)
                            {
                                style.Style = this.Style;
                            }
                            style.Invalidate();
                        }
                        else if (current is ZeroitMetroChecker)
                        {
                            ZeroitMetroChecker metroChecker = (ZeroitMetroChecker)current;
                            if (metroChecker.AutoStyle)
                            {
                                metroChecker.Style = this.Style;
                            }
                            metroChecker.Invalidate();
                        }
                        else if (!(current is ZeroitMetroTracker))
                        {
                            if (!(current is TabPage) && !(current is Panel))
                            {
                                if (current is ZeroitMetroPanelCategory)
                                {
                                    goto Label1;
                                }
                                flag = false;
                                goto Label0;
                            }
                            Label1:
                            flag = true;
                            Label0:
                            if (flag)
                            {
                                this.StyleSpecialControls(current);
                            }
                        }
                        else
                        {
                            ZeroitMetroTracker metroTracker = (ZeroitMetroTracker)current;
                            if (metroTracker.AutoStyle)
                            {
                                metroTracker.Style = this.Style;
                            }
                            metroTracker.Invalidate();
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
        }

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 133)
            {
                int num = 2;
                if (this._aeroEnabled)
                {
                    ZeroitMetroForm.NativeMethods.DwmSetWindowAttribute(this.Handle, 2, ref num, 4);
                    ZeroitMetroForm.NativeStructs.MARGINS mARGIN = new ZeroitMetroForm.NativeStructs.MARGINS()
                    {
                        bottomHeight = 1,
                        leftWidth = 1,
                        rightWidth = 1,
                        topHeight = 1
                    };
                    ZeroitMetroForm.NativeMethods.DwmExtendFrameIntoClientArea(this.Handle, ref mARGIN);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Occurs when [form style changed].
        /// </summary>
        public event EventHandler<ZeroitMetroForm.MetroFormEventArgs> FormStyleChanged;

        /// <summary>
        /// Enum FormState
        /// </summary>
        public enum FormState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal,
            /// <summary>
            /// The finished
            /// </summary>
            Finished,
            /// <summary>
            /// The busy
            /// </summary>
            Busy,
            /// <summary>
            /// The custom
            /// </summary>
            Custom
        }

        /// <summary>
        /// Class MetroFormEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class MetroFormEventArgs : EventArgs
        {
            /// <summary>
            /// The style
            /// </summary>
            private Design.Style _style;

            /// <summary>
            /// Gets the form style.
            /// </summary>
            /// <value>The form style.</value>
            public Design.Style FormStyle
            {
                get
                {
                    return this._style;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MetroFormEventArgs"/> class.
            /// </summary>
            /// <param name="style">The style.</param>
            public MetroFormEventArgs(Design.Style style)
            {
                this._style = style;
            }
        }

        /// <summary>
        /// Class NativeConstants.
        /// </summary>
        private class NativeConstants
        {
            /// <summary>
            /// The cs dropshadow
            /// </summary>
            public const int CS_DROPSHADOW = 131072;

            /// <summary>
            /// The wm ncpaint
            /// </summary>
            public const int WM_NCPAINT = 133;

            /// <summary>
            /// Initializes a new instance of the <see cref="NativeConstants"/> class.
            /// </summary>
            [DebuggerNonUserCode]
            public NativeConstants()
            {
            }
        }

        /// <summary>
        /// Class NativeMethods.
        /// </summary>
        private class NativeMethods
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NativeMethods"/> class.
            /// </summary>
            [DebuggerNonUserCode]
            public NativeMethods()
            {
            }

            /// <summary>
            /// DWMs the extend frame into client area.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="pMarInset">The p mar inset.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("dwmapi", CharSet = CharSet.None, ExactSpelling = false)]
            public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref ZeroitMetroForm.NativeStructs.MARGINS pMarInset);

            /// <summary>
            /// DWMs the is composition enabled.
            /// </summary>
            /// <param name="pfEnabled">The pf enabled.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("dwmapi.dll", CharSet = CharSet.None, ExactSpelling = false)]
            public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

            /// <summary>
            /// DWMs the set window attribute.
            /// </summary>
            /// <param name="hwnd">The HWND.</param>
            /// <param name="attr">The attribute.</param>
            /// <param name="attrValue">The attribute value.</param>
            /// <param name="attrSize">Size of the attribute.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("dwmapi", CharSet = CharSet.None, ExactSpelling = false)]
            internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        }

        /// <summary>
        /// Class NativeStructs.
        /// </summary>
        private class NativeStructs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NativeStructs"/> class.
            /// </summary>
            [DebuggerNonUserCode]
            public NativeStructs()
            {
            }

            /// <summary>
            /// Struct MARGINS
            /// </summary>
            public struct MARGINS
            {
                /// <summary>
                /// The left width
                /// </summary>
                public int leftWidth;

                /// <summary>
                /// The right width
                /// </summary>
                public int rightWidth;

                /// <summary>
                /// The top height
                /// </summary>
                public int topHeight;

                /// <summary>
                /// The bottom height
                /// </summary>
                public int bottomHeight;
            }
        }

        /// <summary>
        /// Enum ResizeDirection
        /// </summary>
        private enum ResizeDirection
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft,
            /// <summary>
            /// The top
            /// </summary>
            Top,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight,
            /// <summary>
            /// The right
            /// </summary>
            Right,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft
        } 
        #endregion
        
    }

}
