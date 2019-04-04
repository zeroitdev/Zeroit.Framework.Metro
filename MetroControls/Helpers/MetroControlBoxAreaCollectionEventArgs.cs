// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-27-2018
// ***********************************************************************
// <copyright file="MetroControlBoxAreaCollectionEventArgs.cs" company="Zeroit Dev Technologies">
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
    /// Class MetroControlBoxAreaCollectionEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MetroControlBoxAreaCollectionEventArgs : EventArgs
	{
        /// <summary>
        /// The item
        /// </summary>
        private MetroControlBoxArea _item;

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
        /// Initializes a new instance of the <see cref="MetroControlBoxAreaCollectionEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public MetroControlBoxAreaCollectionEventArgs(MetroControlBoxArea item)
		{
			this._item = item;
		}
	}
}