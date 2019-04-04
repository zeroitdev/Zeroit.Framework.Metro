// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-27-2018
// ***********************************************************************
// <copyright file="MetroTrackerPath.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.CompilerServices;
using System.Threading;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class MetroTrackerPath.
    /// </summary>
    /// <seealso cref="int" />
    /// <seealso cref="System.Collections.ICollection" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MetroTrackerPath : IEnumerable<int>, ICollection, INotifyPropertyChanged
	{
        /// <summary>
        /// The enc list
        /// </summary>
        private static List<WeakReference> __ENCList;

        /// <summary>
        /// The values
        /// </summary>
        private Queue<int> values;

        /// <summary>
        /// The maximum stored
        /// </summary>
        private int maxStored;

        /// <summary>
        /// The line color
        /// </summary>
        private Color _lineColor;

        /// <summary>
        /// The fill color
        /// </summary>
        private Color _fillColor;

        /// <summary>
        /// The is filled
        /// </summary>
        private bool _isFilled;

        /// <summary>
        /// The line width
        /// </summary>
        private float _lineWidth;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum;

        /// <summary>
        /// The alert above
        /// </summary>
        private int _AlertAbove;

        /// <summary>
        /// The alert under
        /// </summary>
        private int _AlertUnder;

        /// <summary>
        /// The perform alers
        /// </summary>
        private bool _performAlers;

        /// <summary>
        /// The is over value
        /// </summary>
        private bool _IsOverValue;

        /// <summary>
        /// The is under value
        /// </summary>
        private bool _IsUnderValue;

        /// <summary>
        /// The style
        /// </summary>
        private MetroTrackerPath.PathStyle _Style;

        /// <summary>
        /// The drawing style
        /// </summary>
        private DashStyle _DrawingStyle;

        /// <summary>
        /// The dash offset
        /// </summary>
        private float _DashOffset;

        /// <summary>
        /// Gets or sets the alert above.
        /// </summary>
        /// <value>The alert above.</value>
        [DefaultValue(100)]
		public int AlertAbove
		{
			get
			{
				return this._AlertAbove;
			}
			set
			{
				if (this._AlertAbove != value)
				{
					this._AlertAbove = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("AlertAbove"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the alert under.
        /// </summary>
        /// <value>The alert under.</value>
        [DefaultValue(0)]
		public int AlertUnder
		{
			get
			{
				return this._AlertUnder;
			}
			set
			{
				if (this._AlertUnder != value)
				{
					this._AlertUnder = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("AlertUnder"));
					}
				}
			}
		}

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
        /// </summary>
        /// <value>The count.</value>
        public int Count
		{
			get
			{
				return this.values.Count;
			}
		}

        /// <summary>
        /// Gets or sets the dash offset.
        /// </summary>
        /// <value>The dash offset.</value>
        public float DashOffset
		{
			get
			{
				return this._DashOffset;
			}
			set
			{
				if (value != this._DashOffset)
				{
					this._DashOffset = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("DashOffset"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the drawing style.
        /// </summary>
        /// <value>The drawing style.</value>
        public DashStyle DrawingStyle
		{
			get
			{
				return this._DrawingStyle;
			}
			set
			{
				if (value != this._DrawingStyle)
				{
					this._DrawingStyle = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("DrawingStyle"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
		{
			get
			{
				return this._fillColor;
			}
			set
			{
				if (this._fillColor != value)
				{
					this._fillColor = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("FillColor"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this instance is filled.
        /// </summary>
        /// <value><c>true</c> if this instance is filled; otherwise, <c>false</c>.</value>
        public bool IsFilled
		{
			get
			{
				return this._isFilled;
			}
			set
			{
				if (this._isFilled != value)
				{
					this._isFilled = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("IsFilled"));
					}
				}
			}
		}

        /// <summary>
        /// Gets a value indicating whether this instance is over value.
        /// </summary>
        /// <value><c>true</c> if this instance is over value; otherwise, <c>false</c>.</value>
        public bool IsOverValue
		{
			get
			{
				return this._IsOverValue;
			}
		}

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
        /// </summary>
        /// <value><c>true</c> if this instance is synchronized; otherwise, <c>false</c>.</value>
        public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

        /// <summary>
        /// Gets a value indicating whether this instance is under value.
        /// </summary>
        /// <value><c>true</c> if this instance is under value; otherwise, <c>false</c>.</value>
        public bool IsUnderValue
		{
			get
			{
				return this._IsUnderValue;
			}
		}

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public Color LineColor
		{
			get
			{
				return this._lineColor;
			}
			set
			{
				if (this._lineColor != value)
				{
					this._lineColor = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("LineColor"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public float LineWidth
		{
			get
			{
				return this._lineWidth;
			}
			set
			{
				if (this._lineWidth != value)
				{
					this._lineWidth = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("LineWidth"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
		{
			get
			{
				return this._maximum;
			}
			set
			{
				if (this._maximum != value)
				{
					this._maximum = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("Maximum"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets the maximum stored values.
        /// </summary>
        /// <value>The maximum stored values.</value>
        public int MaxStoredValues
		{
			get
			{
				return this.maxStored;
			}
			set
			{
				if (this.maxStored != value)
				{
					this.maxStored = value;
					if (this.maxStored < this.values.Count)
					{
						this.CutQueue();
						PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
						if (propertyChangedEventHandler != null)
						{
							propertyChangedEventHandler(this, new PropertyChangedEventArgs("Items"));
						}
					}
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
				return this._name;
			}
			set
			{
				if (Operators.CompareString(this._name, value, false) != 0)
				{
					this._name = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("Name"));
					}
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [perform alerts].
        /// </summary>
        /// <value><c>true</c> if [perform alerts]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
		public bool PerformAlerts
		{
			get
			{
				return this._performAlers;
			}
			set
			{
				if (this._performAlers != value)
				{
					this._performAlers = value;
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("PerformAlerts"));
					}
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
		[Description("Gibt an, welches Farb-Schema der MetroTracker besitzen soll.")]
		public MetroTrackerPath.PathStyle Style
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
					switch (this._Style)
					{
						case MetroTrackerPath.PathStyle.Light:
						{
							this.LineColor = Color.FromArgb(0, 164, 240);
							this.FillColor = Color.FromArgb(35, 0, 164, 240);
							break;
						}
						case MetroTrackerPath.PathStyle.Dark:
						{
							this.LineColor = Color.FromArgb(0, 164, 240);
							this.FillColor = Color.FromArgb(35, 0, 164, 240);
							break;
						}
						case MetroTrackerPath.PathStyle.CPU:
						{
							this.LineColor = Color.FromArgb(17, 125, 187);
							this.FillColor = Color.FromArgb(35, 152, 207, 249);
							break;
						}
						case MetroTrackerPath.PathStyle.Disk:
						{
							this.LineColor = Color.FromArgb(77, 166, 12);
							this.FillColor = Color.FromArgb(35, 103, 239, 0);
							break;
						}
						case MetroTrackerPath.PathStyle.Memory:
						{
							this.LineColor = Color.FromArgb(149, 40, 180);
							this.FillColor = Color.FromArgb(35, 242, 150, 242);
							break;
						}
						case MetroTrackerPath.PathStyle.Ethernet:
						{
							this.LineColor = Color.FromArgb(167, 79, 1);
							this.FillColor = Color.FromArgb(35, 165, 118, 77);
							break;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("LineColor"));
					}
					propertyChangedEventHandler = this.PropertyChanged;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs("Style"));
					}
				}
			}
		}

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
        /// </summary>
        /// <value>The synchronize root.</value>
        public object SyncRoot
		{
			get
			{
				return ((ICollection)this.values).SyncRoot;
			}
		}

        /// <summary>
        /// Initializes static members of the <see cref="MetroTrackerPath"/> class.
        /// </summary>
        [DebuggerNonUserCode]
		static MetroTrackerPath()
		{
			MetroTrackerPath.__ENCList = new List<WeakReference>();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroTrackerPath"/> class.
        /// </summary>
        public MetroTrackerPath()
		{
			MetroTrackerPath.__ENCAddToList(this);
			this._AlertAbove = 100;
			this._AlertUnder = 0;
			this._performAlers = false;
			this._IsOverValue = false;
			this._IsUnderValue = false;
			this._DrawingStyle = DashStyle.Solid;
			this._DashOffset = 2f;
			this.values = new Queue<int>();
			this.maxStored = 100;
			this._maximum = 100;
			this._lineWidth = 1f;
			this._isFilled = false;
		}

        /// <summary>
        /// Encs the add to list.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = MetroTrackerPath.__ENCList;
			Monitor.Enter(_ENCList);
			try
			{
				if (MetroTrackerPath.__ENCList.Count == MetroTrackerPath.__ENCList.Capacity)
				{
					int item = 0;
					int count = checked(MetroTrackerPath.__ENCList.Count - 1);
					for (int i = 0; i <= count; i = checked(i + 1))
					{
						if (MetroTrackerPath.__ENCList[i].IsAlive)
						{
							if (i != item)
							{
								MetroTrackerPath.__ENCList[item] = MetroTrackerPath.__ENCList[i];
							}
							item = checked(item + 1);
						}
					}
					MetroTrackerPath.__ENCList.RemoveRange(item, checked(MetroTrackerPath.__ENCList.Count - item));
					MetroTrackerPath.__ENCList.Capacity = MetroTrackerPath.__ENCList.Count;
				}
				MetroTrackerPath.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
			finally
			{
				Monitor.Exit(_ENCList);
			}
		}

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Add(int value)
		{
			EventHandler<TrackerPathAlertEventArgs> eventHandler;
			this.values.Enqueue(value);
			if (this.maxStored < this.values.Count)
			{
				this.CutQueue();
			}
			if (this.PerformAlerts)
			{
				if (value > this.AlertAbove)
				{
					eventHandler = this.AboveAlerted;
					if (eventHandler != null)
					{
						eventHandler(this, new TrackerPathAlertEventArgs(this, value));
					}
				}
				if (value < this.AlertUnder)
				{
					eventHandler = this.UnderAlerted;
					if (eventHandler != null)
					{
						eventHandler(this, new TrackerPathAlertEventArgs(this, value));
					}
				}
			}
			if (value <= this.AlertAbove)
			{
				this._IsOverValue = false;
			}
			else
			{
				this._IsOverValue = true;
			}
			if (value >= this.AlertUnder)
			{
				this._IsUnderValue = false;
			}
			else
			{
				this._IsUnderValue = true;
			}
			PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs("Items"));
			}
		}

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public void CopyTo(int[] array, int index)
		{
			this.values.CopyTo(array, index);
		}

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(Array array, int index)
		{
			this.values.CopyTo((int[])array, index);
		}

        /// <summary>
        /// Cuts the queue.
        /// </summary>
        private void CutQueue()
		{
			while (this.values.Count > this.maxStored)
			{
				this.values.Dequeue();
			}
		}

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<int> GetEnumerator()
		{
			return (IEnumerator<int>)(object)this.values.GetEnumerator();
		}

        /// <summary>
        /// Gets the enumerator1.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        IEnumerator GetEnumerator1()
		{
			return (IEnumerator)(object)this.values.GetEnumerator();
		}

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<int>)(object)this.values.GetEnumerator();
        }

        /// <summary>
        /// Occurs when [above alerted].
        /// </summary>
        public event EventHandler<TrackerPathAlertEventArgs> AboveAlerted;

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when [under alerted].
        /// </summary>
        public event EventHandler<TrackerPathAlertEventArgs> UnderAlerted;

        /// <summary>
        /// Enum PathStyle
        /// </summary>
        public enum PathStyle
		{
            /// <summary>
            /// The light
            /// </summary>
            Light,
            /// <summary>
            /// The dark
            /// </summary>
            Dark,
            /// <summary>
            /// The cpu
            /// </summary>
            CPU,
            /// <summary>
            /// The disk
            /// </summary>
            Disk,
            /// <summary>
            /// The memory
            /// </summary>
            Memory,
            /// <summary>
            /// The ethernet
            /// </summary>
            Ethernet,
            /// <summary>
            /// The custom
            /// </summary>
            Custom
        }
	}
}