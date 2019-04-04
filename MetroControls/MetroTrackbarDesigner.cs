// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-29-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroTrackbarDesigner.cs" company="Zeroit Dev Technologies">
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

    //--------------- [Designer(typeof(ZeroitMetroTrackbarDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroTrackbarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroTrackbarDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMetroTrackbarSmartTagActionList(this.Component));
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
    /// Class ZeroitMetroTrackbarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroTrackbarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroTrackbar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroTrackbarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroTrackbarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroTrackbar;

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
        /// Gets or sets a value indicating whether [single slider].
        /// </summary>
        /// <value><c>true</c> if [single slider]; otherwise, <c>false</c>.</value>
        public bool SingleSlider
        {
            get
            {
                return colUserControl.SingleSlider;
            }
            set
            {
                GetPropertyByName("SingleSlider").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the slider style.
        /// </summary>
        /// <value>The slider style.</value>
        public ZeroitMetroTrackbar.MetroSliderStyle SliderStyle
        {
            get
            {
                return colUserControl.SliderStyle;
            }
            set
            {
                GetPropertyByName("SliderStyle").SetValue(colUserControl, value);
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
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the gradient.
        /// </summary>
        /// <value>The color of the gradient.</value>
        public Color GradientColor
        {
            get
            {
                return colUserControl.GradientColor;
            }
            set
            {
                GetPropertyByName("GradientColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get
            {
                return colUserControl.HoverColor;
            }
            set
            {
                GetPropertyByName("HoverColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the left.
        /// </summary>
        /// <value>The color of the left.</value>
        public Color LeftColor
        {
            get
            {
                return colUserControl.LeftColor;
            }
            set
            {
                GetPropertyByName("LeftColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the region.
        /// </summary>
        /// <value>The color of the region.</value>
        public Color RegionColor
        {
            get
            {
                return colUserControl.RegionColor;
            }
            set
            {
                GetPropertyByName("RegionColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the right.
        /// </summary>
        /// <value>The color of the right.</value>
        public Color RightColor
        {
            get
            {
                return colUserControl.RightColor;
            }
            set
            {
                GetPropertyByName("RightColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the slider.
        /// </summary>
        /// <value>The color of the slider.</value>
        public Color SliderColor
        {
            get
            {
                return colUserControl.SliderColor;
            }
            set
            {
                GetPropertyByName("SliderColor").SetValue(colUserControl, value);
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
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
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
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the rail.
        /// </summary>
        /// <value>The width of the rail.</value>
        public int RailWidth
        {
            get
            {
                return colUserControl.RailWidth;
            }
            set
            {
                GetPropertyByName("RailWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the rounding arc.
        /// </summary>
        /// <value>The rounding arc.</value>
        public int RoundingArc
        {
            get
            {
                return colUserControl.RoundingArc;
            }
            set
            {
                GetPropertyByName("RoundingArc").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the second value.
        /// </summary>
        /// <value>The second value.</value>
        public int SecondValue
        {
            get
            {
                return colUserControl.SecondValue;
            }
            set
            {
                GetPropertyByName("SecondValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the slider.
        /// </summary>
        /// <value>The width of the slider.</value>
        public int SliderWidth
        {
            get
            {
                return colUserControl.SliderWidth;
            }
            set
            {
                GetPropertyByName("SliderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
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
            

            items.Add(new DesignerActionPropertyItem("SingleSlider",
                                 "Single Slider", "Appearance",
                                 "Enable start and end slider."));

            items.Add(new DesignerActionPropertyItem("SliderStyle",
                                 "Slider Style", "Appearance",
                                 "Sets the slider style."));
            
            items.Add(new DesignerActionPropertyItem("GradientColor",
                "Gradient Color", "Appearance",
                "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border Color", "Appearance",
                "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("HoverColor",
                "Hover Color", "Appearance",
                "Sets the color when hovered."));

            items.Add(new DesignerActionPropertyItem("LeftColor",
                "Left Color", "Appearance",
                "Sets the left color."));

            items.Add(new DesignerActionPropertyItem("RegionColor",
                "Region Color", "Appearance",
                "Sets the region color."));

            items.Add(new DesignerActionPropertyItem("SliderColor",
                "Slider Color", "Appearance",
                "Sets the slider color."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                "Maximum", "Appearance",
                "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                "Minimum", "Appearance",
                "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("RoundingArc",
                "Radius", "Appearance",
                "Sets the rounding corners of the rounded rectangles."));

            items.Add(new DesignerActionPropertyItem("RailWidth",
                "Rail Width", "Appearance",
                "Sets the rail width."));

            items.Add(new DesignerActionPropertyItem("SliderWidth",
                "Slider Width", "Appearance",
                "Sets the slider width."));

            items.Add(new DesignerActionPropertyItem("SecondValue",
                "Second Value", "Appearance",
                "Sets the second value."));

            items.Add(new DesignerActionPropertyItem("Value",
                "Value", "Appearance",
                "Sets the value of the slider."));


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