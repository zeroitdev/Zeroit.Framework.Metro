// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroListbox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// Class ZeroitMetroListbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ListBox" />
    [Description("Ein Listbox-Steuerelement im Metrostil.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ListBox))]
	public class ZeroitMetroListbox : ListBox
	{

        #region Private Fields
        /// <summary>
        /// The selection color
        /// </summary>
        private Color _SelectionColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to enable automatic style.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to enable automatic style.")]
        public bool AutoStyle
        {
            get
            {
                return this._AutoStyle;
            }
            set
            {
                if (this._AutoStyle != value)
                {
                    this._AutoStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance")]
        [Description("Sets the color of the border.")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                if (this._BorderColor != value)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selection.
        /// </summary>
        /// <value>The color of the selection.</value>
        [Category("Appearance")]
        [Description("Sets the color of the selection.")]
        public Color SelectionColor
        {
            get
            {
                return this._SelectionColor;
            }
            set
            {
                if (this._SelectionColor != value)
                {
                    this._SelectionColor = value;
                    this.Invalidate();
                }
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
        [RefreshProperties(RefreshProperties.All)]
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
                    switch (value)
                    {
                        case Design.Style.Light:
                            {
                                this._SelectionColor = Design.MetroColors.AccentBlue;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.BackColor = Design.MetroColors.LightDefault;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._SelectionColor = Design.MetroColors.AccentBlue;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.BackColor = Design.MetroColors.DarkDefault;
                                this.ForeColor = Design.MetroColors.DarkFont;
                                break;
                            }
                    }
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroListbox" /> class.
        /// </summary>
        public ZeroitMetroListbox()
        {
            this._SelectionColor = Design.MetroColors.AccentBlue;
            this._BorderColor = Design.MetroColors.LightBorder;
            this._Style = Design.Style.Light;
            this._AutoStyle = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.DoubleBuffered = true;
            this.BackColor = Design.MetroColors.LightDefault;
            this.ForeColor = Design.MetroColors.LightFont;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ListBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (SolidBrush solidBrush = new SolidBrush(this._SelectionColor))
                {
                    e.Graphics.FillRectangle(solidBrush, e.Bounds);
                }
            }
            using (Pen pen = new Pen(this._BorderColor))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
            }
            if (this.Items.Count > 0)
            {
                using (SolidBrush solidBrush1 = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(this.GetItemText(RuntimeHelpers.GetObjectValue(this.Items[e.Index])), e.Font, solidBrush1, e.Bounds);
                }
            }
            e.DrawFocusRectangle();
            base.OnDrawItem(e);
        }

        /// <summary>
        /// Specifies when the window handle has been created so that column width and other characteristics can be set. Inheriting classes should call base.OnHandleCreated.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            this.Select();
            base.OnHandleCreated(e);
        } 
        #endregion

    }
}