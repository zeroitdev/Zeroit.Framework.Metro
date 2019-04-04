// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroCheckBoxActionList.cs" company="Zeroit Dev Technologies">
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
    /// Class MetroCheckBoxActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class MetroCheckBoxActionList : DesignerActionList
	{
        /// <summary>
        /// The sep
        /// </summary>
        private ZeroitMetroCheckBox _sep;

        /// <summary>
        /// The designer action SVC
        /// </summary>
        private DesignerActionUIService designerActionSvc;

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
		{
			get
			{
				return this._sep.ColorScheme.BorderColor;
			}
			set
			{
				this._sep.ColorScheme.BorderColor = value;
			}
		}

        /// <summary>
        /// Gets or sets the color of the box.
        /// </summary>
        /// <value>The color of the box.</value>
        public Color BoxColor
		{
			get
			{
				return this._sep.ColorScheme._InnerBoxColor;
			}
			set
			{
				this._sep.ColorScheme._InnerBoxColor = value;
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
				return this._sep.ColorScheme.FillColor;
			}
			set
			{
				this._sep.ColorScheme.FillColor = value;
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
        /// Initializes a new instance of the <see cref="MetroCheckBoxActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public MetroCheckBoxActionList(IComponent component) : base(component)
		{
			this.designerActionSvc = null;
			this._sep = (ZeroitMetroCheckBox)component;
			this.designerActionSvc = (DesignerActionUIService)this.GetService(typeof(DesignerActionUIService));
		}

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Farb-Eigenschaften"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BoxColor", "BoxColor:", "Farb-Eigenschaften", "Die Hauptfarbe des CheckCircles."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("FillColor", "FillColor:", "Farb-Eigenschaften", "Die Füll-Farbe des CheckCircles."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderColor", "BorderColor:", "Farb-Eigenschaften", "Die Farbe der Umrandung des CheckCircles."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Eigenschaften"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Style", "Style:", "Eigenschaften", "Der Style der MetroProgressbar."));
			return designerActionItemCollection;
		}
	}
}