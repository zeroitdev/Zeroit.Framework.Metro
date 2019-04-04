// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroSeparator.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering a metro-style seperator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("Click")]
	[Designer(typeof(MetroSeparatorDesigner))]
	[DesignerCategory("Value")]
	[ToolboxBitmap(typeof(ZeroitMetroSeparator), "MetroSeperator.bmp")]
	public class ZeroitMetroSeparator : Control
	{

        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The orientation
        /// </summary>
        private Design.Orientation _Orientation;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the color scheme.")]
        [ReadOnly(false)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ZeroitMetroSeparator.MainColorScheme ColorScheme
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("Sets the orientation.")]
        public Design.Orientation Orientation
        {
            get
            {
                return this._Orientation;
            }
            set
            {
                if (value != this._Orientation)
                {
                    this._Orientation = value;
                    if (value != Design.Orientation.Horizontal)
                    {
                        this.Height = this.Width;
                        this.Width = 2;
                    }
                    else
                    {
                        this.Width = this.Height;
                        this.Height = 2;
                    }
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
                    if (this.Style == Design.Style.Light)
                    {
                        this.ColorScheme._Color1 = Color.FromArgb(98, 98, 98);
                        this.ColorScheme._Color2 = Color.White;
                    }
                    else if (this.Style != Design.Style.Dark)
                    {
                        this.Style = Design.Style.Custom;
                    }
                    else
                    {
                        this.ColorScheme._Color1 = Color.FromArgb(51, 51, 51);
                        this.ColorScheme._Color2 = Color.FromArgb(98, 98, 98);
                    }
                    this.Invalidate();
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroSeparator" /> class.
        /// </summary>
        public ZeroitMetroSeparator()
		{
			this._Style = Design.Style.Light;
			this._Orientation = Design.Orientation.Horizontal;
			this.ColorScheme = new ZeroitMetroSeparator.MainColorScheme();
			this.Height = 2;
			this._Style = Design.Style.Light;
		}


        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			if (this.Orientation != Design.Orientation.Horizontal)
			{
				e.Graphics.DrawLine(new Pen(this.ColorScheme.Color1), 0, 0, 0, this.Height);
				e.Graphics.DrawLine(new Pen(this.ColorScheme.Color2), 1, 0, 1, this.Height);
			}
			else
			{
				e.Graphics.DrawLine(new Pen(this.ColorScheme.Color1), 0, 0, this.Width, 0);
				e.Graphics.DrawLine(new Pen(this.ColorScheme.Color2), 0, 1, this.Width, 1);
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.Orientation != Design.Orientation.Horizontal)
			{
				this.Width = 2;
			}
			else
			{
				this.Height = 2;
			}
		}

        /// <summary>
        /// Class MainColorScheme.
        /// </summary>
        public class MainColorScheme
		{
            /// <summary>
            /// The color1
            /// </summary>
            public Color _Color1;

            /// <summary>
            /// The color2
            /// </summary>
            public Color _Color2;

            /// <summary>
            /// Gets or sets the color1.
            /// </summary>
            /// <value>The color1.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Hauptfarbe des Seperators.")]
			public Color Color1
			{
				get
				{
					return this._Color1;
				}
				set
				{
					if (value != this._Color1)
					{
						this._Color1 = value;
					}
				}
			}

            /// <summary>
            /// Gets or sets the color2.
            /// </summary>
            /// <value>The color2.</value>
            [Browsable(true)]
			[Category("Appearance")]
			[Description("Setzt die Farbe für den Akzent des Seperators.")]
			public Color Color2
			{
				get
				{
					return this._Color2;
				}
				set
				{
					if (value != this.Color2)
					{
						this._Color2 = value;
					}
				}
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="MainColorScheme"/> class.
            /// </summary>
            public MainColorScheme()
			{
				this._Color1 = Color.FromArgb(98, 98, 98);
				this._Color2 = Color.White;
			}
		}
	}
}