// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroExpanderActionList.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class MetroExpanderActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class MetroExpanderActionList : DesignerActionList
	{
        /// <summary>
        /// The ex
        /// </summary>
        private ZeroitMetroExpander _ex;

        /// <summary>
        /// The designer action SVC
        /// </summary>
        private DesignerActionUIService designerActionSvc;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ZeroitMetroExpander.eState State
		{
			get
			{
				return this._ex.State;
			}
			set
			{
				this._ex.State = value;
				this.designerActionSvc.Refresh(this._ex);
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroExpanderActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public MetroExpanderActionList(IComponent component) : base(component)
		{
			this.designerActionSvc = null;
			this._ex = (ZeroitMetroExpander)component;
			this.designerActionSvc = (DesignerActionUIService)this.GetService(typeof(DesignerActionUIService));
		}

        /// <summary>
        /// Betas this instance.
        /// </summary>
        public void BETA()
		{
			Interaction.MsgBox("Bitte beachten Sie, dass dieses Control noch in der BETA-Test-Phase ist und somit den ein oder anderen Fehler aufweist.\r\nIch bitte um Ihr Verständnis!", MsgBoxStyle.Information, "Hinweis!");
			this.designerActionSvc.Refresh(this._ex);
		}

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Properties"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("State", "State:", "Properties", "Der Status des Expanders."));
			return designerActionItemCollection;
		}
	}
}