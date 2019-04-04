// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTextbox.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a metro-style texbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("TextChanged")]
	[Description("Ein Textbox-Steuerelement im MetroStil.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(TextBox))]
    [Designer(typeof(ZeroitMetroTextboxDesigner))]
    public class ZeroitMetroTextbox : Control
	{
        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The disabled color
        /// </summary>
        private Color _DisabledColor;

        /// <summary>
        /// The illegal chars
        /// </summary>
        private string _IllegalChars;

        /// <summary>
        /// The ban illegal chars
        /// </summary>
        private bool _BanIllegalChars;

        /// <summary>
        /// The watermark
        /// </summary>
        private string _Watermark;

        /// <summary>
        /// The line only
        /// </summary>
        private bool _LineOnly;

        /// <summary>
        /// The base
        /// </summary>
        private TextBox Base;

        /// <summary>
        /// The maximum length
        /// </summary>
        private int _MaxLength;

        /// <summary>
        /// The accepts return
        /// </summary>
        private bool _AcceptsReturn;

        /// <summary>
        /// The accepts tab
        /// </summary>
        private bool _AcceptsTab;

        /// <summary>
        /// The character casing
        /// </summary>
        private System.Windows.Forms.CharacterCasing _CharacterCasing;

        /// <summary>
        /// The hide selection
        /// </summary>
        private bool _HideSelection;

        /// <summary>
        /// The password character
        /// </summary>
        private char _PasswordChar;

        /// <summary>
        /// The read only
        /// </summary>
        private bool _ReadOnly;

        /// <summary>
        /// The shortcuts enabled
        /// </summary>
        private bool _ShortcutsEnabled;

        /// <summary>
        /// The use system password character
        /// </summary>
        private bool _UseSystemPasswordChar;

        /// <summary>
        /// The word wrap
        /// </summary>
        private bool _WordWrap;

        /// <summary>
        /// The multiline
        /// </summary>
        private bool _Multiline;

        /// <summary>
        /// The text align
        /// </summary>
        private HorizontalAlignment _TextAlign;

        /// <summary>
        /// The scrollbars
        /// </summary>
        private System.Windows.Forms.ScrollBars _Scrollbars;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;

        /// <summary>
        /// The border
        /// </summary>
        private int border = 1;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether it accepts return.
        /// </summary>
        /// <value><c>true</c> if accepts return; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Sets a value indicating whether it accepts return.")]
        public bool AcceptsReturn
        {
            get
            {
                return this._AcceptsReturn;
            }
            set
            {
                if (this.Base != null)
                {
                    this._AcceptsReturn = value;
                    this.Base.AcceptsReturn = this._AcceptsReturn;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it accepts tab.
        /// </summary>
        /// <value><c>true</c> if accepts tab; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Sets a value indicating whether it accepts tab.")]
        public bool AcceptsTab
        {
            get
            {
                return this._AcceptsTab;
            }
            set
            {
                if (this.Base != null)
                {
                    this._AcceptsTab = value;
                    this.Base.AcceptsTab = this._AcceptsTab;
                }
            }
        }

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
        /// Gets or sets a value indicating whether to ban illegal characters.
        /// </summary>
        /// <value><c>true</c> if ban illegal chars; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to ban illegal characters.")]
        public bool BanIllegalChars
        {
            get
            {
                return this._BanIllegalChars;
            }
            set
            {
                if (value != this._BanIllegalChars)
                {
                    this._BanIllegalChars = value;
                    this.Invalidate();
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
                if (value != this._BorderColor)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the character casing.
        /// </summary>
        /// <value>The character casing.</value>
        [DefaultValue(0)]
        [Description("Sets the character casing.")]
        public System.Windows.Forms.CharacterCasing CharacterCasing
        {
            get
            {
                return this._CharacterCasing;
            }
            set
            {
                if (this.Base != null)
                {
                    this._CharacterCasing = value;
                    this.Base.CharacterCasing = this._CharacterCasing;
                }
            }
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
        /// Gets or sets the color of the disabled.
        /// </summary>
        /// <value>The color of the disabled.</value>
        [Category("Appearance")]
        [Description("Sets the color of the disabled.")]
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
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        /// <value><c>true</c> if focused; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Gets a value indicating whether the control has input focus.")]
        public override bool Focused
        {
            get
            {
                return this.Base.Focused;
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Category("Appearance")]
        [Description("Sets the font of the text displayed by the control.")]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                if (this.Base != null)
                {
                    this.Base.Font = value;
                    this.Base.Location = new Point(3, 5);
                    this.Base.Width = checked(this.Width - 6);
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Category("Appearance")]
        [Description("Sets the foreground color of the control.")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                if (this.Base != null)
                {
                    this.Base.ForeColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to hide selection.
        /// </summary>
        /// <value><c>true</c> if hide selection; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to hide selection.")]
        public bool HideSelection
        {
            get
            {
                return this._HideSelection;
            }
            set
            {
                if (this.Base != null)
                {
                    this._HideSelection = value;
                    this.Base.HideSelection = this._HideSelection;
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
        /// Gets or sets the illegal chars.
        /// </summary>
        /// <value>The illegal chars.</value>
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Sets the illegal chars.")]
        public string IllegalChars
        {
            get
            {
                return this._IllegalChars;
            }
            set
            {
                if (Operators.CompareString(value, this._IllegalChars, false) != 0)
                {
                    this._IllegalChars = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether line only is enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if line only; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether line only is enabled/disabled.")]
        public bool LineOnly
        {
            get
            {
                return this._LineOnly;
            }
            set
            {
                if (value != this._LineOnly)
                {
                    this._LineOnly = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        [DefaultValue(32767)]
        [Description("Gets or sets the maximum length.")]
        public int MaxLength
        {
            get
            {
                return this._MaxLength;
            }
            set
            {
                if (this.Base != null)
                {
                    this._MaxLength = value;
                    this.Base.MaxLength = this._MaxLength;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroTextbox" /> is multiline.
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Sets a value indicating whether this control has multiline support.")]
        public bool Multiline
        {
            get
            {
                return this._Multiline;
            }
            set
            {
                if (this.Base != null)
                {
                    this._Multiline = value;
                    this.Base.Multiline = this._Multiline;
                    if (value)
                    {
                        this.Base.Height = checked(this.Height - 11);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the password character.
        /// </summary>
        /// <value>The password character.</value>
        [DefaultValue("")]
        [Description("Sets the password character.")]
        public char PasswordChar
        {
            get
            {
                return this._PasswordChar;
            }
            set
            {
                if (this.Base != null)
                {
                    this._PasswordChar = value;
                    this.Base.PasswordChar = this._PasswordChar;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it has read only support.
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Sets a value indicating whether it has read only support.")]
        public bool ReadOnly
        {
            get
            {
                return this._ReadOnly;
            }
            set
            {
                if (this.Base != null)
                {
                    this._ReadOnly = value;
                    this.Base.ReadOnly = this._ReadOnly;
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
        /// Gets or sets the scroll bars.
        /// </summary>
        /// <value>The scroll bars.</value>
        [DefaultValue(0)]
        [Description("Sets the scroll bars.")]
        public System.Windows.Forms.ScrollBars ScrollBars
        {
            get
            {
                return this._Scrollbars;
            }
            set
            {
                if (this.Base != null)
                {
                    this._Scrollbars = value;
                    this.Base.ScrollBars = this._Scrollbars;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether shortcuts is enabled.
        /// </summary>
        /// <value><c>true</c> if [shortcuts enabled]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Sets a value indicating whether shortcuts is enabled.")]
        public bool ShortcutsEnabled
        {
            get
            {
                return this._ShortcutsEnabled;
            }
            set
            {
                if (this.Base != null)
                {
                    this._ShortcutsEnabled = value;
                    this.Base.ShortcutsEnabled = this._ShortcutsEnabled;
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
                                this._HoverColor = Design.MetroColors.AccentBlue;
                                this._DisabledColor = Design.MetroColors.LightDisabled;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._HoverColor = Design.MetroColors.AccentBlue;
                                this._DisabledColor = Design.MetroColors.DarkDisabled;
                                this.ForeColor = Design.MetroColors.DarkFont;
                                break;
                            }
                        default:
                            {
                                this._AutoStyle = false;
                                break;
                            }
                    }
                    this.Base.BackColor = this._DefaultColor;
                    this.Base.ForeColor = this.ForeColor;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Category("Behavior")]
        [Description("Sets the text associated with this control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (this.Base != null)
                {
                    this.Base.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        [DefaultValue(0)]
        [Description("Sets the text align.")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                if (this.Base != null)
                {
                    this._TextAlign = value;
                    this.Base.TextAlign = this._TextAlign;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use system password character.
        /// </summary>
        /// <value><c>true</c> if use system password character; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to use system password character.")]
        public bool UseSystemPasswordChar
        {
            get
            {
                return this._UseSystemPasswordChar;
            }
            set
            {
                if (this.Base != null)
                {
                    this._UseSystemPasswordChar = value;
                    this.Base.UseSystemPasswordChar = this._UseSystemPasswordChar;
                }
            }
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Sets the watermark.")]
        [Localizable(true)]
        public string Watermark
        {
            get
            {
                return this._Watermark;
            }
            set
            {
                this._Watermark = value;
                this.UpdateWatermark();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether allow word wrap.
        /// </summary>
        /// <value><c>true</c> if [word wrap]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Sets a value indicating whether allow word wrap.")]
        public bool WordWrap
        {
            get
            {
                return this._WordWrap;
            }
            set
            {
                if (this.Base != null)
                {
                    this._WordWrap = value;
                    this.Base.WordWrap = this._WordWrap;
                }
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public int Border
	    {
	        get { return border; }
	        set { border = value;
	            Invalidate();
	        }
	    }


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTextbox" /> class.
        /// </summary>
        public ZeroitMetroTextbox()
		{
			this._Style = Design.Style.Light;
			this._BorderColor = Design.MetroColors.LightBorder;
			this._HoverColor = Design.MetroColors.AccentBlue;
			this._DefaultColor = Design.MetroColors.LightDefault;
			this._DisabledColor = Design.MetroColors.LightDisabled;
			this._IllegalChars = "";
			this._BanIllegalChars = false;
			this._Watermark = "";
			this._LineOnly = false;
			this._MaxLength = 32767;
			this._AcceptsReturn = false;
			this._AcceptsTab = false;
			this._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this._HideSelection = false;
			this._PasswordChar = '\0';
			this._ReadOnly = false;
			this._ShortcutsEnabled = true;
			this._UseSystemPasswordChar = false;
			this._WordWrap = true;
			this._Multiline = false;
			this._TextAlign = HorizontalAlignment.Left;
			this._Scrollbars = System.Windows.Forms.ScrollBars.None;
			this._AutoStyle = true;
			this._MouseState = Helpers.MouseState.None;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			this.CreateBase();
		}

        /// <summary>
        /// Creates the base.
        /// </summary>
        private void CreateBase()
		{
			this.Base = new TextBox()
			{
				Font = this.Font,
				Text = this.Text,
				MaxLength = this._MaxLength,
				Cursor = Cursors.IBeam,
				Multiline = this._Multiline,
				ReadOnly = this._ReadOnly,
				UseSystemPasswordChar = this._UseSystemPasswordChar,
				BorderStyle = BorderStyle.None,
				Location = new Point(5, 4),
				Width = checked(this.Width - 10),
				BackColor = this._DefaultColor,
				ForeColor = this.ForeColor
			};
			ZeroitMetroTextbox metroTextbox = this;
			this.Base.TextChanged += new EventHandler(metroTextbox.OnBaseTextChanged);
			ZeroitMetroTextbox metroTextbox1 = this;
			this.Base.GotFocus += new EventHandler(metroTextbox1.OnBaseGotFocus);
			ZeroitMetroTextbox metroTextbox2 = this;
			this.Base.LostFocus += new EventHandler(metroTextbox2.OnBaseLostFocus);
			ZeroitMetroTextbox metroTextbox3 = this;
			this.Base.HandleCreated += new EventHandler(metroTextbox3.OnBaseHandleCreated);
			ZeroitMetroTextbox metroTextbox4 = this;
			this.Base.MouseDoubleClick += new MouseEventHandler(metroTextbox4.OnBaseMouseDoubleClick);
			ZeroitMetroTextbox metroTextbox5 = this;
			this.Base.MouseHover += new EventHandler(metroTextbox5.OnBaseMouseHover);
			ZeroitMetroTextbox metroTextbox6 = this;
			this.Base.MouseMove += new MouseEventHandler(metroTextbox6.OnBaseMouseMove);
			ZeroitMetroTextbox metroTextbox7 = this;
			this.Base.MouseWheel += new MouseEventHandler(metroTextbox7.OnBaseMouseWheel);
			ZeroitMetroTextbox metroTextbox8 = this;
			this.Base.MouseClick += new MouseEventHandler(metroTextbox8.OnBaseMouseClick);
			ZeroitMetroTextbox metroTextbox9 = this;
			this.Base.MouseEnter += new EventHandler(metroTextbox9.OnBaseMouseEnter);
			ZeroitMetroTextbox metroTextbox10 = this;
			this.Base.KeyDown += new KeyEventHandler(metroTextbox10.OnBaseKeyDown);
			ZeroitMetroTextbox metroTextbox11 = this;
			this.Base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(metroTextbox11.OnBaseKeyPress);
			ZeroitMetroTextbox metroTextbox12 = this;
			this.Base.KeyUp += new KeyEventHandler(metroTextbox12.OnBaseKeyUp);
		}

        /// <summary>
        /// Focuses this instance.
        /// </summary>
        protected new void Focus()
		{
			this.Base.Focus();
			this.Base.Select();
		}

        /// <summary>
        /// Gets the ASCII character.
        /// </summary>
        /// <param name="uVirtKey">The u virt key.</param>
        /// <returns>System.Char.</returns>
        private char GetAsciiCharacter(int uVirtKey)
		{
			char chr;
			byte[] numArray = new byte[256];
			ZeroitMetroTextbox.GetKeyboardState(numArray);
			byte[] numArray1 = new byte[2];
			chr = (ZeroitMetroTextbox.ToAscii(uVirtKey, 0, numArray, numArray1, 0) != 1 ? new char() : Convert.ToChar(numArray1[0]));
			return chr;
		}

        /// <summary>
        /// Gets the state of the keyboard.
        /// </summary>
        /// <param name="pbKeyState">State of the pb key.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int GetKeyboardState(byte[] pbKeyState);

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
        /// Handles the <see cref="E:BaseGotFocus" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseGotFocus(object sender, EventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			this.Focus();
			ZeroitMetroTextbox.GotFocusEventHandler gotFocusEventHandler = this.GotFocus;
			if (gotFocusEventHandler != null)
			{
				gotFocusEventHandler(this, e);
			}
			this.Invalidate();
		}

        /// <summary>
        /// Handles the <see cref="E:BaseHandleCreated" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseHandleCreated(object sender, EventArgs e)
		{
			this.UpdateWatermark();
		}

        /// <summary>
        /// Handles the <see cref="E:BaseKeyDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void OnBaseKeyDown(object sender, KeyEventArgs e)
		{
			if (this._BanIllegalChars)
			{
				if (!this._IllegalChars.Contains(Conversions.ToString(this.GetAsciiCharacter(e.KeyValue))))
				{
					ZeroitMetroTextbox.KeyDownEventHandler keyDownEventHandler = this.KeyDown;
					if (keyDownEventHandler != null)
					{
						keyDownEventHandler(this, e);
					}
				}
				else
				{
					e.SuppressKeyPress = true;
					ZeroitMetroTextbox.IllegalCharEnteredEventHandler illegalCharEnteredEventHandler = this.IllegalCharEntered;
					if (illegalCharEnteredEventHandler != null)
					{
						illegalCharEnteredEventHandler(this, e);
					}
				}
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseKeyPress" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void OnBaseKeyPress(object sender, KeyPressEventArgs e)
		{
			ZeroitMetroTextbox.KeyPressEventHandler keyPressEventHandler = this.KeyPress;
			if (keyPressEventHandler != null)
			{
				keyPressEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseKeyUp" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void OnBaseKeyUp(object sender, KeyEventArgs e)
		{
			ZeroitMetroTextbox.KeyDownEventHandler keyDownEventHandler = this.KeyDown;
			if (keyDownEventHandler != null)
			{
				keyDownEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseLostFocus" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseLostFocus(object sender, EventArgs e)
		{
			this._MouseState = Helpers.MouseState.None;
			ZeroitMetroTextbox.LostFocusEventHandler lostFocusEventHandler = this.LostFocus;
			if (lostFocusEventHandler != null)
			{
				lostFocusEventHandler(this, e);
			}
			this.Invalidate();
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseClick(object sender, MouseEventArgs e)
		{
			ZeroitMetroTextbox.MouseClickEventHandler mouseClickEventHandler = this.MouseClick;
			if (mouseClickEventHandler != null)
			{
				mouseClickEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseDoubleClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseDoubleClick(object sender, MouseEventArgs e)
		{
			ZeroitMetroTextbox.MouseDoubleClickEventHandler mouseDoubleClickEventHandler = this.MouseDoubleClick;
			if (mouseDoubleClickEventHandler != null)
			{
				mouseDoubleClickEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseEnter" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseEnter(object sender, EventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			this.Invalidate();
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseHover" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseHover(object sender, EventArgs e)
		{
			ZeroitMetroTextbox.MouseHoverEventHandler mouseHoverEventHandler = this.MouseHover;
			if (mouseHoverEventHandler != null)
			{
				mouseHoverEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseMove(object sender, MouseEventArgs e)
		{
			ZeroitMetroTextbox.MouseMoveEventHandler mouseMoveEventHandler = this.MouseMove;
			if (mouseMoveEventHandler != null)
			{
				mouseMoveEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseMouseWheel" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnBaseMouseWheel(object sender, MouseEventArgs e)
		{
			ZeroitMetroTextbox.MouseWheelEventHandler mouseWheelEventHandler = this.MouseWheel;
			if (mouseWheelEventHandler != null)
			{
				mouseWheelEventHandler(this, e);
			}
		}

        /// <summary>
        /// Handles the <see cref="E:BaseTextChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.Base.Text;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.Over;
			this.Focus();
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
			if (!this.Base.Focused)
			{
				this._MouseState = Helpers.MouseState.None;
				this.Invalidate();
			}
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
			Color color = (this.Enabled ? this._DefaultColor : this._DisabledColor);
			graphics.Clear(color);
			this.Base.BackColor = color;
			using (Pen pen = new Pen(this._BorderColor){Width = Border})
			{
				if ((this._MouseState == Helpers.MouseState.Over || this._MouseState == Helpers.MouseState.Pressed ? true : false))
				{
					pen.Color = this._HoverColor;
				}
				if (!this._LineOnly)
				{
					Rectangle rectangle = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
					graphics.DrawRectangle(pen, rectangle);
				}
				else
				{
					graphics.DrawLine(pen, 0, checked(this.Height - 1), checked(this.Width - 1), checked(this.Height - 1));
				}
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnParentChanged(EventArgs e)
		{
			if (!this.Controls.Contains(this.Base))
			{
				this.Controls.Add(this.Base);
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
		{
			this.Base.Location = new Point(5, 4);
			this.Base.Width = checked(this.Width - 10);
			if (this._Multiline)
			{
				this.Base.Height = checked(this.Height - 11);
			}
			base.OnResize(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.VisibleChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
		{
			this.Base.Visible = this.Visible;
			base.OnVisibleChanged(e);
		}

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wp">The wp.</param>
        /// <param name="lp">The lp.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet=CharSet.Unicode, ExactSpelling=false)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);

        /// <summary>
        /// To the ASCII.
        /// </summary>
        /// <param name="uVirtKey">The u virt key.</param>
        /// <param name="uScanCode">The u scan code.</param>
        /// <param name="lpbKeyState">State of the LPB key.</param>
        /// <param name="lpChar">The lp character.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpChar, int uFlags);

        /// <summary>
        /// Updates the watermark.
        /// </summary>
        private void UpdateWatermark()
		{
			if ((!this.Base.IsHandleCreated || this._Watermark == null ? false : true))
			{
				IntPtr handle = this.Base.Handle;
				IntPtr intPtr = new IntPtr(1);
				ZeroitMetroTextbox.SendMessage(handle, 5377, intPtr, this._Watermark);
			}
		}

        /// <summary>
        /// Occurs when [got focus].
        /// </summary>
        public event ZeroitMetroTextbox.GotFocusEventHandler GotFocus;

        /// <summary>
        /// Occurs when [illegal character entered].
        /// </summary>
        public event ZeroitMetroTextbox.IllegalCharEnteredEventHandler IllegalCharEntered;

        /// <summary>
        /// Occurs when [key down].
        /// </summary>
        public event ZeroitMetroTextbox.KeyDownEventHandler KeyDown;

        /// <summary>
        /// Occurs when [key press].
        /// </summary>
        public event ZeroitMetroTextbox.KeyPressEventHandler KeyPress;

        /// <summary>
        /// Occurs when [key up].
        /// </summary>
        public event ZeroitMetroTextbox.KeyUpEventHandler KeyUp;

        /// <summary>
        /// Occurs when [lost focus].
        /// </summary>
        public event ZeroitMetroTextbox.LostFocusEventHandler LostFocus;

        /// <summary>
        /// Occurs when [mouse click].
        /// </summary>
        public event ZeroitMetroTextbox.MouseClickEventHandler MouseClick;

        /// <summary>
        /// Occurs when [mouse double click].
        /// </summary>
        public event ZeroitMetroTextbox.MouseDoubleClickEventHandler MouseDoubleClick;

        /// <summary>
        /// Occurs when [mouse hover].
        /// </summary>
        public event ZeroitMetroTextbox.MouseHoverEventHandler MouseHover;

        /// <summary>
        /// Occurs when [mouse move].
        /// </summary>
        public event ZeroitMetroTextbox.MouseMoveEventHandler MouseMove;

        /// <summary>
        /// Occurs when [mouse wheel].
        /// </summary>
        public event ZeroitMetroTextbox.MouseWheelEventHandler MouseWheel;

        /// <summary>
        /// Delegate GotFocusEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void GotFocusEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Delegate IllegalCharEnteredEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        public delegate void IllegalCharEnteredEventHandler(object sender, KeyEventArgs e);

        /// <summary>
        /// Delegate KeyDownEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        public delegate void KeyDownEventHandler(object sender, KeyEventArgs e);

        /// <summary>
        /// Delegate KeyPressEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        public delegate void KeyPressEventHandler(object sender, KeyPressEventArgs e);

        /// <summary>
        /// Delegate KeyUpEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        public delegate void KeyUpEventHandler(object sender, KeyEventArgs e);

        /// <summary>
        /// Delegate LostFocusEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void LostFocusEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Delegate MouseClickEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public delegate void MouseClickEventHandler(object sender, MouseEventArgs e);

        /// <summary>
        /// Delegate MouseDoubleClickEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public delegate void MouseDoubleClickEventHandler(object sender, MouseEventArgs e);

        /// <summary>
        /// Delegate MouseHoverEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void MouseHoverEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Delegate MouseMoveEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public delegate void MouseMoveEventHandler(object sender, MouseEventArgs e);

        /// <summary>
        /// Delegate MouseWheelEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public delegate void MouseWheelEventHandler(object sender, MouseEventArgs e);
	}
}