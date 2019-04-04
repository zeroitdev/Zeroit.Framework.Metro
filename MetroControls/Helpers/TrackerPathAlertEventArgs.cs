// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-27-2018
// ***********************************************************************
// <copyright file="TrackerPathAlertEventArgs.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class TrackerPathAlertEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TrackerPathAlertEventArgs : EventArgs
	{
        /// <summary>
        /// The item
        /// </summary>
        private MetroTrackerPath _item;

        /// <summary>
        /// The value
        /// </summary>
        private int _value;

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public MetroTrackerPath Item
		{
			get
			{
				return this._item;
			}
		}

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
		{
			get
			{
				return this._value;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerPathAlertEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        public TrackerPathAlertEventArgs(MetroTrackerPath item, int value)
		{
			this._item = item;
			this._value = value;
		}
	}
}