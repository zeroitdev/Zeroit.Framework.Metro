// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-27-2018
// ***********************************************************************
// <copyright file="MetroTrackbarRegionEventArgs.cs" company="Zeroit Dev Technologies">
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
    /// Class ZeroitMetroTrackbarRegionEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitMetroTrackbarRegionEventArgs : EventArgs
	{
        /// <summary>
        /// The value
        /// </summary>
        private int _Value;

        /// <summary>
        /// The value two
        /// </summary>
        private int _ValueTwo;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
		{
			get
			{
				return this._Value;
			}
		}

        /// <summary>
        /// Gets the value two.
        /// </summary>
        /// <value>The value two.</value>
        public int ValueTwo
		{
			get
			{
				return this._Value;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTrackbarRegionEventArgs"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="valTwo">The value two.</param>
        public ZeroitMetroTrackbarRegionEventArgs(int val, int valTwo)
		{
			this._Value = val;
			this._ValueTwo = valTwo;
		}
	}
}