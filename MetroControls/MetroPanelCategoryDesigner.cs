// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-29-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroPanelCategoryDesigner.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMetroPanelCategoryDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroPanelCategoryDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroPanelCategoryDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMetroPanelCategorySmartTagActionList(this.Component));
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
    /// Class ZeroitMetroPanelCategorySmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroPanelCategorySmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroPanelCategory colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroPanelCategorySmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroPanelCategorySmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroPanelCategory;

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
        /// Gets or sets a value indicating whether [use gradient].
        /// </summary>
        /// <value><c>true</c> if [use gradient]; otherwise, <c>false</c>.</value>
        public bool UseGradient
        {
            get
            {
                return colUserControl.UseGradient;
            }
            set
            {
                GetPropertyByName("UseGradient").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use gradient on line].
        /// </summary>
        /// <value><c>true</c> if [use gradient on line]; otherwise, <c>false</c>.</value>
        public bool UseGradientOnLine
        {
            get
            {
                return colUserControl.UseGradientOnLine;
            }
            set
            {
                GetPropertyByName("UseGradientOnLine").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow form moving].
        /// </summary>
        /// <value><c>true</c> if [allow form moving]; otherwise, <c>false</c>.</value>
        public bool AllowFormMoving
        {
            get
            {
                return colUserControl.AllowFormMoving;
            }
            set
            {
                GetPropertyByName("AllowFormMoving").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>The appearance.</value>
        public ZeroitMetroPanelCategory.PanelAppearance Appearance
        {
            get
            {
                return colUserControl.Appearance;
            }
            set
            {
                GetPropertyByName("Appearance").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the line align.
        /// </summary>
        /// <value>The line align.</value>
        public StringAlignment LineAlign
        {
            get
            {
                return colUserControl.LineAlign;
            }
            set
            {
                GetPropertyByName("LineAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the line orientation.
        /// </summary>
        /// <value>The line orientation.</value>
        public Orientation LineOrientation
        {
            get
            {
                return colUserControl.LineOrientation;
            }
            set
            {
                GetPropertyByName("LineOrientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public StringAlignment TextAlign
        {
            get
            {
                return colUserControl.TextAlign;
            }
            set
            {
                GetPropertyByName("TextAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>The color of the accent.</value>
        public Color AccentColor
        {
            get
            {
                return colUserControl.AccentColor;
            }
            set
            {
                GetPropertyByName("AccentColor").SetValue(colUserControl, value);
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
        /// Gets or sets the default color.
        /// </summary>
        /// <value>The default color.</value>
        public Color DefaultColor
        {
            get
            {
                return colUserControl.DefaultColor;
            }
            set
            {
                GetPropertyByName("DefaultColor").SetValue(colUserControl, value);
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
        /// Gets or sets the color of the line gradient.
        /// </summary>
        /// <value>The color of the line gradient.</value>
        public Color LineGradientColor
        {
            get
            {
                return colUserControl.LineGradientColor;
            }
            set
            {
                GetPropertyByName("LineGradientColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient point a.
        /// </summary>
        /// <value>The gradient point a.</value>
        public Point GradientPointA
        {
            get
            {
                return colUserControl.GradientPointA;
            }
            set
            {
                GetPropertyByName("GradientPointA").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient point b.
        /// </summary>
        /// <value>The gradient point b.</value>
        public Point GradientPointB
        {
            get
            {
                return colUserControl.GradientPointB;
            }
            set
            {
                GetPropertyByName("GradientPointB").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        /// <value>The line thickness.</value>
        public int LineThickness
        {
            get
            {
                return colUserControl.LineThickness;
            }
            set
            {
                GetPropertyByName("LineThickness").SetValue(colUserControl, value);
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
        /// Gets or sets the slope a.
        /// </summary>
        /// <value>The slope a.</value>
        public int SlopeA
        {
            get
            {
                return colUserControl.SlopeA;
            }
            set
            {
                GetPropertyByName("SlopeA").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the slope b.
        /// </summary>
        /// <value>The slope b.</value>
        public int SlopeB
        {
            get
            {
                return colUserControl.SlopeB;
            }
            set
            {
                GetPropertyByName("SlopeB").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("UseGradient",
                                 "Use Gradient", "Appearance",
                                 "Set to use gradient."));

            items.Add(new DesignerActionPropertyItem("UseGradientOnLine",
                                 "Gradient On Line", "Appearance",
                                 "Set to use gradient on line."));

            items.Add(new DesignerActionPropertyItem("AllowFormMoving",
                                 "Allow Form Moving", "Appearance",
                                 "Set to allow panel to move form."));

            items.Add(new DesignerActionPropertyItem("Appearance",
                                 "Appearance", "Appearance",
                                 "Sets the appearance parameters."));


            items.Add(new DesignerActionPropertyItem("LineAlign",
                "Line Alignment", "Appearance",
                "Sets the line alignment."));

            items.Add(new DesignerActionPropertyItem("LineOrientation",
                "Line Orientation", "Appearance",
                "Sets the line orientation."));


            items.Add(new DesignerActionPropertyItem("TextAlign",
                "Text Alignment", "Appearance",
                "Sets the text alignment."));

            items.Add(new DesignerActionPropertyItem("AccentColor",
                "Accent Color", "Appearance",
                "Sets the accent color."));


            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border Color", "Appearance",
                "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("DefaultColor",
                "Default Color", "Appearance",
                "Sets the default color."));


            items.Add(new DesignerActionPropertyItem("GradientColor",
                "Gradient Color", "Appearance",
                "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("LineGradientColor",
                "Line Gradient Color", "Appearance",
                "Sets the line's gradient color."));


            items.Add(new DesignerActionPropertyItem("GradientPointA",
                "Gradient Point A", "Appearance",
                "Sets the gradient point."));

            items.Add(new DesignerActionPropertyItem("GradientPointB",
                "Gradient Point B", "Appearance",
                "Sets the gradient point."));


            items.Add(new DesignerActionPropertyItem("LineThickness",
                "Line Thickness", "Appearance",
                "Sets the line thickness."));

            items.Add(new DesignerActionPropertyItem("RoundingArc",
                "Rounding Corners", "Appearance",
                "Sets the rounding corners of the panel."));


            items.Add(new DesignerActionPropertyItem("SlopeA",
                "Slope A", "Appearance",
                "Sets the slope."));

            items.Add(new DesignerActionPropertyItem("SlopeB",
                "Slope B", "Appearance",
                "Sets the slope."));
            

            
            

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