// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroSeparatorActionList.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class MetroSeparatorActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class MetroSeparatorActionList : DesignerActionList
	{
        /// <summary>
        /// The sep
        /// </summary>
        private ZeroitMetroSeparator _sep;

        /// <summary>
        /// The designer action SVC
        /// </summary>
        private DesignerActionUIService designerActionSvc;

        /// <summary>
        /// Gets or sets the color1.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
		{
			get
			{
				return this._sep.ColorScheme.Color1;
			}
			set
			{
				this._sep.ColorScheme.Color1 = value;
			}
		}

        /// <summary>
        /// Gets or sets the color2.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
		{
			get
			{
				return this._sep.ColorScheme.Color2;
			}
			set
			{
				this._sep.ColorScheme.Color2 = value;
			}
		}

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Design.Orientation Orientation
		{
			get
			{
				return this._sep.Orientation;
			}
			set
			{
				this._sep.Orientation = value;
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
				return this._sep.Style;
			}
			set
			{
				this._sep.Style = value;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroSeparatorActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public MetroSeparatorActionList(IComponent component) : base(component)
		{
			this.designerActionSvc = null;
			this._sep = (ZeroitMetroSeparator)component;
			this.designerActionSvc = (DesignerActionUIService)this.GetService(typeof(DesignerActionUIService));
		}

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Properties"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Color1", "Color1:", "Properties", "Gibt die erste Farbe an. (=Oben/Links)"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Color2", "Color2:", "Properties", "Gibt die zweite Farbe an. (= Unten/Rechts)"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation:", "Properties", "Gibt die Orientierung des Separators an."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Style", "Style:", "Properties", "Setzt das Design."));
			return designerActionItemCollection;
		}
	}
}