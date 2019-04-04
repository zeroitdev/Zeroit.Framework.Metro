// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroCheckBoxDesigner.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class MetroCheckBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class MetroCheckBoxDesigner : ControlDesigner
	{
        /// <summary>
        /// The lists
        /// </summary>
        private DesignerActionListCollection lists;

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.lists == null)
				{
					this.lists = new DesignerActionListCollection();
					this.lists.Add(new MetroCheckBoxActionList(this.Component));
				}
				return this.lists;
			}
		}

        /// <summary>
        /// Gets the host control.
        /// </summary>
        /// <value>The host control.</value>
        private ZeroitMetroCheckBox HostControl
		{
			get
			{
				return (ZeroitMetroCheckBox)this.Control;
			}
		}

        /// <summary>
        /// Gets the selection rules that indicate the movement capabilities of a component.
        /// </summary>
        /// <value>The selection rules.</value>
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
		{
			get
			{
				return (SelectionRules)268435456 | (SelectionRules)4 | System.Windows.Forms.Design.SelectionRules.RightSizeable;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroCheckBoxDesigner"/> class.
        /// </summary>
        [DebuggerNonUserCode]
		public MetroCheckBoxDesigner()
		{
		}

        /// <summary>
        /// Allows a designer to change or remove items from the set of properties that it exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
        /// </summary>
        /// <param name="properties">The properties for the class of the component.</param>
        protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("BackgroundImage");
			properties.Remove("BackgroundImageLayout");
			properties.Remove("BorderStyle");
			properties.Remove("RightToLeft");
			base.PostFilterProperties(properties);
		}
	}
}