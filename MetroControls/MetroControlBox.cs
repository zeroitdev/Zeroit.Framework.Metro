// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroControlBox.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class ZeroitMetroControlBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("AreaClicked")]
	[Description("Ein ControlBox-Steuerelement im metro Stil, welches eigene Schaltflächen unterstützt.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroControlBox), "ZeroitMetroControlBox.bmp")]
	public class ZeroitMetroControlBox : Control
	{

        #region Private Fields

        /// <summary>
        /// The areas
        /// </summary>
        private List<Rectangle> _Areas = new List<Rectangle>();

        /// <summary>
        /// The load default areas
        /// </summary>
        private bool _LoadDefaultAreas;

        /// <summary>
        /// The is ready
        /// </summary>
        private bool _IsReady;

        /// <summary>
        /// The draw design mode control
        /// </summary>
        private bool _DrawDesignModeControl;

        /// <summary>
        /// The area collection
        /// </summary>
        private MetroControlBoxAreaCollection _AreaCollection = new MetroControlBoxAreaCollection();

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;

        /// <summary>
        /// The mouse state
        /// </summary>
        private Helpers.MouseState _MouseState;

        /// <summary>
        /// The mouse location
        /// </summary>
        private Point _MouseLocation;

        /// <summary>
        /// The hot area
        /// </summary>
        private Rectangle _HotArea;

        /// <summary>
        /// The hot index
        /// </summary>
        private int _HotIndex;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets the areas.
        /// </summary>
        /// <value>The areas.</value>
        [Browsable(true)]
        [Category("Data")]
        [Description("Sets the areas.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MetroControlBoxAreaCollection Areas
        {
            get
            {
                return _AreaCollection;
            }
            set
            {
                _AreaCollection = value;
                Invalidate();
            }
        }

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
                    this.CreateFormHandlers(value);
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
        /// Gets or sets a value indicating whether to enable design mode control.
        /// </summary>
        /// <value><c>true</c> if design mode control; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to enable design mode control.")]
        public bool DesignModeControl
        {
            get
            {
                return this._DrawDesignModeControl;
            }
            set
            {
                if (this._DrawDesignModeControl != value)
                {
                    this._DrawDesignModeControl = value;
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
        /// Gets a value indicating whether this control is ready.
        /// </summary>
        /// <value><c>true</c> if this instance is ready; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Gets a value indicating whether this control is ready.")]
        private bool IsReady
        {
            get
            {
                return this._IsReady;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to load default areas.
        /// </summary>
        /// <value><c>true</c> if load default areas; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to load default areas.")]
        public bool LoadDefaultAreas
        {
            get
            {
                return this._LoadDefaultAreas;
            }
            set
            {
                this._LoadDefaultAreas = value;
                this._IsReady = false;
                if (!this._LoadDefaultAreas)
                {
                    this._AreaCollection.Clear();
                }
                this.Invalidate();
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
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroControlBox" /> class.
        /// </summary>
        public ZeroitMetroControlBox()
		{
			
			this._LoadDefaultAreas = true;
			this._IsReady = false;
			this._DrawDesignModeControl = true;
			//this._AreaCollection = new MetroControlBoxAreaCollection();
			this._AutoStyle = true;
			this._MouseState = Helpers.MouseState.None;
			this._HotArea = new Rectangle();
			this._HotIndex = 0;
			this.Size = new System.Drawing.Size(128, 32);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			ZeroitMetroControlBox metroControlBox = this;
			this._AreaCollection.ItemAdded += new EventHandler<MetroControlBoxAreaCollectionEventArgs>(metroControlBox.Area_Added);
			ZeroitMetroControlBox metroControlBox1 = this;
			this._AreaCollection.ItemRemoving += new EventHandler<MetroControlBoxAreaCollectionEventArgs>(metroControlBox1.Area_Removed);
			this.CreateFormHandlers(true);
		}


        /// <summary>
        /// Handles the Added event of the Area control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MetroControlBoxAreaCollectionEventArgs"/> instance containing the event data.</param>
        private void Area_Added(object sender, MetroControlBoxAreaCollectionEventArgs e)
		{
			if (e.Item != null)
			{
				ZeroitMetroControlBox metroControlBox = this;
				e.Item.PropertyChanged += new PropertyChangedEventHandler(metroControlBox.Item_PropertyChanged);
			}
			ZeroitMetroControlBox.AreaAddedEventHandler areaAddedEventHandler = this.AreaAdded;
			if (areaAddedEventHandler != null)
			{
				areaAddedEventHandler(this, new MetroControlBoxAreaCollectionEventArgs(e.Item));
			}
			this.RefreshAreas();
		}

        /// <summary>
        /// Handles the Removed event of the Area control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MetroControlBoxAreaCollectionEventArgs"/> instance containing the event data.</param>
        private void Area_Removed(object sender, MetroControlBoxAreaCollectionEventArgs e)
		{
			if (e.Item != null)
			{
				ZeroitMetroControlBox metroControlBox = this;
				e.Item.PropertyChanged -= new PropertyChangedEventHandler(metroControlBox.Item_PropertyChanged);
				this.RefreshAreas();
			}
		}

        /// <summary>
        /// Changes the color brightness.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="correctionFactor">The correction factor.</param>
        /// <returns>Color.</returns>
        private Color ChangeColorBrightness(Color color, float correctionFactor)
		{
			float r = (float)color.R;
			float g = (float)color.G;
			float b = (float)color.B;
			if (correctionFactor >= 0f)
			{
				r = (255f - r) * correctionFactor + r;
				g = (255f - g) * correctionFactor + g;
				b = (255f - b) * correctionFactor + b;
			}
			else
			{
				correctionFactor = 1f + correctionFactor;
				r *= correctionFactor;
				g *= correctionFactor;
				b *= correctionFactor;
			}
			Color color1 = Color.FromArgb((int)color.A, checked((int)Math.Round((double)r)), checked((int)Math.Round((double)g)), checked((int)Math.Round((double)b)));
			return color1;
		}

        /// <summary>
        /// Creates the default areas.
        /// </summary>
        private void CreateDefaultAreas()
		{
			this._IsReady = true;
			MetroControlBoxArea[] metroControlBoxArea = new MetroControlBoxArea[3];
			Design.Style style = Design.Style.Light;
			if (this.Parent is ZeroitMetroForm)
			{
				if (((ZeroitMetroForm)this.Parent).Style == Design.Style.Dark)
				{
					style = Design.Style.Dark;
				}
			}
			else if (this.Parent.BackColor == Color.FromArgb(40, 40, 40))
			{
				style = Design.Style.Dark;
			}
			metroControlBoxArea[0] = new MetroControlBoxArea(MetroControlBoxArea.ControlBoxAreaType.Minimize, style, "defminimize", false);
			metroControlBoxArea[1] = new MetroControlBoxArea(MetroControlBoxArea.ControlBoxAreaType.Maximize, style, "defmaximize", false);
			metroControlBoxArea[2] = new MetroControlBoxArea(MetroControlBoxArea.ControlBoxAreaType.Close, style, "defclose", false);
			this.Areas.AddItems(metroControlBoxArea);
			this.Invalidate();
			this.Size = new System.Drawing.Size(96, 32);
		}

        /// <summary>
        /// Creates the form handlers.
        /// </summary>
        /// <param name="action">if set to <c>true</c> [action].</param>
        private void CreateFormHandlers(bool action)
		{
			try
			{
				if (this.FindForm() is ZeroitMetroForm)
				{
					ZeroitMetroForm metroForm = (ZeroitMetroForm)this.FindForm();
					if (!action)
					{
						ZeroitMetroControlBox metroControlBox = this;
						metroForm.FormStyleChanged -= new EventHandler<ZeroitMetroForm.MetroFormEventArgs>(metroControlBox.FormStyle_Changed);
					}
					else
					{
						ZeroitMetroControlBox metroControlBox1 = this;
						metroForm.FormStyleChanged += new EventHandler<ZeroitMetroForm.MetroFormEventArgs>(metroControlBox1.FormStyle_Changed);
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
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
		{
			this.CreateFormHandlers(true);
			base.CreateHandle();
		}

        /// <summary>
        /// Draws the design mode control.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawDesignModeControl(Graphics g)
		{
			if (this.DesignMode)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					Color color = this.ChangeColorBrightness(this.Parent.BackColor, -0.1f);
					g.Clear(color);
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					using (SolidBrush solidBrush = new SolidBrush(color))
					{
						if ((double)color.GetBrightness() >= 0.3)
						{
							solidBrush.Color = Color.Black;
						}
						else
						{
							solidBrush.Color = Color.White;
						}
						g.DrawString("Gathers ZeroitMetroControlBox\r\n(Will disappear once loaded)", new System.Drawing.Font(this.Parent.Font.FontFamily, 7f), solidBrush, this.ClientRectangle, stringFormat);
					}
				}
			}
		}

        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="c">The c.</param>
        /// <param name="typ">The typ.</param>
        /// <param name="r">The r.</param>
        /// <param name="bc">The bc.</param>
        private void DrawIcon(Graphics g, Color c, MetroControlBoxArea.ControlBoxAreaType typ, Rectangle r, Color bc)
		{
			Rectangle rectangle;
			Point point;
			Point point1;
			switch (typ)
			{
				case MetroControlBoxArea.ControlBoxAreaType.Minimize:
				{
					r = new Rectangle(checked(checked(r.X + checked((int)Math.Round((double)r.Width / 2))) - 4), checked(checked(r.Y + checked((int)Math.Round((double)r.Height / 2))) - 4), 8, 8);
					using (Pen pen = new Pen(c, 3f))
					{
						point1 = new Point(r.X, checked(checked(r.Y + r.Height) - 2));
						point = new Point(checked(r.X + r.Width), checked(checked(r.Y + r.Height) - 2));
						g.DrawLine(pen, point1, point);
					}
					break;
				}
				case MetroControlBoxArea.ControlBoxAreaType.Maximize:
				{
					r = new Rectangle(checked(checked(r.X + checked((int)Math.Round((double)r.Width / 2))) - 4), checked(checked(r.Y + checked((int)Math.Round((double)r.Height / 2))) - 4), 8, 8);
					using (Pen pen1 = new Pen(c, 1f))
					{
						if (this.FindForm().WindowState == FormWindowState.Normal)
						{
							rectangle = new Rectangle(checked(r.X + 3), r.Y, 7, 7);
							g.DrawRectangle(pen1, rectangle);
							rectangle = new Rectangle(checked(r.X + 3), checked(r.Y + 1), 7, 6);
							g.DrawRectangle(pen1, rectangle);
							rectangle = new Rectangle(r.X, checked(r.Y + 4), 7, 6);
							g.DrawRectangle(pen1, rectangle);
							rectangle = new Rectangle(r.X, checked(r.Y + 3), 7, 7);
							g.DrawRectangle(pen1, rectangle);
							using (SolidBrush solidBrush = new SolidBrush(bc))
							{
								rectangle = new Rectangle(checked(r.X + 1), checked(r.Y + 5), 6, 4);
								g.FillRectangle(solidBrush, rectangle);
							}
						}
						else if (this.FindForm().WindowState == FormWindowState.Maximized)
						{
							rectangle = new Rectangle(checked(r.X + 1), checked(r.Y + 1), checked(r.Width - 1), checked(r.Height - 1));
							g.DrawRectangle(pen1, rectangle);
							rectangle = new Rectangle(checked(r.X + 1), checked(r.Y + 2), checked(r.Width - 1), checked(r.Height - 2));
							g.DrawRectangle(pen1, rectangle);
						}
					}
					break;
				}
				case MetroControlBoxArea.ControlBoxAreaType.Close:
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					r = new Rectangle(checked(checked(r.X + checked((int)Math.Round((double)r.Width / 2))) - 4), checked(checked(r.Y + checked((int)Math.Round((double)r.Height / 2))) - 4), 8, 8);
					using (Pen pen2 = new Pen(c, 2f))
					{
						point = new Point(r.X, r.Y);
						point1 = new Point(checked(r.X + r.Width), checked(r.Y + r.Height));
						g.DrawLine(pen2, point, point1);
						point1 = new Point(r.X, checked(r.Y + r.Height));
						point = new Point(checked(r.X + r.Width), r.Y);
						g.DrawLine(pen2, point1, point);
					}
					break;
				}
			}
			g.SmoothingMode = SmoothingMode.HighSpeed;
		}

        /// <summary>
        /// Handles the Changed event of the FormStyle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ZeroitMetroForm.MetroFormEventArgs"/> instance containing the event data.</param>
        private void FormStyle_Changed(object sender, ZeroitMetroForm.MetroFormEventArgs e)
		{
			IEnumerator<MetroControlBoxArea> enumerator = null;
			if (this._AutoStyle)
			{
				using (enumerator)
				{
					enumerator = this._AreaCollection.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.Style = e.FormStyle;
					}
				}
				this.Invalidate();
			}
		}

        /// <summary>
        /// Gets the center point.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="rect">The rect.</param>
        /// <returns>Point.</returns>
        private Point GetCenterPoint(Image img, Rectangle rect)
		{
			Point point = new Point(checked(checked(checked(rect.X + checked((int)Math.Round((double)rect.Width / 2))) - checked((int)Math.Round((double)img.Width / 2))) + 1), checked(checked(checked(rect.Y + checked((int)Math.Round((double)rect.Height / 2))) - checked((int)Math.Round((double)img.Width / 2))) + 1));
			return point;
		}

        /// <summary>
        /// Handles the PropertyChanged event of the Item control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.RefreshAreas();
			this.Invalidate();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
		{
			if (this._AreaCollection.Count > 0)
			{
				if (this._AreaCollection[this._HotIndex].Enabled)
				{
					EventHandler<ZeroitMetroControlBox.MetroControlBoxEventArgs> eventHandler = this.AreaClicked;
					if (eventHandler != null)
					{
						eventHandler(this, new ZeroitMetroControlBox.MetroControlBoxEventArgs(this._AreaCollection[this._HotIndex], this._HotIndex));
					}
					if (this._LoadDefaultAreas)
					{
						string name = this._AreaCollection[this._HotIndex].Name;
						if (Operators.CompareString(name, "defminimize", false) == 0)
						{
							this.FindForm().WindowState = FormWindowState.Minimized;
						}
						else if (Operators.CompareString(name, "defmaximize", false) == 0)
						{
							if (this.FindForm().WindowState != FormWindowState.Maximized)
							{
								this.FindForm().WindowState = FormWindowState.Maximized;
							}
							else
							{
								this.FindForm().WindowState = FormWindowState.Normal;
							}
						}
						else if (Operators.CompareString(name, "defclose", false) == 0)
						{
							if (this.FindForm() != null)
							{
								this.FindForm().Close();
							}
						}
					}
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
			this._HotArea = new Rectangle();
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
		{
			this._MouseLocation = e.Location;
			if (this._Areas.Count > 0)
			{
				this._HotArea = new Rectangle();
				this._HotIndex = 0;
				int count = checked(this._Areas.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					if (this._Areas[i].Contains(this._MouseLocation))
					{
						this._HotArea = this._Areas[i];
						this._HotIndex = i;
						this.Invalidate();
					}
				}
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
			Rectangle item;
			Rectangle rectangle;
			Rectangle item1;
			Point point;
			Rectangle rectangle1;
			Rectangle item2;
			Rectangle rectangle2;
			Rectangle item3;
			Point point1;
			Rectangle rectangle3 = new Rectangle();
			Graphics graphics = e.Graphics;
			if (this._DrawDesignModeControl)
			{
				this.DrawDesignModeControl(graphics);
			}
			if (this._LoadDefaultAreas && !this._IsReady)
			{
				this.CreateDefaultAreas();
			}
			if (this._AreaCollection.Count > 0)
			{
				int count = checked(this._Areas.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					Color defaultColor = this._AreaCollection[i].DefaultColor;
					graphics.FillRectangle(new SolidBrush(defaultColor), this._Areas[i]);
					if (this._Areas[i] != this._HotArea)
					{
						switch (this._AreaCollection[i].AreaType)
						{
							case MetroControlBoxArea.ControlBoxAreaType.Custom:
							{
								if (this._AreaCollection[i].AreaImage != null)
								{
									graphics.DrawImage(this._AreaCollection[i].AreaImage, this.GetCenterPoint(this._AreaCollection[i].AreaImage, this._Areas[i]));
								}
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Minimize:
							{
								this.DrawIcon(graphics, this._AreaCollection[i].IconColor, MetroControlBoxArea.ControlBoxAreaType.Minimize, this._Areas[i], defaultColor);
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Maximize:
							{
								this.DrawIcon(graphics, this._AreaCollection[i].IconColor, MetroControlBoxArea.ControlBoxAreaType.Maximize, this._Areas[i], defaultColor);
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Close:
							{
								this.DrawIcon(graphics, this._AreaCollection[i].IconColor, MetroControlBoxArea.ControlBoxAreaType.Close, this._Areas[i], defaultColor);
								break;
							}
						}
						using (Pen pen = new Pen(this._AreaCollection[i].HighlightColor))
						{
							if (this._AreaCollection[i].IsHighlighted)
							{
								item = this._Areas[i];
								int x = checked(item.X + 1);
								rectangle = this._Areas[i];
								int y = rectangle.Y;
								item1 = this._Areas[i];
								point = new Point(x, checked(checked(y + item1.Height) - 1));
								rectangle1 = this._Areas[i];
								int num = rectangle1.X;
								item2 = this._Areas[i];
								int width = checked(checked(num + item2.Width) - 1);
								rectangle2 = this._Areas[i];
								int y1 = rectangle2.Y;
								item3 = this._Areas[i];
								point1 = new Point(width, checked(checked(y1 + item3.Height) - 1));
								graphics.DrawLine(pen, point, point1);
							}
						}
					}
				}
			}
			if (this._HotArea != rectangle3)
			{
				using (Pen red = new Pen(Brushes.Red))
				{
					using (SolidBrush solidBrush = new SolidBrush(this._AreaCollection[this._HotIndex].HoverColor))
					{
						bool flag = false;
						Color iconColor = this._AreaCollection[this._HotIndex].IconColor;
						switch (this._MouseState)
						{
							case Helpers.MouseState.Over:
							{
								red.Color = Color.Red;
								solidBrush.Color = this._AreaCollection[this._HotIndex].HoverColor;
								break;
							}
							case Helpers.MouseState.Pressed:
							{
								red.Color = Color.DarkRed;
								solidBrush.Color = this._AreaCollection[this._HotIndex].PressedColor;
								if ((this._AreaCollection[this._HotIndex].Style == Design.Style.Light || this._AreaCollection[this._HotIndex].Style == Design.Style.Dark ? true : false))
								{
									flag = true;
								}
								if (!this._AreaCollection[this._HotIndex].InvertIconColor)
								{
									break;
								}
								iconColor = Design.MetroColors.InvertColor(this._AreaCollection[this._HotIndex].IconColor);
								break;
							}
						}
						if (this._AreaCollection[this._HotIndex].Enabled)
						{
							graphics.FillRectangle(solidBrush, this._HotArea);
						}
						Color color = (flag ? Color.White : iconColor);
						switch (this._AreaCollection[this._HotIndex].AreaType)
						{
							case MetroControlBoxArea.ControlBoxAreaType.Custom:
							{
								if (this._AreaCollection[this._HotIndex].AreaImage != null)
								{
									graphics.DrawImage(this._AreaCollection[this._HotIndex].AreaImage, this.GetCenterPoint(this._AreaCollection[this._HotIndex].AreaImage, this._HotArea));
								}
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Minimize:
							{
								this.DrawIcon(graphics, color, MetroControlBoxArea.ControlBoxAreaType.Minimize, this._HotArea, solidBrush.Color);
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Maximize:
							{
								this.DrawIcon(graphics, color, MetroControlBoxArea.ControlBoxAreaType.Maximize, this._HotArea, solidBrush.Color);
								break;
							}
							case MetroControlBoxArea.ControlBoxAreaType.Close:
							{
								this.DrawIcon(graphics, color, MetroControlBoxArea.ControlBoxAreaType.Close, this._HotArea, solidBrush.Color);
								break;
							}
						}
					}
					red.Color = this._AreaCollection[this._HotIndex].HighlightColor;
					if (this._AreaCollection[this._HotIndex].IsHighlighted)
					{
						item2 = this._Areas[this._HotIndex];
						int x1 = item2.X;
						item3 = this._Areas[this._HotIndex];
						int num1 = item3.Y;
						rectangle2 = this._Areas[this._HotIndex];
						point1 = new Point(x1, checked(checked(num1 + rectangle2.Height) - 1));
						rectangle1 = this._Areas[this._HotIndex];
						int x2 = rectangle1.X;
						item1 = this._Areas[this._HotIndex];
						int width1 = checked(checked(x2 + item1.Width) - 1);
						rectangle = this._Areas[this._HotIndex];
						int y2 = rectangle.Y;
						item = this._Areas[this._HotIndex];
						point = new Point(width1, checked(checked(y2 + item.Height) - 1));
						graphics.DrawLine(red, point1, point);
					}
				}
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Refreshes the areas.
        /// </summary>
        public void RefreshAreas()
		{
			System.Drawing.Size areaSize;
			int width = 0;
			int height = 0;
			this._Areas.Clear();
			int count = checked(this._AreaCollection.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				if (this._AreaCollection[i].AreaSize.Height > height)
				{
					areaSize = this._AreaCollection[i].AreaSize;
					height = areaSize.Height;
				}
				areaSize = this._AreaCollection[i].AreaSize;
				int num = areaSize.Width;
				System.Drawing.Size size = this._AreaCollection[i].AreaSize;
				Rectangle rectangle = new Rectangle(width, 0, num, size.Height);
				this._Areas.Add(rectangle);
				areaSize = this._AreaCollection[i].AreaSize;
				width = checked(width + areaSize.Width);
			}
			areaSize = new System.Drawing.Size(width, height);
			this.Size = areaSize;
			this.Invalidate();
			if (this.Parent is ZeroitMetroForm)
			{
				ZeroitMetroForm parent = (ZeroitMetroForm)this.Parent;
				if (parent.MainControlBox == this)
				{
					parent.RelocateMainControlBox();
				}
			}
		}

        /// <summary>
        /// Occurs when [area added].
        /// </summary>
        public event ZeroitMetroControlBox.AreaAddedEventHandler AreaAdded;

        /// <summary>
        /// Occurs when [area clicked].
        /// </summary>
        public event EventHandler<ZeroitMetroControlBox.MetroControlBoxEventArgs> AreaClicked;

        /// <summary>
        /// Delegate AreaAddedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MetroControlBoxAreaCollectionEventArgs"/> instance containing the event data.</param>
        public delegate void AreaAddedEventHandler(object sender, MetroControlBoxAreaCollectionEventArgs e);

        /// <summary>
        /// Class MetroControlBoxEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class MetroControlBoxEventArgs : EventArgs
		{
            /// <summary>
            /// The item
            /// </summary>
            private MetroControlBoxArea _item;

            /// <summary>
            /// The index
            /// </summary>
            private int _Index;

            /// <summary>
            /// Gets the index.
            /// </summary>
            /// <value>The index.</value>
            public int Index
			{
				get
				{
					return this._Index;
				}
			}

            /// <summary>
            /// Gets the item.
            /// </summary>
            /// <value>The item.</value>
            public MetroControlBoxArea Item
			{
				get
				{
					return this._item;
				}
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="MetroControlBoxEventArgs"/> class.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="index">The index.</param>
            public MetroControlBoxEventArgs(MetroControlBoxArea item, int index)
			{
				this._item = item;
				this._Index = index;
			}
		}

	}
}