// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTabControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a metro-style tab control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    [Description("")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(TabControl))]
	public class ZeroitMetroTabControl : TabControl
	{
        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The item color
        /// </summary>
        private Color _ItemColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The selected border color
        /// </summary>
        private Color _SelectedBorderColor;

        /// <summary>
        /// The selected item color
        /// </summary>
        private Color _SelectedItemColor;

        /// <summary>
        /// The selected fore color
        /// </summary>
        private Color _SelectedForeColor;

        /// <summary>
        /// The selected item line color
        /// </summary>
        private Color _SelectedItemLineColor;

        /// <summary>
        /// The item fore color
        /// </summary>
        private Color _ItemForeColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The hover border color
        /// </summary>
        private Color _HoverBorderColor;

        /// <summary>
        /// The header item color
        /// </summary>
        private Color _HeaderItemColor;

        /// <summary>
        /// The header fore color
        /// </summary>
        private Color _HeaderForeColor;

        /// <summary>
        /// The tab container color
        /// </summary>
        private Color _TabContainerColor;

        /// <summary>
        /// The draw selected line
        /// </summary>
        private bool _DrawSelectedLine;

        /// <summary>
        /// The draw polygon
        /// </summary>
        private bool _DrawPolygon;

        /// <summary>
        /// The polygon width
        /// </summary>
        private int _PolygonWidth;

        /// <summary>
        /// The selected item line width
        /// </summary>
        private int _SelectedItemLineWidth;

        /// <summary>
        /// The selected tab is bold
        /// </summary>
        private bool _SelectedTabIsBold;

        /// <summary>
        /// The has animation
        /// </summary>
        private bool _HasAnimation;

        /// <summary>
        /// The automatic back color
        /// </summary>
        private bool _AutoBackColor;

        /// <summary>
        /// The item text align
        /// </summary>
        private StringAlignment _ItemTextAlign;

        /// <summary>
        /// The header indexes
        /// </summary>
        private List<int> _HeaderIndexes;

        /// <summary>
        /// The image width
        /// </summary>
        private int _ImageWidth;

        /// <summary>
        /// The last index
        /// </summary>
        private int _LastIndex;

        /// <summary>
        /// The animation speed
        /// </summary>
        private int _AnimationSpeed;

        /// <summary>
        /// The initialized
        /// </summary>
        private bool _Initialized;

        /// <summary>
        /// The default item size
        /// </summary>
        public System.Drawing.Size DefaultItemSize;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;

        /// <summary>
        /// The hot tab
        /// </summary>
        private Rectangle _HotTab;

        /// <summary>
        /// The hot index
        /// </summary>
        private int _HotIndex;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the area of the control (for example, along the top) where the tabs are aligned.
        /// </summary>
        /// <value>The alignment.</value>
        [DefaultValue(2)]
		public new TabAlignment Alignment
		{
			get
			{
				return base.Alignment;
			}
			set
			{
				System.Drawing.Size itemSize;
				System.Drawing.Size size;
				System.Drawing.Size size1;
				if ((value == TabAlignment.Bottom || value == TabAlignment.Top ? true : false))
				{
					if ((base.Alignment == TabAlignment.Left || base.Alignment == TabAlignment.Right ? true : false))
					{
						itemSize = this.ItemSize;
						int height = itemSize.Height;
						size = this.ItemSize;
						size1 = new System.Drawing.Size(height, size.Width);
						this.ItemSize = size1;
					}
				}
				else if ((value == TabAlignment.Left || value == TabAlignment.Right ? true : false))
				{
					if ((base.Alignment == TabAlignment.Bottom || base.Alignment == TabAlignment.Top ? true : false))
					{
						size1 = this.ItemSize;
						int num = size1.Height;
						size = this.ItemSize;
						itemSize = new System.Drawing.Size(num, size.Width);
						this.ItemSize = itemSize;
					}
				}
				base.Alignment = value;
			}
		}

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        [Category("Behavior")]
		[DefaultValue(5)]
		[Description("Sets the animation speed.")]
		public int AnimationSpeed
		{
			get
			{
				return this._AnimationSpeed;
			}
			set
			{
				if (this._AnimationSpeed != value)
				{
					this._AnimationSpeed = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the visual appearance of the control's tabs.
        /// </summary>
        /// <value>The appearance.</value>
        [Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new System.Windows.Forms.Appearance Appearance
		{
			[DebuggerNonUserCode]
			get;
			[DebuggerNonUserCode]
			set;
		}

        /// <summary>
        /// Gets or sets a value indicating whether enable automatic back color.
        /// </summary>
        /// <value><c>true</c> if automatic back color; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		[DefaultValue(true)]
		[Description("Sets a value indicating whether enable automatic back color.")]
		public bool AutoBackColor
		{
			get
			{
				return this._AutoBackColor;
			}
			set
			{
				if (this._AutoBackColor != value)
				{
					this._AutoBackColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether to set automatic style.
        /// </summary>
        /// <value><c>true</c> if [automatic style]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		[DefaultValue(true)]
		[Description("Sets a value indicating whether to set automatic style.")]
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
        /// Gets or sets the background image.
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
        /// Gets or sets the background image layout.
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
        /// Gets or sets a value indicating whether to draw the item selected line.
        /// </summary>
        /// <value><c>true</c> if draw item selected line; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		[DefaultValue(false)]
		[Description("Sets a value indicating whether to draw the item selected line.")]
		public bool DrawItemSelectedLine
		{
			get
			{
				return this._DrawSelectedLine;
			}
			set
			{
				if (this._DrawSelectedLine != value)
				{
					this._DrawSelectedLine = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether to draw triangle.
        /// </summary>
        /// <value><c>true</c> if draw triangle; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		[DefaultValue(false)]
		[Description("Sets a value indicating whether to draw triangle.")]
		public bool DrawTriangle
		{
			get
			{
				return this._DrawPolygon;
			}
			set
			{
				if (this._DrawPolygon != value)
				{
					this._DrawPolygon = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this control has animation enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if this control has animation; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
		[DefaultValue(true)]
		[Description("Sets a value indicating whether this control has animation enabled/disabled.")]
		public bool HasAnimation
		{
			get
			{
				return this._HasAnimation;
			}
			set
			{
				if (this._HasAnimation != value)
				{
					this._HasAnimation = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>The color of the header.</value>
        [Category("Appearance")]
		[Description("Sets the color of the header.")]
		public Color HeaderForeColor
		{
			get
			{
				return this._HeaderForeColor;
			}
			set
			{
				if (this._HeaderForeColor != value)
				{
					this._HeaderForeColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the header item.
        /// </summary>
        /// <value>The color of the header item.</value>
        [Category("Appearance")]
		[Description("Sets the color of the header item.")]
		public Color HeaderItemColor
		{
			get
			{
				return this._HeaderItemColor;
			}
			set
			{
				if (this._HeaderItemColor != value)
				{
					this._HeaderItemColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the border when hovered.
        /// </summary>
        /// <value>The color of the hover border.</value>
        [Category("Appearance")]
		[Description("Sets the color of the border when hovered.")]
		public Color HoverBorderColor
		{
			get
			{
				return this._HoverBorderColor;
			}
			set
			{
				if (this._HoverBorderColor != value)
				{
					this._HoverBorderColor = value;
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
				if (this._HoverColor != value)
				{
					this._HoverColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the images to display on the control's tabs.
        /// </summary>
        /// <value>The image list.</value>
        public new System.Windows.Forms.ImageList ImageList
		{
			get
			{
				return base.ImageList;
			}
			set
			{
				base.ImageList = value;
				if (value != null)
				{
					this._ImageWidth = this.ImageList.ImageSize.Width;
				}
			}
		}

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        [Category("Appearance")]
		[DefaultValue(16)]
		[Description("Sets the width of the image.")]
		public int ImageWidth
		{
			get
			{
				return this._ImageWidth;
			}
			set
			{
				if (this._ImageWidth != value)
				{
					this._ImageWidth = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the item.
        /// </summary>
        /// <value>The color of the item.</value>
        [Category("Appearance")]
		[Description("Sets the color of the item.")]
		public Color ItemColor
		{
			get
			{
				return this._ItemColor;
			}
			set
			{
				if (this._ItemColor != value)
				{
					this._ItemColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the item.
        /// </summary>
        /// <value>The color of the item.</value>
        [Category("Appearance")]
		[Description("Sets the color of the item.")]
		public Color ItemForeColor
		{
			get
			{
				return this._ItemForeColor;
			}
			set
			{
				if (this._ItemForeColor != value)
				{
					this._ItemForeColor = value;
					this.Invalidate();
				}
			}
		}

        /// <summary>
        /// Gets or sets the item's text alignment.
        /// </summary>
        /// <value>The item text align.</value>
        [Category("Behavior")]
		[DefaultValue(1)]
		[Description("Sets the item's text alignment.")]        
        public StringAlignment ItemTextAlign
        {
            get
            {
                return this._ItemTextAlign;
            }
            set
            {
                if (this._ItemTextAlign != value)
                {
                    this._ItemTextAlign = value;
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
        /// Gets or sets a value indicating whether right-to-left mirror placement is turned on.
        /// </summary>
        /// <value><c>true</c> if right to left layout; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool RightToLeftLayout
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the color of the selected border.
        /// </summary>
        /// <value>The color of the selected border.</value>
        [Category("Appearance")]
        [Description("Sets the color of the selected border.")]
        public Color SelectedBorderColor
        {
            get
            {
                return this._SelectedBorderColor;
            }
            set
            {
                if (this._SelectedBorderColor != value)
                {
                    this._SelectedBorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected fore.
        /// </summary>
        /// <value>The color of the selected fore.</value>
        [Category("Appearance")]
        [Description("Sets the color of the selected item.")]
        public Color SelectedForeColor
        {
            get
            {
                return this._SelectedForeColor;
            }
            set
            {
                if (this._SelectedForeColor != value)
                {
                    this._SelectedForeColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected item.
        /// </summary>
        /// <value>The color of the selected item.</value>
        [Category("Appearance")]
        [Description("Sets the color of the selected item.")]
        public Color SelectedItemColor
        {
            get
            {
                return this._SelectedItemColor;
            }
            set
            {
                if (this._SelectedItemColor != value)
                {
                    this._SelectedItemColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected item line.
        /// </summary>
        /// <value>The color of the selected item line.</value>
        [Category("Appearance")]
        [Description("Sets the color of the selected item line.")]
        public Color SelectedItemLineColor
        {
            get
            {
                return this._SelectedItemLineColor;
            }
            set
            {
                if (this._SelectedItemLineColor != value)
                {
                    this._SelectedItemLineColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the selected item line.
        /// </summary>
        /// <value>The width of the selected item line.</value>
        [Category("Behavior")]
        [DefaultValue(2)]
        [Description("Sets the width of the selected item line.")]
        public int SelectedItemLineWidth
        {
            get
            {
                return this._SelectedItemLineWidth;
            }
            set
            {
                if (this._SelectedItemLineWidth != value)
                {
                    this._SelectedItemLineWidth = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether selected tab is bold.
        /// </summary>
        /// <value><c>true</c> if selected tab is bold; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether selected tab is bold.")]
        public bool SelectedTabIsBold
        {
            get
            {
                return this._SelectedTabIsBold;
            }
            set
            {
                if (this._SelectedTabIsBold != value)
                {
                    this._SelectedTabIsBold = value;
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
                                this._ItemColor = Design.MetroColors.LightDefault;
                                this._BorderColor = Design.MetroColors.PopUpBorder;
                                this._SelectedBorderColor = Design.MetroColors.AccentBlue;
                                this._SelectedItemColor = Design.MetroColors.AccentBlue;
                                this._SelectedForeColor = Design.MetroColors.LightDefault;
                                this._ItemForeColor = Design.MetroColors.LightFont;
                                this._HoverColor = Design.MetroColors.LightDefault;
                                this._HoverBorderColor = Design.MetroColors.AccentBlue;
                                this._HeaderItemColor = Design.MetroColors.LightDefault;
                                this._HeaderForeColor = Design.MetroColors.PopUpFont;
                                this._TabContainerColor = Design.MetroColors.LightDefault;
                                this.ForeColor = Design.MetroColors.LightFont;
                                if (this._AutoBackColor)
                                {
                                    this.ChangeTabPageColors(this.GetParentColor());
                                }
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._ItemColor = Design.MetroColors.DarkDefault;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this._SelectedBorderColor = Design.MetroColors.AccentBlue;
                                this._SelectedItemColor = Design.MetroColors.AccentBlue;
                                this._SelectedForeColor = Design.MetroColors.LightDefault;
                                this._ItemForeColor = Design.MetroColors.DarkFont;
                                this._HoverColor = Design.MetroColors.DarkDefault;
                                this._HoverBorderColor = Design.MetroColors.AccentBlue;
                                this._HeaderItemColor = Design.MetroColors.DarkDefault;
                                this._HeaderForeColor = Design.MetroColors.PopUpFont;
                                this._TabContainerColor = Design.MetroColors.DarkDefault;
                                this.ForeColor = Design.MetroColors.DarkFont;
                                if (this._AutoBackColor)
                                {
                                    this.ChangeTabPageColors(this.GetParentColor());
                                }
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
        /// Gets or sets the color of the tab container.
        /// </summary>
        /// <value>The color of the tab container.</value>
        [Category("Appearance")]
        [Description("Sets the color of the tab container.")]
        public Color TabContainerColor
        {
            get
            {
                return this._TabContainerColor;
            }
            set
            {
                if (this._TabContainerColor != value)
                {
                    this._TabContainerColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the triangle.
        /// </summary>
        /// <value>The width of the triangle.</value>
        [Category("Appearance")]
        [DefaultValue(10)]
        [Description("Sets the width of the triangle.")]
        public int TriangleWidth
        {
            get
            {
                return this._PolygonWidth;
            }
            set
            {
                if (this._PolygonWidth != value)
                {
                    this._PolygonWidth = value;
                    this.Invalidate();
                }
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTabControl" /> class.
        /// </summary>
        public ZeroitMetroTabControl()
		{
			this._Style = Design.Style.Light;
			this._ItemColor = Design.MetroColors.LightDefault;
			this._BorderColor = Design.MetroColors.PopUpBorder;
			this._SelectedBorderColor = Design.MetroColors.AccentBlue;
			this._SelectedItemColor = Design.MetroColors.AccentBlue;
			this._SelectedForeColor = Design.MetroColors.LightDefault;
			this._SelectedItemLineColor = Design.MetroColors.AccentBlue;
			this._ItemForeColor = Design.MetroColors.LightFont;
			this._HoverColor = Design.MetroColors.LightDefault;
			this._HoverBorderColor = Design.MetroColors.AccentBlue;
			this._HeaderItemColor = Design.MetroColors.LightDefault;
			this._HeaderForeColor = Color.FromArgb(150, 150, 150);
			this._TabContainerColor = Design.MetroColors.LightDefault;
			this._DrawSelectedLine = false;
			this._DrawPolygon = false;
			this._PolygonWidth = 10;
			this._SelectedItemLineWidth = 2;
			this._SelectedTabIsBold = true;
			this._HasAnimation = true;
			this._AutoBackColor = true;
			this._ItemTextAlign = StringAlignment.Center;
			this._HeaderIndexes = new List<int>();
			this._ImageWidth = 16;
			this._LastIndex = 0;
			this._AnimationSpeed = 5;
			this._Initialized = false;
			this.DefaultItemSize = new System.Drawing.Size(45, 120);
			this._MouseState = Helpers.MouseState.None;
			this._HotIndex = -1;
			this._AutoStyle = true;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			this.SizeMode = TabSizeMode.Fixed;
			this.Alignment = TabAlignment.Left;
			this.HotTrack = true;
			this.ItemSize = new System.Drawing.Size(45, 120);
		}

        /// <summary>
        /// Changes the tab page colors.
        /// </summary>
        /// <param name="color">The color.</param>
        public void ChangeTabPageColors(Color color)
		{
			int count = checked(this.TabPages.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				this.TabPages[i].BackColor = color;
			}
		}

        /// <summary>
        /// Changes the tab page to header.
        /// </summary>
        /// <param name="index">The index.</param>
        public void ChangeTabPageToHeader(int index)
		{
			this._HeaderIndexes.Add(index);
			this.Invalidate();
		}

        /// <summary>
        /// Changes the tab page to header.
        /// </summary>
        /// <param name="index">The index.</param>
        public void ChangeTabPageToHeader(int[] index)
		{
			int[] numArray = index;
			for (int i = 0; i < checked((int)numArray.Length); i = checked(i + 1))
			{
				this.ChangeTabPageToHeader(numArray[i]);
			}
		}

        /// <summary>
        /// Does the animation.
        /// </summary>
        /// <param name="Control1">The control1.</param>
        /// <param name="Control2">The control2.</param>
        /// <param name="isLeftScroll">if set to <c>true</c> [is left scroll].</param>
        private void DoAnimation(Control Control1, Control Control2, bool isLeftScroll)
		{
			int i;
			IEnumerator enumerator = null;
			IEnumerator enumerator1 = null;
			IEnumerator enumerator2 = null;
			IEnumerator enumerator3 = null;
			try
			{
				Graphics graphic = Control1.CreateGraphics();
				Bitmap bitmap = new Bitmap(Control1.Width, Control1.Height);
				Bitmap bitmap1 = new Bitmap(Control2.Width, Control2.Height);
				Rectangle rectangle = new Rectangle(0, 0, Control1.Width, Control1.Height);
				Control1.DrawToBitmap(bitmap, rectangle);
				rectangle = new Rectangle(0, 0, Control2.Width, Control2.Height);
				Control2.DrawToBitmap(bitmap1, rectangle);
				try
				{
					enumerator = Control2.Controls.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Control current = (Control)enumerator.Current;
						if (!current.Visible)
						{
							current.Tag = "0";
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
				try
				{
					enumerator1 = Control1.Controls.GetEnumerator();
					while (enumerator1.MoveNext())
					{
						Control control = (Control)enumerator1.Current;
						if (!control.Visible)
						{
							control.Tag = "0";
						}
						control.Hide();
					}
				}
				finally
				{
					if (enumerator1 is IDisposable)
					{
						(enumerator1 as IDisposable).Dispose();
					}
				}
				int width = checked(Control1.Width - Control1.Width % this._AnimationSpeed);
				if (!isLeftScroll)
				{
					int num = checked(0 - width);
					int num1 = checked(0 - this._AnimationSpeed);
					for (i = 0; (num1 >> 31 ^ i) <= (num1 >> 31 ^ num); i = checked(i + num1))
					{
						rectangle = new Rectangle(i, 0, Control1.Width, Control1.Height);
						graphic.DrawImage(bitmap, rectangle);
						rectangle = new Rectangle(checked(i + Control2.Width), 0, Control2.Width, Control2.Height);
						graphic.DrawImage(bitmap1, rectangle);
					}
					i = Control1.Width;
					rectangle = new Rectangle(i, 0, Control1.Width, Control1.Height);
					graphic.DrawImage(bitmap, rectangle);
					rectangle = new Rectangle(checked(i + Control2.Width), 0, Control2.Width, Control2.Height);
					graphic.DrawImage(bitmap1, rectangle);
				}
				else
				{
					int num2 = width;
					int num3 = this._AnimationSpeed;
					for (i = 0; (num3 >> 31 ^ i) <= (num3 >> 31 ^ num2); i = checked(i + num3))
					{
						rectangle = new Rectangle(i, 0, Control1.Width, Control1.Height);
						graphic.DrawImage(bitmap, rectangle);
						rectangle = new Rectangle(checked(i - Control2.Width), 0, Control2.Width, Control2.Height);
						graphic.DrawImage(bitmap1, rectangle);
					}
					i = Control1.Width;
					rectangle = new Rectangle(i, 0, Control1.Width, Control1.Height);
					graphic.DrawImage(bitmap, rectangle);
					rectangle = new Rectangle(checked(i - Control2.Width), 0, Control2.Width, Control2.Height);
					graphic.DrawImage(bitmap1, rectangle);
				}
				this.SelectedTab = (TabPage)Control2;
				try
				{
					enumerator2 = Control2.Controls.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Control current1 = (Control)enumerator2.Current;
						if (current1.Tag != null)
						{
							current1.Show();
						}
						current1.Tag = null;
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
				try
				{
					enumerator3 = Control1.Controls.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						Control control1 = (Control)enumerator3.Current;
						if (control1.Tag != null)
						{
							control1.Show();
						}
						control1.Tag = null;
					}
				}
				finally
				{
					if (enumerator3 is IDisposable)
					{
						(enumerator3 as IDisposable).Dispose();
					}
				}
				graphic.Dispose();
				bitmap.Dispose();
				bitmap1.Dispose();
				ZeroitMetroTabControl.AnimationCompleteEventHandler animationCompleteEventHandler = this.AnimationComplete;
				if (animationCompleteEventHandler != null)
				{
					animationCompleteEventHandler(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
		}

        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void DrawPolygon(PaintEventArgs e)
		{
			Point[] pointArray;
			Point point;
			Point point1;
			Point point2;
			Point[] pointArray1;
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this._DrawPolygon)
			{
				int num = checked((int)Math.Round((double)this._PolygonWidth / 2));
				Rectangle tabRect = this.GetTabRect(this.SelectedIndex);
				switch (this.Alignment)
				{
					case TabAlignment.Top:
					{
						pointArray1 = new Point[3];
						point2 = new Point(checked(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))) - num), checked(tabRect.Y + tabRect.Height));
						pointArray1[0] = point2;
						point1 = new Point(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))), checked(checked(tabRect.Y + tabRect.Height) - num));
						pointArray1[1] = point1;
						point = new Point(checked(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))) + num), checked(tabRect.Y + tabRect.Height));
						pointArray1[2] = point;
						pointArray = pointArray1;
						break;
					}
					case TabAlignment.Bottom:
					{
						pointArray1 = new Point[3];
						point2 = new Point(checked(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))) - num), tabRect.Y);
						pointArray1[0] = point2;
						point1 = new Point(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))), checked(tabRect.Y + num));
						pointArray1[1] = point1;
						point = new Point(checked(checked(tabRect.X + checked((int)Math.Round((double)tabRect.Width / 2))) + num), tabRect.Y);
						pointArray1[2] = point;
						pointArray = pointArray1;
						break;
					}
					case TabAlignment.Left:
					{
						pointArray1 = new Point[3];
						point = new Point(checked(tabRect.X + tabRect.Width), checked(checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))) - num));
						pointArray1[0] = point;
						point1 = new Point(checked(checked(tabRect.X + tabRect.Width) - num), checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))));
						pointArray1[1] = point1;
						point2 = new Point(checked(tabRect.X + tabRect.Width), checked(checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))) + num));
						pointArray1[2] = point2;
						pointArray = pointArray1;
						break;
					}
					case TabAlignment.Right:
					{
						pointArray1 = new Point[3];
						point2 = new Point(tabRect.X, checked(checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))) - num));
						pointArray1[0] = point2;
						point1 = new Point(checked(tabRect.X + num), checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))));
						pointArray1[1] = point1;
						point = new Point(tabRect.X, checked(checked(tabRect.Y + checked((int)Math.Round((double)tabRect.Height / 2))) + num));
						pointArray1[2] = point;
						pointArray = pointArray1;
						break;
					}
					default:
					{
						pointArray = null;
						break;
					}
				}
				using (SolidBrush solidBrush = new SolidBrush(this._SelectedBorderColor))
				{
					if (pointArray != null)
					{
						graphics.FillPolygon(solidBrush, pointArray);
					}
				}
			}
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
		}

        /// <summary>
        /// Gets the correct tab rect.
        /// </summary>
        /// <param name="tabrect">The tabrect.</param>
        /// <param name="index">The index.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetCorrectTabRect(Rectangle tabrect, int index)
		{
			Rectangle rectangle;
			if (!this._HeaderIndexes.Contains(checked(index + 1)))
			{
				rectangle = tabrect;
			}
			else
			{
				rectangle = ((this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom ? false : true) ? new Rectangle(tabrect.X, tabrect.Y, tabrect.Width, checked(tabrect.Height - 1)) : new Rectangle(tabrect.X, tabrect.Y, checked(tabrect.Width - 1), tabrect.Height));
			}
			return rectangle;
		}

        /// <summary>
        /// Gets the color of the parent.
        /// </summary>
        /// <returns>Color.</returns>
        private Color GetParentColor()
		{
			Color backColor;
			try
			{
				backColor = this.Parent.BackColor;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				backColor = this._ItemColor;
				ProjectData.ClearProjectError();
			}
			return backColor;
		}

        /// <summary>
        /// Gets the tab container.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetTabContainer(TabAlignment align)
		{
			Rectangle rectangle = new Rectangle();
			Rectangle rectangle1;
			System.Drawing.Size size;
			System.Drawing.Size itemSize;
			if (this.TabCount > 0)
			{
				Rectangle tabRect = this.GetTabRect(0);
				switch (align)
				{
					case TabAlignment.Top:
					{
						Point location = tabRect.Location;
						int width = this.Width;
						itemSize = this.ItemSize;
						size = new System.Drawing.Size(width, itemSize.Height);
						rectangle1 = new Rectangle(location, size);
						rectangle = rectangle1;
						break;
					}
					case TabAlignment.Bottom:
					{
						Point point = tabRect.Location;
						int num = this.Width;
						itemSize = this.ItemSize;
						size = new System.Drawing.Size(num, checked(itemSize.Width - 1));
						rectangle1 = new Rectangle(point, size);
						rectangle = rectangle1;
						break;
					}
					case TabAlignment.Left:
					{
						Point location1 = tabRect.Location;
						size = this.ItemSize;
						itemSize = new System.Drawing.Size(checked(size.Height + 3), this.Height);
						rectangle1 = new Rectangle(location1, itemSize);
						rectangle = rectangle1;
						break;
					}
					case TabAlignment.Right:
					{
						Point point1 = tabRect.Location;
						itemSize = this.ItemSize;
						size = new System.Drawing.Size(checked(itemSize.Height + 1), this.Height);
						rectangle1 = new Rectangle(point1, size);
						rectangle = rectangle1;
						break;
					}
				}
			}
			else
			{
				rectangle1 = new Rectangle(0, 0, 0, 0);
				rectangle = rectangle1;
			}
			return rectangle;
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
        /// Raises the <see cref="E:System.Windows.Forms.TabControl.Deselecting" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TabControlCancelEventArgs" /> that contains the event data.</param>
        protected override void OnDeselecting(TabControlCancelEventArgs e)
		{
			if (this._HasAnimation && this.TabPages.Count > 0)
			{
				this._LastIndex = e.TabPageIndex;
			}
		}

        /// <summary>
        /// This member overrides <see cref="M:System.Windows.Forms.Control.OnHandleCreated(System.EventArgs)" />.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
		{
			if (!this._Initialized)
			{
				if (this._HasAnimation)
				{
					int num = this._AnimationSpeed;
					this._AnimationSpeed = 20;
					int count = this.TabPages.Count;
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						this.SelectedIndex = i;
					}
					this.SelectedIndex = 0;
					this._AnimationSpeed = num;
					this._Initialized = true;
				}
			}
			base.OnHandleCreated(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
		{
			this._MouseState = Helpers.MouseState.None;
			this._HotTab = new Rectangle();
			this._HotIndex = -1;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
		{
			int count = checked(this.TabPages.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				if (this.GetTabRect(i).Contains(e.Location))
				{
					if (this._HotTab != this.GetTabRect(i))
					{
						if (!this._HeaderIndexes.Contains(i))
						{
							this._HotTab = this.GetTabRect(i);
							this._HotIndex = i;
							this._MouseState = Helpers.MouseState.Over;
							this.Invalidate();
						}
					}
				}
			}
			base.OnMouseMove(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle correctTabRect;
			Rectangle rectangle;
			Rectangle rectangle1 = new Rectangle();
			Graphics graphics = e.Graphics;
			StringFormat stringFormat = new StringFormat()
			{
				LineAlignment = StringAlignment.Center,
				Alignment = this._ItemTextAlign
			};
			StringFormat stringFormat1 = stringFormat;
			graphics.Clear(this.GetParentColor());
			using (SolidBrush solidBrush = new SolidBrush(this._TabContainerColor))
			{
				graphics.FillRectangle(solidBrush, this.GetTabContainer(this.Alignment));
			}
			using (SolidBrush solidBrush1 = new SolidBrush(this._ItemColor))
			{
				using (Pen pen = new Pen(this._BorderColor))
				{
					if (this.TabCount > 0)
					{
						int tabCount = checked(this.TabCount - 1);
						for (int i = 0; i <= tabCount; i = checked(i + 1))
						{
							solidBrush1.Color = (this._HeaderIndexes.Contains(i) ? this._HeaderItemColor : this._ItemColor);
							correctTabRect = this.GetCorrectTabRect(this.GetTabRect(i), i);
							if (correctTabRect == this._HotTab)
							{
								solidBrush1.Color = (this._HeaderIndexes.Contains(i) ? this._HeaderItemColor : this._HoverColor);
							}
							graphics.FillRectangle(solidBrush1, correctTabRect);
							graphics.DrawRectangle(pen, correctTabRect);
							using (SolidBrush solidBrush2 = new SolidBrush((this._HeaderIndexes.Contains(i) ? this._HeaderForeColor : this._ItemForeColor)))
							{
								if (this.ImageList != null)
								{
									if (this.TabPages[i].ImageIndex != -1)
									{
										if (this.ImageList.Images[this.TabPages[i].ImageIndex] != null)
										{
											Image item = this.ImageList.Images[this.TabPages[i].ImageIndex];
											rectangle = new Rectangle(checked(correctTabRect.X + checked((int)Math.Round((double)this._ImageWidth / 2))), checked(checked(checked(correctTabRect.Y + checked((int)Math.Round((double)correctTabRect.Height / 2))) - checked((int)Math.Round((double)this._ImageWidth / 2))) + 1), this._ImageWidth, this._ImageWidth);
											graphics.DrawImage(item, rectangle);
											correctTabRect = new Rectangle(checked(checked(correctTabRect.X + 20) + this._ImageWidth), correctTabRect.Y, checked(correctTabRect.Width - (checked(20 + this._ImageWidth))), correctTabRect.Height);
										}
									}
									else if (this._ItemTextAlign == StringAlignment.Near)
									{
										correctTabRect = new Rectangle(checked(correctTabRect.X + checked((int)Math.Round((double)this._ImageWidth / 2))), correctTabRect.Y, checked(correctTabRect.Width - checked((int)Math.Round((double)this._ImageWidth / 2))), correctTabRect.Height);
									}
								}
								graphics.DrawString(this.TabPages[i].Text, this.TabPages[i].Font, solidBrush2, correctTabRect, stringFormat1);
							}
						}
						pen.Color = this._HoverBorderColor;
						if (this._HotTab != rectangle1 && this.HotTrack && this.SelectedIndex != this._HotIndex)
						{
							graphics.DrawRectangle(pen, this._HotTab);
						}
					}
					if (this.TabCount > 0)
					{
						correctTabRect = this.GetCorrectTabRect(this.GetTabRect(this.SelectedIndex), this.SelectedIndex);
						solidBrush1.Color = this._SelectedItemColor;
						pen.Color = this._SelectedBorderColor;
						graphics.FillRectangle(solidBrush1, correctTabRect);
						graphics.DrawRectangle(pen, correctTabRect);
						this.DrawPolygon(e);
						if (this._DrawSelectedLine)
						{
							pen.Color = this._SelectedItemLineColor;
							pen.Width = (float)this._SelectedItemLineWidth;
							graphics.DrawLine(pen, correctTabRect.X, checked(checked(correctTabRect.Y + correctTabRect.Height) - checked((int)Math.Round((double)this._SelectedItemLineWidth / 2))), checked(checked(correctTabRect.X + correctTabRect.Width) + 1), checked(checked(correctTabRect.Y + correctTabRect.Height) - checked((int)Math.Round((double)this._SelectedItemLineWidth / 2))));
						}
						using (SolidBrush solidBrush3 = new SolidBrush(this._SelectedForeColor))
						{
							System.Drawing.Font font = new System.Drawing.Font(this.TabPages[this.SelectedIndex].Font.FontFamily, this.TabPages[this.SelectedIndex].Font.Size, (this._SelectedTabIsBold ? FontStyle.Bold : FontStyle.Regular));
							if (this.ImageList != null)
							{
								if (this.TabPages[this.SelectedIndex].ImageIndex != -1)
								{
									if (this.ImageList.Images[this.TabPages[this.SelectedIndex].ImageIndex] != null)
									{
										Image image = this.ImageList.Images[this.TabPages[this.SelectedIndex].ImageIndex];
										rectangle = new Rectangle(checked(correctTabRect.X + checked((int)Math.Round((double)this._ImageWidth / 2))), checked(checked(checked(correctTabRect.Y + checked((int)Math.Round((double)correctTabRect.Height / 2))) - checked((int)Math.Round((double)this._ImageWidth / 2))) + 1), this._ImageWidth, this._ImageWidth);
										graphics.DrawImage(image, rectangle);
										correctTabRect = new Rectangle(checked(checked(correctTabRect.X + 20) + this._ImageWidth), correctTabRect.Y, checked(correctTabRect.Width - (checked(20 + this._ImageWidth))), correctTabRect.Height);
									}
								}
								else if (this._ItemTextAlign == StringAlignment.Near)
								{
									correctTabRect = new Rectangle(checked(correctTabRect.X + checked((int)Math.Round((double)this._ImageWidth / 2))), correctTabRect.Y, checked(correctTabRect.Width - checked((int)Math.Round((double)this._ImageWidth / 2))), correctTabRect.Height);
								}
							}
							graphics.DrawString(this.TabPages[this.SelectedIndex].Text, font, solidBrush3, correctTabRect, stringFormat1);
							font.Dispose();
						}
					}
					stringFormat1.Dispose();
				}
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TabControl.Selecting" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TabControlCancelEventArgs" /> that contains the event data.</param>
        protected override void OnSelecting(TabControlCancelEventArgs e)
		{
			if (this._HeaderIndexes.Contains(e.TabPageIndex))
			{
				e.Cancel = true;
			}
			else if (this._HasAnimation)
			{
				if (this.TabPages.Count > 0)
				{
					if (this._LastIndex >= 0)
					{
						if (this._LastIndex >= e.TabPageIndex)
						{
							this.DoAnimation(this.TabPages[this._LastIndex], this.TabPages[e.TabPageIndex], true);
						}
						else
						{
							this.DoAnimation(this.TabPages[this._LastIndex], this.TabPages[e.TabPageIndex], false);
						}
					}
				}
			}
		}

        /// <summary>
        /// Removes the header.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveHeader(int index)
		{
			try
			{
				this._HeaderIndexes.Remove(index);
				this.Invalidate();
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
		}

        /// <summary>
        /// Occurs when [animation complete].
        /// </summary>
        public event ZeroitMetroTabControl.AnimationCompleteEventHandler AnimationComplete;

        /// <summary>
        /// Delegate AnimationCompleteEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void AnimationCompleteEventHandler(object sender, EventArgs e);
	}
    
}