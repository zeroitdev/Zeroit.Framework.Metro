// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTracker.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering metro-style tracker.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("A class for rendering a tracker.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroTracker), "ZeroitMetroTracker.bmp")]
	public class ZeroitMetroTracker : Control
	{

        #region Private Fields
        /// <summary>
        /// The paths
        /// </summary>
        private MetroTrackerPathCollection _paths;

        /// <summary>
        /// The pens
        /// </summary>
        private Dictionary<MetroTrackerPath, Pen> _pens;

        /// <summary>
        /// The brushes
        /// </summary>
        private Dictionary<MetroTrackerPath, Brush> _brushes;

        /// <summary>
        /// The name brushes
        /// </summary>
        private Dictionary<MetroTrackerPath, Brush> _nameBrushes;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The grid color
        /// </summary>
        private Color _GridColor;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The grid style
        /// </summary>
        private Design.GridStyle _GridStyle;

        /// <summary>
        /// The grid size
        /// </summary>
        private int _GridSize;

        /// <summary>
        /// The show path names
        /// </summary>
        private bool _ShowPathNames;

        /// <summary>
        /// The show custom value
        /// </summary>
        private bool _ShowCustomValue;

        /// <summary>
        /// The showed value count
        /// </summary>
        private int _ShowedValueCount;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
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
        /// Gets or sets a value indicating whether to display text.
        /// </summary>
        /// <value><c>true</c> if display text; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to display text.")]
        public bool DisplayText
        {
            get
            {
                return this._ShowCustomValue;
            }
            set
            {
                if (value != this._ShowCustomValue)
                {
                    this._ShowCustomValue = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the grid.
        /// </summary>
        /// <value>The color of the grid.</value>
        [Category("Appearance")]
        [Description("Sets the color of the grid.")]
        public Color GridColor
        {
            get
            {
                return this._GridColor;
            }
            set
            {
                if (value != this._GridColor)
                {
                    this._GridColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the grid.
        /// </summary>
        /// <value>The size of the grid.</value>
        [Category("Appearance")]
        [DefaultValue(10)]
        [Description("Sets the size of the grid.")]
        public int GridSize
        {
            get
            {
                return this._GridSize;
            }
            set
            {
                if (value != this._GridSize)
                {
                    this._GridSize = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the grid style.
        /// </summary>
        /// <value>The grid style.</value>
        [Category("Appearance")]
        [DefaultValue(3)]
        [Description("Sets the grid style.")]
        public Design.GridStyle GridStyle
        {
            get
            {
                return this._GridStyle;
            }
            set
            {
                if (value != this._GridStyle)
                {
                    this._GridStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the paths.
        /// </summary>
        /// <value>The paths.</value>
        [Browsable(true)]
        [Category("Data")]
        [Description("Gets the paths.")]
        public MetroTrackerPathCollection Paths
        {
            get
            {
                return this._paths;
            }
        }

        /// <summary>
        /// Gets or sets the showed value count.
        /// </summary>
        /// <value>The showed value count.</value>
        [Category("Behavior")]
        [DefaultValue(1000)]
        [Description("Sets the showed value count.")]
        public int ShowedValueCount
        {
            get
            {
                return this._ShowedValueCount;
            }
            set
            {
                if (value != this._ShowedValueCount)
                {
                    this._ShowedValueCount = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show path names.
        /// </summary>
        /// <value><c>true</c> if show path names; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to show path names.")]
        public bool ShowPathNames
        {
            get
            {
                return this._ShowPathNames;
            }
            set
            {
                if (value != this._ShowPathNames)
                {
                    this._ShowPathNames = value;
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
                                this._GridColor = Design.MetroColors.PopUpBorder;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.BackColor = Design.MetroColors.LightDefault;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._GridColor = Color.FromArgb(200, Design.MetroColors.LightBorder);
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.BackColor = Design.MetroColors.DarkDefault;
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


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTracker" /> class.
        /// </summary>
        public ZeroitMetroTracker()
		{
			this._paths = new MetroTrackerPathCollection();
			this._pens = new Dictionary<MetroTrackerPath, Pen>();
			this._brushes = new Dictionary<MetroTrackerPath, Brush>();
			this._nameBrushes = new Dictionary<MetroTrackerPath, Brush>();
			this._BorderColor = Design.MetroColors.LightBorder;
			this._GridColor = Design.MetroColors.PopUpBorder;
			this._Style = Design.Style.Light;
			this._GridStyle = Design.GridStyle.Crossed;
			this._GridSize = 10;
			this._ShowPathNames = true;
			this._ShowCustomValue = true;
			this._ShowedValueCount = 1000;
			this._AutoStyle = true;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			this.BackColor = Color.White;
			this._paths = new MetroTrackerPathCollection();
			ZeroitMetroTracker metroTracker = this;
			this.Paths.ItemAdded += new EventHandler<MetroTrackerPathCollectionEventArgs>(metroTracker.Paths_Added);
			ZeroitMetroTracker metroTracker1 = this;
			this.Paths.ItemRemoving += new EventHandler<MetroTrackerPathCollectionEventArgs>(metroTracker1.Paths_Removing);
			this._pens = new Dictionary<MetroTrackerPath, Pen>();
			this._brushes = new Dictionary<MetroTrackerPath, Brush>();
			this._nameBrushes = new Dictionary<MetroTrackerPath, Brush>();
		}


        /// <summary>
        /// Finalizes this instance.
        /// </summary>
        protected virtual void Finalize()
		{
			Dictionary<MetroTrackerPath, Pen>.Enumerator enumerator = new Dictionary<MetroTrackerPath, Pen>.Enumerator();
			Dictionary<MetroTrackerPath, Brush>.Enumerator enumerator1 = new Dictionary<MetroTrackerPath, Brush>.Enumerator();
			Dictionary<MetroTrackerPath, Brush>.Enumerator enumerator2 = new Dictionary<MetroTrackerPath, Brush>.Enumerator();
			try
			{
				enumerator = this._pens.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Value.Dispose();
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			this._pens.Clear();
			try
			{
				enumerator1 = this._brushes.GetEnumerator();
				while (enumerator1.MoveNext())
				{
					enumerator1.Current.Value.Dispose();
				}
			}
			finally
			{
				((IDisposable)enumerator1).Dispose();
			}
			this._brushes.Clear();
			try
			{
				enumerator2 = this._nameBrushes.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Value.Dispose();
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			this._nameBrushes.Clear();
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			StringFormat stringFormat;
			Graphics graphics = e.Graphics;
			float width = (float)((double)this.Width / (double)(checked(this._ShowedValueCount - 1)));
			using (Pen pen = new Pen(this._GridColor))
			{
				switch (this._GridStyle)
				{
					case Design.GridStyle.Horizontal:
					{
						int num = checked((int)Math.Round((double)this.Height / (double)this._GridSize));
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							graphics.DrawLine(pen, 0, checked(i * this._GridSize), this.Width, checked(i * this._GridSize));
						}
						break;
					}
					case Design.GridStyle.Vertical:
					{
						int num1 = checked((int)Math.Round((double)this.Width / (double)this._GridSize));
						for (int j = 1; j <= num1; j = checked(j + 1))
						{
							graphics.DrawLine(pen, checked(j * this._GridSize), 0, checked(j * this._GridSize), this.Height);
						}
						break;
					}
					case Design.GridStyle.Crossed:
					{
						int num2 = checked((int)Math.Round((double)this.Height / (double)this._GridSize));
						for (int k = 1; k <= num2; k = checked(k + 1))
						{
							graphics.DrawLine(pen, 0, checked(k * this._GridSize), this.Width, checked(k * this._GridSize));
						}
						int num3 = checked((int)Math.Round((double)this.Width / (double)this._GridSize));
						for (int l = 1; l <= num3; l = checked(l + 1))
						{
							graphics.DrawLine(pen, checked(l * this._GridSize), 0, checked(l * this._GridSize), this.Height);
						}
						break;
					}
				}
			}
			int count = checked(this.Paths.Count - 1);
			for (int m = 0; m <= count; m = checked(m + 1))
			{
				MetroTrackerPath item = this.Paths[m];
				PointF[] pointF = new PointF[checked(checked(this._ShowedValueCount - 1) + 1)];
				using (IEnumerator<int> enumerator = item.GetEnumerator())
				{
					if (item.Count > this._ShowedValueCount)
					{
						int count1 = checked(checked(item.Count - this._ShowedValueCount) - 1);
						for (int n = 0; n <= count1; n = checked(n + 1))
						{
							enumerator.MoveNext();
						}
					}
					int num4 = checked(this._ShowedValueCount - 1);
					for (int o = 0; o <= num4; o = checked(o + 1))
					{
						float single = (float)o * width;
						if (o < checked(this._ShowedValueCount - item.Count))
						{
							pointF[o] = new PointF(single, (float)this.Height);
						}
						else
						{
							enumerator.MoveNext();
							float height = (float)this.Height - (float)((double)enumerator.Current / (double)item.Maximum) * (float)this.Height;
							pointF[o] = new PointF(single, height);
						}
					}
				}
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
				graphicsPath.AddLines(pointF);
				Point point = new Point(this.Width, this.Height);
				graphicsPath.AddLine(point, new Point(0, this.Height));
				graphicsPath.CloseFigure();
				if (item.IsFilled)
				{
					graphics.FillPath(this._brushes[item], graphicsPath);
				}
				this._pens[item].DashStyle = item.DrawingStyle;
				this._pens[item].DashOffset = item.DashOffset;
				this._pens[item].DashCap = DashCap.Round;
				graphics.DrawPath(this._pens[item], graphicsPath);
				graphicsPath.Dispose();
			}
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
			if (this._ShowPathNames)
			{
				int num5 = Math.Max((checked(this.Height / 2 - 10)) / 18, 1);
				int num6 = 10;
				int x = 0;
				int count2 = checked(this.Paths.Count - 1);
				for (int p = 0; p <= count2; p = checked(p + 1))
				{
					if (p % num5 == 0)
					{
						num6 = checked(x + 10);
					}
					MetroTrackerPath metroTrackerPaths = this.Paths[p];
					Rectangle rectangle = new Rectangle(num6, checked(10 + checked(p % num5 * 18)), 10, 10);
					graphics.FillRectangle(this._nameBrushes[metroTrackerPaths], rectangle);
					graphics.DrawRectangle(Pens.Black, rectangle);
					Rectangle rectangle1 = new Rectangle(checked(checked(rectangle.X + rectangle.Width) + 5), checked(rectangle.Y - 3), checked(this.Width - 25), 18);
					using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
					{
						stringFormat = new StringFormat()
						{
							Alignment = StringAlignment.Near,
							LineAlignment = StringAlignment.Center
						};
						using (StringFormat stringFormat1 = stringFormat)
						{
							graphics.DrawString(metroTrackerPaths.Name, this.Font, solidBrush, rectangle1, stringFormat1);
						}
					}
					SizeF sizeF = graphics.MeasureString(metroTrackerPaths.Name, this.Font);
					float width1 = sizeF.Width;
					if ((float)rectangle1.X + width1 > (float)x)
					{
						x = checked(rectangle1.X + checked((int)Math.Round((double)width1)));
					}
				}
			}
			if (this._ShowCustomValue)
			{
				SizeF sizeF1 = graphics.MeasureString(this.Text, this.Font);
				Rectangle rectangle2 = new Rectangle(checked((int)Math.Round((double)((float)((float)(checked(this.Width - 10)) - sizeF1.Width)))), 10, checked((int)Math.Round((double)((float)(sizeF1.Width + 5f)))), checked((int)Math.Round((double)sizeF1.Height)));
				stringFormat = new StringFormat()
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				};
				using (StringFormat stringFormat2 = stringFormat)
				{
					using (SolidBrush solidBrush1 = new SolidBrush(this.ForeColor))
					{
						graphics.DrawString(this.Text, this.Font, solidBrush1, rectangle2, stringFormat2);
					}
				}
			}
			using (Pen pen1 = new Pen(this._BorderColor))
			{
				Rectangle rectangle3 = new Rectangle(0, 0, checked(this.Width - 1), checked(this.Height - 1));
				graphics.DrawRectangle(pen1, rectangle3);
			}
			base.OnPaint(e);
		}

        /// <summary>
        /// Handles the PropertyChanged event of the Path control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void Path_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			MetroTrackerPath solidBrush = (MetroTrackerPath)sender;
			string propertyName = e.PropertyName;
			if (Operators.CompareString(propertyName, "LineColor", false) == 0)
			{
				this._nameBrushes[solidBrush].Dispose();
				this._nameBrushes[solidBrush] = new SolidBrush(solidBrush.LineColor);
				this._pens[solidBrush].Dispose();
				this._pens[solidBrush] = new Pen(solidBrush.LineColor, solidBrush.LineWidth);
			}
			else if (Operators.CompareString(propertyName, "LineWidth", false) == 0)
			{
				this._pens[solidBrush].Dispose();
				this._pens[solidBrush] = new Pen(solidBrush.LineColor, solidBrush.LineWidth);
			}
			else if (Operators.CompareString(propertyName, "FillColor", false) == 0)
			{
				this._brushes[solidBrush].Dispose();
				this._brushes[solidBrush] = new SolidBrush(solidBrush.FillColor);
			}
			this.Invalidate();
		}

        /// <summary>
        /// Handles the Added event of the Paths control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MetroTrackerPathCollectionEventArgs"/> instance containing the event data.</param>
        private void Paths_Added(object sender, MetroTrackerPathCollectionEventArgs e)
		{
			if (e.Item != null)
			{
				ZeroitMetroTracker metroTracker = this;
				e.Item.PropertyChanged += new PropertyChangedEventHandler(metroTracker.Path_PropertyChanged);
				this._pens.Add(e.Item, new Pen(e.Item.LineColor, e.Item.LineWidth));
				this._brushes.Add(e.Item, new SolidBrush(e.Item.FillColor));
				this._nameBrushes.Add(e.Item, new SolidBrush(e.Item.LineColor));
			}
		}

        /// <summary>
        /// Handles the Removing event of the Paths control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MetroTrackerPathCollectionEventArgs"/> instance containing the event data.</param>
        private void Paths_Removing(object sender, MetroTrackerPathCollectionEventArgs e)
		{
			if (e.Item != null)
			{
				ZeroitMetroTracker metroTracker = this;
				e.Item.PropertyChanged -= new PropertyChangedEventHandler(metroTracker.Path_PropertyChanged);
				this._pens[e.Item].Dispose();
				this._pens.Remove(e.Item);
				this._brushes[e.Item].Dispose();
				this._brushes.Remove(e.Item);
				this._nameBrushes[e.Item].Dispose();
				this._nameBrushes.Remove(e.Item);
			}
		}
	}
}