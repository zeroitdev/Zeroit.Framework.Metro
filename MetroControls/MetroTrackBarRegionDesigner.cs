// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTrackBarRegionDesigner.cs" company="Zeroit Dev Technologies">
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

    //--------------- [Designer(typeof(ZeroitMetroTrackbarRegionDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroTrackbarRegionDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroTrackbarRegionDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMetroTrackbarRegionSmartTagActionList(this.Component));
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
    /// Class ZeroitMetroTrackbarRegionSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroTrackbarRegionSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroTrackbarRegion colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTrackbarRegionSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroTrackbarRegionSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroTrackbarRegion;

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
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use fixed size].
        /// </summary>
        /// <value><c>true</c> if [use fixed size]; otherwise, <c>false</c>.</value>
        public bool UseFixedSize
        {
            get
            {
                return this.colUserControl.UseFixedSize;
            }
            set
            {
                this.colUserControl.UseFixedSize = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use switch borders].
        /// </summary>
        /// <value><c>true</c> if [use switch borders]; otherwise, <c>false</c>.</value>
        public bool UseSwitchBorders
        {
            get
            {
                return this.colUserControl.UseSwitchBorders;
            }
            set
            {
                this.colUserControl.UseSwitchBorders = value;
            }
        }

        /// <summary>
        /// Gets or sets the color left.
        /// </summary>
        /// <value>The color left.</value>
        public Color ColorLeft
        {
            get
            {
                return this.colUserControl.ColorScheme.LeftColor;
            }
            set
            {
                this.colUserControl.ColorScheme.LeftColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color middle.
        /// </summary>
        /// <value>The color middle.</value>
        public Color ColorMiddle
        {
            get
            {
                return this.colUserControl.ColorScheme.MiddleColor;
            }
            set
            {
                this.colUserControl.ColorScheme.MiddleColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color right.
        /// </summary>
        /// <value>The color right.</value>
        public Color ColorRight
        {
            get
            {
                return this.colUserControl.ColorScheme.RightColor;
            }
            set
            {
                this.colUserControl.ColorScheme.RightColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color switch.
        /// </summary>
        /// <value>The color switch.</value>
        public Color ColorSwitch
        {
            get
            {
                return this.colUserControl.ColorScheme.SwitchColor;
            }
            set
            {
                this.colUserControl.ColorScheme.SwitchColor = value;
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
                return this.colUserControl.Style;
            }
            set
            {
                this.colUserControl.Style = value;
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
                return this.colUserControl.Maximum;
            }
            set
            {
                this.colUserControl.Maximum = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return this.colUserControl.Minimum;
            }
            set
            {
                this.colUserControl.Minimum = value;
            }
        }

        /// <summary>
        /// Gets or sets the slider value1.
        /// </summary>
        /// <value>The slider value1.</value>
        public int SliderValue1
        {
            get
            {
                return this.colUserControl.SliderValue1;
            }
            set
            {
                this.colUserControl.SliderValue1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the slider value2.
        /// </summary>
        /// <value>The slider value2.</value>
        public int SliderValue2
        {
            get
            {
                return this.colUserControl.SliderValue2;
            }
            set
            {
                this.colUserControl.SliderValue2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the switch.
        /// </summary>
        /// <value>The width of the switch.</value>
        public int SwitchWidth
        {
            get
            {
                return this.colUserControl.SwitchWidth;
            }
            set
            {
                this.colUserControl.SwitchWidth = value;
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


            items.Add(new DesignerActionPropertyItem("UseFixedSize",
                "Use Fixed Size", "Appearance",
                "Set to use fixed size."));

            items.Add(new DesignerActionPropertyItem("UseSwitchBorders",
                "Use Capsule Borders", "Appearance",
                "Set to show capsule borders."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                "Fore Color", "Appearance",
                "Sets the fore color."));
            
            items.Add(new DesignerActionPropertyItem("ColorLeft",
                "Left Color", "Appearance",
                "Sets the left color."));

            items.Add(new DesignerActionPropertyItem("ColorMiddle",
                "Middle Color", "Appearance",
                "Sets the middle color."));


            items.Add(new DesignerActionPropertyItem("ColorRight",
                "Right Color", "Appearance",
                "Sets the right color."));

            items.Add(new DesignerActionPropertyItem("ColorSwitch",
                "Capsule Color", "Appearance",
                "Sets the capsule color."));


            items.Add(new DesignerActionPropertyItem("Maximum",
                "Maximum", "Appearance",
                "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                "Minimum", "Appearance",
                "Sets the minimum value."));


            items.Add(new DesignerActionPropertyItem("SliderValue1",
                "Main Slider Value", "Appearance",
                "Sets the main slider value."));

            items.Add(new DesignerActionPropertyItem("SliderValue2",
                "Helper Slider", "Appearance",
                "Sets the helper slider value."));


            items.Add(new DesignerActionPropertyItem("SwitchWidth",
                "Capsule Width", "Appearance",
                "Set the capsule size."));
            
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