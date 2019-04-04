// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTaskPoint.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;

namespace Zeroit.Framework.Metro
{


    /// <summary>
    /// Class ZeroitMetroTaskPoint.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ZeroitMetroTaskPoint : INotifyPropertyChanged
	{

        /// <summary>
        /// The finished
        /// </summary>
        private bool _Finished;

        /// <summary>
        /// The enabled
        /// </summary>
        private bool _Enabled;

        /// <summary>
        /// The circe color
        /// </summary>
        private Color _CirceColor;

        /// <summary>
        /// The icon
        /// </summary>
        private Image _Icon;

        /// <summary>
        /// The circle width
        /// </summary>
        private int _CircleWidth;

        /// <summary>
        /// The text
        /// </summary>
        private string _Text;

        /// <summary>
        /// Gets or sets the color of the circe.
        /// </summary>
        /// <value>The color of the circe.</value>
        public Color CirceColor
		{
			get
			{
				return this._CirceColor;
			}
			set
			{
				this._CirceColor = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("CirceColor"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the width of the circle.
        /// </summary>
        /// <value>The width of the circle.</value>
        public int CircleWidth
		{
			get
			{
				return this._CircleWidth;
			}
			set
			{
				this._CircleWidth = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("CircleWidth"));
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroTaskPoint"/> is enabled.
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
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroTaskPoint"/> is finished.
        /// </summary>
        /// <value><c>true</c> if finished; otherwise, <c>false</c>.</value>
        public bool Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				this._Finished = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Finished"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Image Icon
		{
			get
			{
				return this._Icon;
			}
			set
			{
				this._Icon = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Icon"));
				}
			}
		}

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				this._Text = value;
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs("Text"));
				}
			}
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTaskPoint"/> class.
        /// </summary>
        public ZeroitMetroTaskPoint()
		{
			this._Finished = false;
			this._Enabled = true;
			this._CirceColor = Design.MetroColors.AccentBlue;
			this._Icon = null;
			this._CircleWidth = 20;
			this._Text = string.Empty;
		}


        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
	}
    


}