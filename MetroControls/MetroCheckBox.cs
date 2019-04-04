// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroCheckBox.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class ZeroitMetroCheckBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("Click")]
	[Description("MetroCheckbox - Control, das mehrere und eigene Stile unterstützt.")]
	//[Designer(typeof(MetroCheckBoxDesigner))]
	[Designer(typeof(ZeroitMetroCheckBoxDesigner))]
    [DesignerCategory("Code")]
	[ToolboxBitmap(typeof(CheckBox))]
	public class ZeroitMetroCheckBox : Control
	{

        #region Private Fields
        /// <summary>
        /// The rect
        /// </summary>
        private Rectangle rect;

        /// <summary>
        /// The current state
        /// </summary>
        private ZeroitMetroCheckBox.MouseState CurrentState;

        /// <summary>
        /// The text
        /// </summary>
        private string _Text;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The draw borders
        /// </summary>
        private bool _DrawBorders;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// The check on click
        /// </summary>
        private bool _CheckOnClick;

        /// <summary>
        /// The use full detection area
        /// </summary>
        private bool _UseFullDetectionArea;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMetroCheckBox" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Set the control to be checked.")]
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                if (value != this._Checked)
                {
                    this._Checked = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to check on click.
        /// </summary>
        /// <value><c>true</c> if check on click; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Set to checked when clicked.")]
        public bool CheckOnClick
        {
            get
            {
                return this._CheckOnClick;
            }
            set
            {
                if (value != this._CheckOnClick)
                {
                    this._CheckOnClick = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the color scheme")]
        [ReadOnly(false)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ZeroitMetroCheckBox.MainColorScheme ColorScheme
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets a value indicating whether to draw borders.
        /// </summary>
        /// <value><c>true</c> if draw borders; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Set to draw borders.")]
        public bool DrawBorders
        {
            get
            {
                return this._DrawBorders;
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the style.")]
        public Design.Style Style
        {
            get
            {
                return this._Style;
            }
            set
            {
                if (value != this._Style)
                {
                    this._Style = value;
                    if (this._Style == Design.Style.Light)
                    {
                        this.ForeColor = Color.Black;
                        this.ColorScheme._InnerBoxColor = Color.FromArgb(98, 98, 98);
                        this.ColorScheme._BorderColor = Color.FromArgb(250, 250, 250);
                        this.ColorScheme._FillColor = Color.FromArgb(0, 164, 240);
                    }
                    else if (this._Style != Design.Style.Dark)
                    {
                        this._Style = Design.Style.Custom;
                    }
                    else
                    {
                        this.ForeColor = Color.FromArgb(153, 153, 153);
                        this.ColorScheme._InnerBoxColor = Color.FromArgb(98, 98, 98);
                        this.ColorScheme._BorderColor = Color.FromArgb(0, 164, 240);
                        this.ColorScheme._FillColor = Color.FromArgb(0, 164, 240);
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the text.")]
        public override string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                if (Operators.CompareString(value, this._Text, false) != 0)
                {
                    this._Text = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use full detection area.
        /// </summary>
        /// <value><c>true</c> if use full detection area; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Set to use full detection area.")]
        public bool UseFullDetectionArea
        {
            get
            {
                return this._UseFullDetectionArea;
            }
            set
            {
                if (value != this._UseFullDetectionArea)
                {
                    this._UseFullDetectionArea = value;
                }
            }
        }
        /**/
        #endregion


        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroCheckBox" /> class.
        /// </summary>
        public ZeroitMetroCheckBox()
        {
            this.rect = new Rectangle(0, 0, 16, 16);
            this.CurrentState = ZeroitMetroCheckBox.MouseState.None;
            this._Text = this.Name;
            this._Style = Design.Style.Light;
            this._DrawBorders = true;
            this._Checked = true;
            this._CheckOnClick = true;
            this._UseFullDetectionArea = false;
            this.ColorScheme = new ZeroitMetroCheckBox.MainColorScheme();
            this.Size = new System.Drawing.Size(115, 18);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.FixBug();
        }

        #endregion

        /// <summary>
        /// Fixes the bug.
        /// </summary>
        private void FixBug()
		{
			this.Style = Design.Style.Dark;
			this.Invalidate();
			this.Style = Design.Style.Light;
			this.Invalidate();
		}

        /// <summary>
        /// Gets the color of the back.
        /// </summary>
        /// <returns>Color.</returns>
        private Color GetBackColor()
		{
			System.Windows.Forms.Form form = base.FindForm();
			Color backColor = form.BackColor;
			int r = checked(backColor.R + 11);
			backColor = form.BackColor;
			int b = checked(backColor.B + 11);
			backColor = form.BackColor;
			int g = checked(backColor.G + 11);
			if (r >= 255)
			{
				r = 255;
			}
			if (b >= 255)
			{
				b = 255;
			}
			if (g >= 255)
			{
				g = 255;
			}
			return Color.FromArgb(r, g, b);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
		{
			this.CurrentState = ZeroitMetroCheckBox.MouseState.Over;
			this.Invalidate();
			base.OnMouseDown(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
		{
			this.CurrentState = ZeroitMetroCheckBox.MouseState.Over;
			this.Invalidate();
			base.OnMouseEnter(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
		{
			this.CurrentState = ZeroitMetroCheckBox.MouseState.None;
			this.Invalidate();
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
		{
			ZeroitMetroCheckBox.CheckedChangedEventHandler checkedChangedEventHandler;
			if (this.UseFullDetectionArea)
			{
				if (this.CheckOnClick)
				{
					if (this.Checked)
					{
						this.Checked = false;
					}
					else if (!this.Checked)
					{
						this.Checked = true;
					}
					checkedChangedEventHandler = this.CheckedChanged;
					if (checkedChangedEventHandler != null)
					{
						checkedChangedEventHandler(this, new EventArgs());
					}
					this.Invalidate();
				}
			}
			else if (this.rect.Contains(e.Location))
			{
				if (this.CheckOnClick)
				{
					if (this.Checked)
					{
						this.Checked = false;
					}
					else if (!this.Checked)
					{
						this.Checked = true;
					}
					checkedChangedEventHandler = this.CheckedChanged;
					if (checkedChangedEventHandler != null)
					{
						checkedChangedEventHandler(this, new EventArgs());
					}
					this.Invalidate();
				}
			}
			this.CurrentState = ZeroitMetroCheckBox.MouseState.Over;
			base.OnMouseUp(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle rectangle = new Rectangle(4, 4, 9, 9);
			Rectangle rectangle1 = new Rectangle(3, 3, 10, 10);
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			Point[] pointArray = new Point[8];
			Point point = new Point(6, 14);
			pointArray[0] = point;
			Point point1 = new Point(1, 9);
			pointArray[1] = point1;
			Point point2 = new Point(2, 7);
			pointArray[2] = point2;
			Point point3 = new Point(6, 11);
			pointArray[3] = point3;
			Point point4 = new Point(7, 11);
			pointArray[4] = point4;
			Point point5 = new Point(13, 2);
			pointArray[5] = point5;
			Point point6 = new Point(15, 3);
			pointArray[6] = point6;
			Point point7 = new Point(7, 14);
			pointArray[7] = point7;

            switch (this.CurrentState)
			{
				case ZeroitMetroCheckBox.MouseState.None:
				{
					if (this.Checked)
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._FillColor), this.rect);
						graphics.FillRectangle(new SolidBrush(this.ColorScheme._FillColor), rectangle);
					}
					else
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._InnerBoxColor), this.rect);
					}
					break;
				}
				case ZeroitMetroCheckBox.MouseState.Over:
				{
					if (this.Checked)
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._FillColor), this.rect);
						graphics.DrawRectangle(new Pen(this.ColorScheme._BorderColor), rectangle1);
						graphics.FillRectangle(new SolidBrush(this.ColorScheme._FillColor), rectangle);
					}
					else
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._FillColor), this.rect);
					}
					break;
				}
				case ZeroitMetroCheckBox.MouseState.Down:
				{
					if (this.Checked)
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._FillColor), this.rect);
						graphics.DrawRectangle(new Pen(this.ColorScheme._BorderColor), rectangle1);
						graphics.FillRectangle(new SolidBrush(this.ColorScheme._FillColor), rectangle);
					}
					else
					{
						graphics.DrawRectangle(new Pen(this.ColorScheme._FillColor), this.rect);
					}
					break;
				}
			}
			Point point8 = new Point(20, 2);
			Brush solidBrush = new SolidBrush(this.ForeColor);
			graphics.DrawString(this.Text, this.Font, solidBrush, point8);
			base.OnPaint(e);
		}

        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event ZeroitMetroCheckBox.CheckedChangedEventHandler CheckedChanged;

        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Class MainColorScheme.
        /// </summary>
        public class MainColorScheme
		{
            /// <summary>
            /// The inner box color
            /// </summary>
            public Color _InnerBoxColor;

            /// <summary>
            /// The fill color
            /// </summary>
            public Color _FillColor;

            /// <summary>
            /// The border color
            /// </summary>
            public Color _BorderColor;

            /// <summary>
            /// Gets or sets the color of the border.
            /// </summary>
            /// <value>The color of the border.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Gibt die Farbe für die Umrandung an.")]
			public Color BorderColor
			{
				get
				{
					return this._BorderColor;
				}
				set
				{
					if (value != this._BorderColor)
					{
						this._BorderColor = value;
					}
				}
			}

            /// <summary>
            /// Gets or sets the color of the fill.
            /// </summary>
            /// <value>The color of the fill.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Gibt die Farbe des Checked-Symbols an.")]
			public Color FillColor
			{
				get
				{
					return this._FillColor;
				}
				set
				{
					if (value != this._FillColor)
					{
						this._FillColor = value;
					}
				}
			}

            /// <summary>
            /// Gets or sets the color of the inner box.
            /// </summary>
            /// <value>The color of the inner box.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Gibt die Hintergrundfarbe der Checkbox an.")]
			public Color InnerBoxColor
			{
				get
				{
					return this._InnerBoxColor;
				}
				set
				{
					if (value != this._InnerBoxColor)
					{
						this._InnerBoxColor = value;
					}
				}
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="MainColorScheme"/> class.
            /// </summary>
            public MainColorScheme()
			{
				this._InnerBoxColor = Color.FromArgb(98, 98, 98);
				this._FillColor = Color.FromArgb(0, 164, 240);
				this._BorderColor = Color.FromArgb(250, 250, 250);
			}
		}

        /// <summary>
        /// Enum MouseState
        /// </summary>
        private enum MouseState
		{
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The over
            /// </summary>
            Over,
            /// <summary>
            /// Down
            /// </summary>
            Down
        }
	}


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMetroCheckBoxDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMetroCheckBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMetroCheckBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMetroCheckBoxSmartTagActionList(this.Component));
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
    /// Class ZeroitMetroCheckBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMetroCheckBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMetroCheckBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroCheckBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMetroCheckBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMetroCheckBox;

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
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return this.colUserControl.ColorScheme.BorderColor;
            }
            set
            {
                this.colUserControl.ColorScheme.BorderColor = value;
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
                return this.colUserControl.ColorScheme._InnerBoxColor;
            }
            set
            {
                this.colUserControl.ColorScheme._InnerBoxColor = value;
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
                return this.colUserControl.ColorScheme.FillColor;
            }
            set
            {
                this.colUserControl.ColorScheme.FillColor = value;
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "BorderColor", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("BoxColor",
                                 "BoxColor", "Appearance",
                                 "Sets the box color."));

            items.Add(new DesignerActionPropertyItem("FillColor",
                                "FillColor", "Appearance",
                                "Sets the fill color."));

            items.Add(new DesignerActionPropertyItem("Style",
                                "Style", "Appearance",
                                "Sets the style of the checkbox."));


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