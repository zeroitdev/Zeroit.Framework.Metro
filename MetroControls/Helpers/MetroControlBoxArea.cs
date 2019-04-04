// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-27-2018
// ***********************************************************************
// <copyright file="MetroControlBoxArea.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class MetroControlBoxArea.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MetroControlBoxArea : INotifyPropertyChanged
	{
        /// <summary>
        /// The enc list
        /// </summary>
        private static List<WeakReference> __ENCList;

        /// <summary>
        /// The area image
        /// </summary>
        private Image _AreaImage;

        /// <summary>
        /// The area size
        /// </summary>
        private Size _AreaSize;

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
        /// The icon color
        /// </summary>
        private Color _IconColor;

        /// <summary>
        /// The area type
        /// </summary>
        private MetroControlBoxArea.ControlBoxAreaType _AreaType;

        /// <summary>
        /// The name
        /// </summary>
        private string _Name;

        /// <summary>
        /// The highlight color
        /// </summary>
        private Color _HighlightColor;

        /// <summary>
        /// The is highlighted
        /// </summary>
        private bool _IsHighlighted;

        /// <summary>
        /// The enabled
        /// </summary>
        private bool _Enabled;

        /// <summary>
        /// The invert icon color
        /// </summary>
        private bool _InvertIconColor;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// Gets or sets the area image.
        /// </summary>
        /// <value>The area image.</value>
        public Image AreaImage
		{
			get
			{
				return this._AreaImage;
			}
			set
			{
				this._AreaImage = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("AreaImage"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the size of the area.
        /// </summary>
        /// <value>The size of the area.</value>
        public Size AreaSize
		{
			get
			{
				return this._AreaSize;
			}
			set
			{
				this._AreaSize = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("AreaSize"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the type of the area.
        /// </summary>
        /// <value>The type of the area.</value>
        public MetroControlBoxArea.ControlBoxAreaType AreaType
		{
			get
			{
				return this._AreaType;
			}
			set
			{
				this._AreaType = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("AreaType"));
				}
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
				return this._DefaultColor;
			}
			set
			{
				this._DefaultColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("DefaultColor"));
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MetroControlBoxArea"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				this._Enabled = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Enabled"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the highlight.
        /// </summary>
        /// <value>The color of the highlight.</value>
        public Color HighlightColor
		{
			get
			{
				return this._HighlightColor;
			}
			set
			{
				this._HighlightColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("HighlightColor"));
				}
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
				return this._HoverColor;
			}
			set
			{
				this._HoverColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("HoverColor"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the icon.
        /// </summary>
        /// <value>The color of the icon.</value>
        public Color IconColor
		{
			get
			{
				return this._IconColor;
			}
			set
			{
				this._IconColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("IconColor"));
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [invert icon color].
        /// </summary>
        /// <value><c>true</c> if [invert icon color]; otherwise, <c>false</c>.</value>
        public bool InvertIconColor
		{
			get
			{
				return this._InvertIconColor;
			}
			set
			{
				this._InvertIconColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("InvertIconColor"));
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this instance is highlighted.
        /// </summary>
        /// <value><c>true</c> if this instance is highlighted; otherwise, <c>false</c>.</value>
        public bool IsHighlighted
		{
			get
			{
				return this._IsHighlighted;
			}
			set
			{
				this._IsHighlighted = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("IsHighlighted"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Name"));
				}
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
				return this._PressedColor;
			}
			set
			{
				this._PressedColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("PressedColor"));
				}
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
				return this._Style;
			}
			set
			{
				if (value == Design.Style.Light)
				{
					this._DefaultColor = Color.White;
					this._HoverColor = Color.FromArgb(240, 240, 240);
					this._PressedColor = Color.FromArgb(0, 122, 204);
					this._IconColor = Color.Black;
				}
				else if (value == Design.Style.Dark)
				{
					this._DefaultColor = Color.FromArgb(40, 40, 40);
					this._HoverColor = Color.FromArgb(63, 63, 63);
					this._PressedColor = Color.FromArgb(0, 122, 204);
					this._IconColor = Color.FromArgb(241, 241, 241);
				}
				this._Style = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Style"));
				}
			}
		}

        /// <summary>
        /// Initializes static members of the <see cref="MetroControlBoxArea"/> class.
        /// </summary>
        [DebuggerNonUserCode]
		static MetroControlBoxArea()
		{
			MetroControlBoxArea.__ENCList = new List<WeakReference>();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroControlBoxArea"/> class.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="size">The size.</param>
        /// <param name="defaultcolor">The defaultcolor.</param>
        /// <param name="hovercolor">The hovercolor.</param>
        /// <param name="pressedcolor">The pressedcolor.</param>
        /// <param name="areatype">The areatype.</param>
        /// <param name="name">The name.</param>
        /// <param name="highlightarea">if set to <c>true</c> [highlightarea].</param>
        public MetroControlBoxArea(Image img, Size size, Color defaultcolor, Color hovercolor, Color pressedcolor, MetroControlBoxArea.ControlBoxAreaType areatype = 0, string name = "", bool highlightarea = false)
		{
			Size size1 = new Size();
			Color color = new Color();
			MetroControlBoxArea.__ENCAddToList(this);
			this._AreaImage = null;
			this._AreaSize = new Size(32, 32);
			this._DefaultColor = Color.White;
			this._HoverColor = Color.FromArgb(240, 240, 240);
			this._PressedColor = Color.FromArgb(0, 122, 204);
			this._IconColor = Color.Black;
			this._AreaType = MetroControlBoxArea.ControlBoxAreaType.Custom;
			this._Name = string.Empty;
			this._HighlightColor = Color.FromArgb(0, 122, 204);
			this._IsHighlighted = false;
			this._Enabled = true;
			this._InvertIconColor = false;
			this._Style = Design.Style.Light;
			if (img != null)
			{
				this._AreaImage = img;
			}
			if (size != size1)
			{
				this._AreaSize = size;
			}
			if (defaultcolor != color)
			{
				this._DefaultColor = defaultcolor;
			}
			if (hovercolor != color)
			{
				this._HoverColor = hovercolor;
			}
			if (this._PressedColor != color)
			{
				this._PressedColor = pressedcolor;
			}
			this._IsHighlighted = highlightarea;
			this._HighlightColor = this._PressedColor;
			this._AreaType = areatype;
			this._Name = name;
			PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs("Items"));
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroControlBoxArea"/> class.
        /// </summary>
        /// <param name="areatype">The areatype.</param>
        /// <param name="style">The style.</param>
        /// <param name="name">The name.</param>
        /// <param name="highlightarea">if set to <c>true</c> [highlightarea].</param>
        public MetroControlBoxArea(MetroControlBoxArea.ControlBoxAreaType areatype, Design.Style style, string name = "", bool highlightarea = false)
		{
			MetroControlBoxArea.__ENCAddToList(this);
			this._AreaImage = null;
			this._AreaSize = new Size(32, 32);
			this._DefaultColor = Color.White;
			this._HoverColor = Color.FromArgb(240, 240, 240);
			this._PressedColor = Color.FromArgb(0, 122, 204);
			this._IconColor = Color.Black;
			this._AreaType = MetroControlBoxArea.ControlBoxAreaType.Custom;
			this._Name = string.Empty;
			this._HighlightColor = Color.FromArgb(0, 122, 204);
			this._IsHighlighted = false;
			this._Enabled = true;
			this._InvertIconColor = false;
			this._Style = Design.Style.Light;
			if (style == Design.Style.Light)
			{
				this._DefaultColor = Design.MetroColors.LightDefault;
				this._HoverColor = Design.MetroColors.LightHover;
				this._PressedColor = Design.MetroColors.AccentBlue;
				this._IconColor = Design.MetroColors.LightIcon;
			}
			else if (style == Design.Style.Dark)
			{
				this._DefaultColor = Design.MetroColors.DarkDefault;
				this._HoverColor = Design.MetroColors.DarkHover;
				this._PressedColor = Design.MetroColors.AccentBlue;
				this._IconColor = Design.MetroColors.LightHover;
			}
			this._HighlightColor = this._PressedColor;
			this._IsHighlighted = highlightarea;
			this._Name = name;
			this._AreaType = areatype;
			PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs("Items"));
			}
		}

        /// <summary>
        /// Encs the add to list.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = MetroControlBoxArea.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				if (MetroControlBoxArea.__ENCList.Count == MetroControlBoxArea.__ENCList.Capacity)
				{
					int item = 0;
					int count = checked(MetroControlBoxArea.__ENCList.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						if (MetroControlBoxArea.__ENCList[i].IsAlive)
						{
							if (i != item)
							{
								MetroControlBoxArea.__ENCList[item] = MetroControlBoxArea.__ENCList[i];
							}
							item = checked(item + 1);
						}
					}
					MetroControlBoxArea.__ENCList.RemoveRange(item, checked(MetroControlBoxArea.__ENCList.Count - item));
					MetroControlBoxArea.__ENCList.Capacity = MetroControlBoxArea.__ENCList.Count;
				}
				MetroControlBoxArea.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Enum ControlBoxAreaType
        /// </summary>
        public enum ControlBoxAreaType
		{
            /// <summary>
            /// The custom
            /// </summary>
            Custom,
            /// <summary>
            /// The minimize
            /// </summary>
            Minimize,
            /// <summary>
            /// The maximize
            /// </summary>
            Maximize,
            /// <summary>
            /// The close
            /// </summary>
            Close
        }
	}
}