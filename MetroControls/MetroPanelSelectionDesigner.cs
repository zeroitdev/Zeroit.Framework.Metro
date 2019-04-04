// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroPanelSelectionDesigner.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;

namespace Zeroit.Framework.Metro
{

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMetroPanelSelectionDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroPanelSelectionDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroPanelSelectionDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitMetroPanelSelectionSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMetroPanelSelectionSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroPanelSelectionSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroPanelSelection colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroPanelSelectionSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroPanelSelectionSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroPanelSelection;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>The color of the header.</value>
        public Color HeaderColor
        {
            get
            {
                return colUserControl.ColorScheme.HeaderColor;
            }
            set
            {
                colUserControl.ColorScheme.HeaderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the sub text.
        /// </summary>
        /// <value>The color of the sub text.</value>
        public Color SubTextColor
        {
            get
            {
                return colUserControl.ColorScheme.SubTextColor;
            }
            set
            {
                colUserControl.ColorScheme.SubTextColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroPanelSelectionSmartTagActionList"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get
            {
                return colUserControl.Checked;
            }
            set
            {
                colUserControl.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [check on click].
        /// </summary>
        /// <value><c>true</c> if [check on click]; otherwise, <c>false</c>.</value>
        public bool CheckOnClick
        {
            get
            {
                return colUserControl.CheckOnClick;
            }
            set
            {
                colUserControl.CheckOnClick = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color checked.
        /// </summary>
        /// <value>The background color checked.</value>
        public Color BackgroundColorChecked
        {
            get
            {
                return colUserControl.ColorScheme.BackgroundColorChecked;
            }
            set
            {
                colUserControl.ColorScheme.BackgroundColorChecked = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color hover.
        /// </summary>
        /// <value>The background color hover.</value>
        public Color BackgroundColorHover
        {
            get
            {
                return colUserControl.ColorScheme.BackgroundColorHover;
            }
            set
            {
                colUserControl.ColorScheme.BackgroundColorHover = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color normal.
        /// </summary>
        /// <value>The background color normal.</value>
        public Color BackgroundColorNormal
        {
            get
            {
                return colUserControl.ColorScheme.BackgroundColorNormal;
            }
            set
            {
                colUserControl.ColorScheme.BackgroundColorNormal = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.ColorScheme._BorderColor;
            }
            set
            {
                colUserControl.ColorScheme._BorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the border color n.
        /// </summary>
        /// <value>The border color n.</value>
        public Color BorderColorN
        {
            get
            {
                return colUserControl.ColorScheme._BorderColorN;
            }
            set
            {
                colUserControl.ColorScheme._BorderColorN = value;
            }
        }

        /// <summary>
        /// Gets or sets the headline font.
        /// </summary>
        /// <value>The headline font.</value>
        public System.Drawing.Font HeadlineFont
        {
            get
            {
                return colUserControl.HeadlineFont;
            }
            set
            {
                colUserControl.HeadlineFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the sub text font.
        /// </summary>
        /// <value>The sub text font.</value>
        public System.Drawing.Font SubTextFont
        {
            get
            {
                return colUserControl.SubTextFont;
            }
            set
            {
                colUserControl.SubTextFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the text headline.
        /// </summary>
        /// <value>The text headline.</value>
        public string TextHeadline
        {
            get
            {
                return colUserControl.TextHeadline;
            }
            set
            {
                colUserControl.TextHeadline = value;
            }
        }

        /// <summary>
        /// Gets or sets the text subline.
        /// </summary>
        /// <value>The text subline.</value>
        public string TextSubline
        {
            get
            {
                return colUserControl.TextSubline;
            }
            set
            {
                colUserControl.TextSubline = value;
            }
        }


        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("Checked",
                                 "Checked", "Appearance",
                                 "Set to enable the panel checked."));
            
            items.Add(new DesignerActionPropertyItem("CheckOnClick",
                "Check On Click", "Appearance",
                "Set to enable panel to be checked when clicked."));
            
            items.Add(new DesignerActionPropertyItem("BackgroundColorChecked",
                                 "Checked", "Appearance",
                                 "Sets the background color when checked."));


            items.Add(new DesignerActionPropertyItem("BackgroundColorHover",
                "Hovered", "Appearance",
                "Sets the background color when hovered."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorNormal",
                "Inactive", "Appearance",
                "Sets the inactive background color."));


            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border", "Appearance",
                "Sets the active border color."));

            items.Add(new DesignerActionPropertyItem("BorderColorN",
                "Border Inactive", "Appearance",
                "Sets the inactive border color."));

            items.Add(new DesignerActionPropertyItem("HeaderColor",
                "Header Color", "Appearance",
                "Sets the header color."));

            items.Add(new DesignerActionPropertyItem("SubTextColor",
                "Sub-Text Color", "Appearance",
                "Sets the sub-text color."));


            items.Add(new DesignerActionPropertyItem("HeadlineFont",
                "Headline Font", "Appearance",
                "Sets the headline font."));

            items.Add(new DesignerActionPropertyItem("SubTextFont",
                "Sub-Text Font", "Appearance",
                "Sets the sub-text font."));


            items.Add(new DesignerActionPropertyItem("TextHeadline",
                "Headline", "Appearance",
                "Sets the headline text."));

            items.Add(new DesignerActionPropertyItem("TextSubline",
                "Sub-Text", "Appearance",
                "Sets the sub-text."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

}