// ***********************************************************************
// Assembly         : Zeroit.Framework.Metro
// Author           : ZEROIT
// Created          : 11-28-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="MetroGraph.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Metro
{
    /// <summary>
    /// A class collection for rendering metro graph.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("A class for creating a metro graph.")]
	[DesignerCategory("Code")]
	[ToolboxBitmap(typeof(ZeroitMetroGraph), "ZeroitMetroGraph.bmp")]
    [Designer(typeof(ZeroitMetroGraphDesigner))]
    public class ZeroitMetroGraph : Control
	{

        #region Private Fields
        /// <summary>
        /// The style
        /// </summary>
        private Design.Style _Style;

        /// <summary>
        /// The default color
        /// </summary>
        private Color _DefaultColor;

        /// <summary>
        /// The grid color
        /// </summary>
        private Color _GridColor;

        /// <summary>
        /// The single line color
        /// </summary>
        private Color _SingleLineColor;

        /// <summary>
        /// The classic line color
        /// </summary>
        private Color _ClassicLineColor;

        /// <summary>
        /// The classic fill color
        /// </summary>
        private Color _ClassicFillColor;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color _GradientColor;

        /// <summary>
        /// The hover color
        /// </summary>
        private Color _HoverColor;

        /// <summary>
        /// The hover box color
        /// </summary>
        private Color _HoverBoxColor;

        /// <summary>
        /// The hover box border color
        /// </summary>
        private Color _HoverBoxBorderColor;

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;

        /// <summary>
        /// The draw hover line
        /// </summary>
        private bool _DrawHoverLine;

        /// <summary>
        /// The draw hover data
        /// </summary>
        private bool _DrawHoverData;

        /// <summary>
        /// The classic line thickness
        /// </summary>
        private int _ClassicLineThickness;

        /// <summary>
        /// The use gradient
        /// </summary>
        private bool _UseGradient;

        /// <summary>
        /// The dash style
        /// </summary>
        private System.Drawing.Drawing2D.DashStyle _DashStyle;

        /// <summary>
        /// The draw vertical lines
        /// </summary>
        private bool _DrawVerticalLines;

        /// <summary>
        /// The draw horizontal lines
        /// </summary>
        private bool _DrawHorizontalLines;

        /// <summary>
        /// The single line
        /// </summary>
        private bool _SingleLine;

        /// <summary>
        /// The single line thickness
        /// </summary>
        private int _SingleLineThickness;

        /// <summary>
        /// The single line shadow
        /// </summary>
        private bool _SingleLineShadow;

        /// <summary>
        /// The side padding
        /// </summary>
        private bool _SidePadding;

        /// <summary>
        /// The override minimum
        /// </summary>
        private bool _OverrideMinimum;

        /// <summary>
        /// The override maximum
        /// </summary>
        private bool _OverrideMaximum;

        /// <summary>
        /// The overridden minimum
        /// </summary>
        private int _OverriddenMinimum;

        /// <summary>
        /// The overridden maximum
        /// </summary>
        private int _OverriddenMaximum;

        /// <summary>
        /// The values
        /// </summary>
        private List<float> _Values;

        /// <summary>
        /// The smooth values
        /// </summary>
        private List<float> _SmoothValues;

        /// <summary>
        /// The current value
        /// </summary>
        private float _CurrentValue;

        /// <summary>
        /// The minimum
        /// </summary>
        private float _Minimum;

        /// <summary>
        /// The maximum
        /// </summary>
        private float _Maximum;

        /// <summary>
        /// The index
        /// </summary>
        private int _Index;

        /// <summary>
        /// The gradient point a
        /// </summary>
        private Point _GradientPointA;

        /// <summary>
        /// The gradient point b
        /// </summary>
        private Point _GradientPointB;

        /// <summary>
        /// The f b1
        /// </summary>
        private float FB1;

        /// <summary>
        /// The f b2
        /// </summary>
        private float FB2;

        /// <summary>
        /// The r1
        /// </summary>
        private Rectangle R1;

        /// <summary>
        /// The r2
        /// </summary>
        private Rectangle R2;

        /// <summary>
        /// The r3
        /// </summary>
        private Rectangle R3;

        /// <summary>
        /// The sw
        /// </summary>
        private int SW;

        /// <summary>
        /// The sh
        /// </summary>
        private int SH;

        /// <summary>
        /// The SHH
        /// </summary>
        private int SHH;

        /// <summary>
        /// The last move
        /// </summary>
        private DateTime LastMove;

        /// <summary>
        /// The automatic style
        /// </summary>
        private bool _AutoStyle;

        /// <summary>
        /// The outer border
        /// </summary>
        private bool outerBorder = true;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to draw the outer border.
        /// </summary>
        /// <value><c>true</c> if outer border; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Draws the outer border.")]
        public bool OuterBorder
        {
            get { return outerBorder; }
            set
            {
                outerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically style the control.
        /// </summary>
        /// <value><c>true</c> if automatic style; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to automatically style the control.")]
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
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color BackColor
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
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
                if (value != this._BorderColor)
                {
                    this._BorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the classic fill.
        /// </summary>
        /// <value>The color of the classic fill.</value>
        [Category("Appearance")]
        [Description("Sets the color of the classic fill.")]
        public Color ClassicFillColor
        {
            get
            {
                return this._ClassicFillColor;
            }
            set
            {
                if (value != this._ClassicFillColor)
                {
                    this._ClassicFillColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the classic line.
        /// </summary>
        /// <value>The color of the classic line.</value>
        [Category("Appearance")]
        [Description(".")]
        public Color ClassicLineColor
        {
            get
            {
                return this._ClassicLineColor;
            }
            set
            {
                if (value != this._ClassicLineColor)
                {
                    this._ClassicLineColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the classic line thickness.
        /// </summary>
        /// <value>The classic line thickness.</value>
        [Category("Behavior")]
        [DefaultValue(2)]
        [Description("Sets the classic line thickness.")]
        public int ClassicLineThickness
        {
            get
            {
                return this._ClassicLineThickness;
            }
            set
            {
                if (value != this._ClassicLineThickness)
                {
                    this._ClassicLineThickness = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <value>The context menu strip.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets the dash style.
        /// </summary>
        /// <value>The dash style.</value>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Sets the dash style.")]
        public System.Drawing.Drawing2D.DashStyle DashStyle
        {
            get
            {
                return this._DashStyle;
            }
            set
            {
                if (value != this._DashStyle)
                {
                    this._DashStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the default color.
        /// </summary>
        /// <value>The default color.</value>
        [Category("Appearance")]
        [Description("Sets the default color.")]
        public Color DefaultColor
        {
            get
            {
                return this._DefaultColor;
            }
            set
            {
                if (value != this._DefaultColor)
                {
                    this._DefaultColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw horizontal lines.
        /// </summary>
        /// <value><c>true</c> if draw horizontal lines; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw horizontal lines.")]
        public bool DrawHorizontalLines
        {
            get
            {
                return this._DrawHorizontalLines;
            }
            set
            {
                if (value != this._DrawHorizontalLines)
                {
                    this._DrawHorizontalLines = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw hover data.
        /// </summary>
        /// <value><c>true</c> if [draw hover data]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw hover data.")]
        public bool DrawHoverData
        {
            get
            {
                return this._DrawHoverData;
            }
            set
            {
                if (value != this._DrawHoverData)
                {
                    this._DrawHoverData = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw hover line.
        /// </summary>
        /// <value><c>true</c> if draw hover line; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to draw a hover line.")]
        public bool DrawHoverLine
        {
            get
            {
                return this._DrawHoverLine;
            }
            set
            {
                if (value != this._DrawHoverLine)
                {
                    this._DrawHoverLine = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw vertical lines.
        /// </summary>
        /// <value><c>true</c> if draw vertical lines; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to draw vertical lines.")]
        public bool DrawVerticalLines
        {
            get
            {
                return this._DrawVerticalLines;
            }
            set
            {
                if (value != this._DrawVerticalLines)
                {
                    this._DrawVerticalLines = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the gradient.
        /// </summary>
        /// <value>The color of the gradient.</value>
        [Category("Appearance")]
        [Description("Sets the color of the gradient.")]
        public Color GradientColor
        {
            get
            {
                return this._GradientColor;
            }
            set
            {
                if (value != this._GradientColor)
                {
                    this._GradientColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient point.
        /// </summary>
        /// <value>The gradient point a.</value>
        [Browsable(false)]
        [Category("Appereance")]
        [Description("Sets the gradient point.")]
        public Point GradientPointA
        {
            get
            {
                return this._GradientPointA;
            }
            set
            {
                if (this._GradientPointA != value)
                {
                    this._GradientPointA = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient point.
        /// </summary>
        /// <value>The gradient point b.</value>
        [Browsable(false)]
        [Category("Appereance")]
        [Description("Sets the gradient point.")]
        public Point GradientPointB
        {
            get
            {
                return this._GradientPointB;
            }
            set
            {
                if (this._GradientPointB != value)
                {
                    this._GradientPointB = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the grid.
        /// </summary>
        /// <value>The color of the grid.</value>
        [Category("Appearance")]
        [Description("Sets the color of the grid.")]
        public Color GridColor
        {
            get
            {
                return this._GridColor;
            }
            set
            {
                if (value != this._GridColor)
                {
                    this._GridColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover box border.
        /// </summary>
        /// <value>The color of the hover box border.</value>
        [Category("Appearance")]
        [Description("Sets the color of the hover box border.")]
        public Color HoverBoxBorderColor
        {
            get
            {
                return this._HoverBoxBorderColor;
            }
            set
            {
                if (value != this._HoverBoxBorderColor)
                {
                    this._HoverBoxBorderColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover box.
        /// </summary>
        /// <value>The color of the hover box.</value>
        [Category("Appearance")]
        [Description("Sets the color of the hover box.")]
        public Color HoverBoxColor
        {
            get
            {
                return this._HoverBoxColor;
            }
            set
            {
                if (value != this._HoverBoxColor)
                {
                    this._HoverBoxColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        [Category("Appearance")]
        [Description("Sets the color of the hover.")]
        public Color HoverColor
        {
            get
            {
                return this._HoverColor;
            }
            set
            {
                if (value != this._HoverColor)
                {
                    this._HoverColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Data")]
        [Description("Der Maximumwert des Steuerelements.")]
        public float Maximum
        {
            get
            {
                return this._Maximum;
            }
        }

        /// <summary>
        /// Gets the Minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Data")]
        [Description("Gets the Minimum.")]
        public float Minimum
        {
            get
            {
                return this._Minimum;
            }
        }

        /// <summary>
        /// Gets or sets the overridden maximum.
        /// </summary>
        /// <value>The overridden maximum.</value>
        [Category("Data")]
        [DefaultValue(100)]
        [Description("Sets the overridden maximum.")]
        public int OverriddenMaximum
        {
            get
            {
                return this._OverriddenMaximum;
            }
            set
            {
                if (value != this._OverriddenMaximum)
                {
                    this._OverriddenMaximum = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the overridden minimum.
        /// </summary>
        /// <value>The overridden minimum.</value>
        [Category("Data")]
        [DefaultValue(0)]
        [Description("Sets the overridden minimum.")]
        public int OverriddenMinimum
        {
            get
            {
                return this._OverriddenMinimum;
            }
            set
            {
                if (value != this._OverriddenMinimum)
                {
                    this._OverriddenMinimum = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to override the maximum.
        /// </summary>
        /// <value><c>true</c> if override maximum; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to override the maximum.")]
        public bool OverrideMaximum
        {
            get
            {
                return this._OverrideMaximum;
            }
            set
            {
                if (value != this._OverrideMaximum)
                {
                    this._OverrideMaximum = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to override minimum.
        /// </summary>
        /// <value><c>true</c> if override minimum; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to override minimum.")]
        public bool OverrideMinimum
        {
            get
            {
                return this._OverrideMinimum;
            }
            set
            {
                if (value != this._OverrideMinimum)
                {
                    this._OverrideMinimum = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Windows.Forms.RightToLeft RightToLeft
        {
            [DebuggerNonUserCode]
            get;
            [DebuggerNonUserCode]
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable side padding.
        /// </summary>
        /// <value><c>true</c> if side padding; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to enable side padding.")]
        public bool SidePadding
        {
            get
            {
                return this._SidePadding;
            }
            set
            {
                if (value != this._SidePadding)
                {
                    this._SidePadding = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable single line.
        /// </summary>
        /// <value><c>true</c> if single line; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Sets a value indicating whether to enable single line.")]
        public bool SingleLine
        {
            get
            {
                return this._SingleLine;
            }
            set
            {
                if (value != this._SingleLine)
                {
                    this._SingleLine = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the single line.
        /// </summary>
        /// <value>The color of the single line.</value>
        [Category("Appearance")]
        [Description("Sets the color of the single line.")]
        public Color SingleLineColor
        {
            get
            {
                return this._SingleLineColor;
            }
            set
            {
                if (value != this._SingleLineColor)
                {
                    this._SingleLineColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable single line shadow.
        /// </summary>
        /// <value><c>true</c> if [single line shadow]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to enable single line shadow.")]
        public bool SingleLineShadow
        {
            get
            {
                return this._SingleLineShadow;
            }
            set
            {
                if (value != this._SingleLineShadow)
                {
                    this._SingleLineShadow = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the single line thickness.
        /// </summary>
        /// <value>The single line thickness.</value>
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("Sets the single line thickness.")]
        public int SingleLineThickness
        {
            get
            {
                return this._SingleLineThickness;
            }
            set
            {
                if (value != this._SingleLineThickness)
                {
                    this._SingleLineThickness = value;
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
                                this._DefaultColor = Design.MetroColors.LightDefault;
                                this._GridColor = Design.MetroColors.PopUpBorder;
                                this._SingleLineColor = Design.MetroColors.AccentBlue;
                                this._ClassicLineColor = Design.MetroColors.AccentBlue;
                                this._ClassicFillColor = Color.FromArgb(50, Design.MetroColors.AccentBlue);
                                this._GradientColor = Color.FromArgb(50, Design.MetroColors.ChangeColorBrightness(Design.MetroColors.AccentBlue, -0.2f));
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
                                this._HoverBoxColor = Design.MetroColors.LightDefault;
                                this._HoverBoxBorderColor = Design.MetroColors.PopUpBorder;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.ForeColor = Design.MetroColors.LightFont;
                                break;
                            }
                        case Design.Style.Dark:
                            {
                                this._DefaultColor = Design.MetroColors.DarkDefault;
                                this._GridColor = Design.MetroColors.LightBorder;
                                this._SingleLineColor = Design.MetroColors.AccentBlue;
                                this._ClassicLineColor = Design.MetroColors.AccentBlue;
                                this._ClassicFillColor = Color.FromArgb(50, Design.MetroColors.AccentBlue);
                                this._GradientColor = Color.FromArgb(50, Design.MetroColors.ChangeColorBrightness(Design.MetroColors.AccentBlue, -0.2f));
                                this._HoverColor = Design.MetroColors.AccentLightBlue;
                                this._HoverBoxColor = Design.MetroColors.DarkDefault;
                                this._HoverBoxBorderColor = Design.MetroColors.LightBorder;
                                this._BorderColor = Design.MetroColors.LightBorder;
                                this.ForeColor = Design.MetroColors.DarkFont;
                                break;
                            }
                        default:
                            {
                                this._AutoStyle = false;
                                break;
                            }
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient.
        /// </summary>
        /// <value><c>true</c> if use gradient; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Sets a value indicating whether to use gradient.")]
        public bool UseGradient
        {
            get
            {
                return this._UseGradient;
            }
            set
            {
                if (value != this._UseGradient)
                {
                    this._UseGradient = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        [Browsable(true)]
        [Category("Data")]
        [Description("Sets the values.")]
        public float[] Values
        {
            get
            {
                return this._Values.ToArray();
            }
            set
            {
                this.Clear();
                this.AddValues(value);
                this.FindMinMax();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMetroGraph" /> class.
        /// </summary>
        public ZeroitMetroGraph()
        {
            this._Style = Design.Style.Light;
            this._DefaultColor = Design.MetroColors.LightDefault;
            this._GridColor = Design.MetroColors.PopUpBorder;
            this._SingleLineColor = Design.MetroColors.AccentBlue;
            this._ClassicLineColor = Design.MetroColors.AccentBlue;
            this._ClassicFillColor = Color.FromArgb(50, Design.MetroColors.AccentBlue);
            this._GradientColor = Color.FromArgb(50, Design.MetroColors.ChangeColorBrightness(Design.MetroColors.AccentBlue, -0.2f));
            this._HoverColor = Design.MetroColors.AccentLightBlue;
            this._HoverBoxColor = Design.MetroColors.LightDefault;
            this._HoverBoxBorderColor = Design.MetroColors.PopUpBorder;
            this._BorderColor = Design.MetroColors.LightBorder;
            this._DrawHoverLine = true;
            this._DrawHoverData = true;
            this._ClassicLineThickness = 2;
            this._UseGradient = true;
            this._DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this._DrawVerticalLines = false;
            this._DrawHorizontalLines = true;
            this._SingleLine = false;
            this._SingleLineThickness = 5;
            this._SingleLineShadow = true;
            this._SidePadding = false;
            this._OverrideMinimum = false;
            this._OverrideMaximum = false;
            this._OverriddenMinimum = 0;
            this._OverriddenMaximum = 100;
            this._Minimum = float.MinValue;
            this._Maximum = float.MaxValue;
            this._Index = -1;
            this._GradientPointA = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
            this._GradientPointB = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
            this._AutoStyle = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this._Values = new List<float>();
            this._SmoothValues = new List<float>();
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Adds the value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddValue(float value)
        {
            this._Index = -1;
            this._Values.Add(value);
            this.CleanValues();
            this.FindMinMax();
            this.Invalidate();
        }

        /// <summary>
        /// Adds the values.
        /// </summary>
        /// <param name="values">The values.</param>
        public void AddValues(float[] values)
        {
            this._Index = -1;
            this._Values.AddRange(values);
            this.CleanValues();
            this.FindMinMax();
            this.Invalidate();
        }

        /// <summary>
        /// Cleans the values.
        /// </summary>
        private void CleanValues()
        {
            if (this._Values.Count > this.Width)
            {
                this._Values.RemoveRange(0, checked(this._Values.Count - this.Width));
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            this._Values.Clear();
            this._SmoothValues.Clear();
            this._Maximum = float.MinValue;
            this._Minimum = float.MaxValue;
            this.InvalidateMinMax();
        }

        /// <summary>
        /// Finds the minimum maximum.
        /// </summary>
        private void FindMinMax()
        {
            this._Maximum = float.MinValue;
            this._Minimum = float.MaxValue;
            int count = checked(this._Values.Count - 1);
            for (int i = 0; i <= count; i = checked(i + 1))
            {
                this._CurrentValue = this._Values[i];
                if (this._CurrentValue > this._Maximum)
                {
                    this._Maximum = this._CurrentValue;
                }
                if (this._CurrentValue < this._Minimum)
                {
                    this._Minimum = this._CurrentValue;
                }
            }
            this.InvalidateMinMax();
        }

        /// <summary>
        /// Invalidates the minimum maximum.
        /// </summary>
        private void InvalidateMinMax()
        {
            if (this._OverrideMinimum)
            {
                this._Minimum = (float)this._OverriddenMinimum;
            }
            if (this._OverrideMaximum)
            {
                this._Maximum = (float)this._OverriddenMaximum;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.FindForm() is ZeroitMetroForm)
            {
                if (this._AutoStyle)
                {
                    this.Style = ((ZeroitMetroForm)this.FindForm()).Style;
                    this.Invalidate();
                }
            }
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this._DrawHoverData)
            {
                this._Index = -1;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._DrawHoverData)
            {
                this.R1 = new Rectangle(this.SW, 0, checked(this.Width - this.SW), checked(this.Height - this.SH));
                this.R2 = new Rectangle(checked(this.R1.X + 8), checked(this.R1.Y + 8), checked(this.R1.Width - 16), checked(this.R1.Height - 16));
                this.FB1 = (float)((double)(checked(this.R2.Width - 1)) / (double)(checked(this._Values.Count - 1)));
                if (!this.R1.Contains(e.Location))
                {
                    this._Index = -1;
                }
                else
                {
                    this._Index = checked((int)Math.Round((double)((float)((float)(checked(e.X - this.R2.X)) / this.FB1))));
                    if (this._Index >= this._Values.Count)
                    {
                        this._Index = -1;
                    }
                }
                if (DateTime.Compare(DateTime.Now, this.LastMove.AddMilliseconds(33)) > 0)
                {
                    this.LastMove = DateTime.Now;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Point point;
            Graphics graphics = e.Graphics;
            GraphicsPath graphicsPath = new GraphicsPath();
            this.R1 = new Rectangle(this.SW, 0, checked(this.Width - this.SW), this.Height);
            this.R2 = new Rectangle(checked(this.R1.X + 10), checked(this.R1.Y + 10), checked(this.R1.Width - 20), checked(this.R1.Height - 20));
            if (!this._SidePadding)
            {
                this.R2.X = this.R1.X;
                this.R2.Width = this.R1.Width;
            }
            using (SolidBrush solidBrush = new SolidBrush(this._DefaultColor))
            {
                graphics.FillRectangle(solidBrush, this.R1);
            }
            Pen pen = new Pen(this._GridColor);
            int num = 0;
            do
            {
                this.FB1 = (float)this.R2.Y + (float)((double)(checked(this.R2.Height - 1)) * ((double)num * 0.1));
                if (this._DrawHorizontalLines)
                {
                    graphics.DrawLine(pen, (float)this.R1.X, this.FB1, (float)(checked(this.R1.Right - 1)), this.FB1);
                }
                num = checked(num + 1);
            }
            while (num <= 10);
            if (this._Values.Count > 1)
            {
                PointF[] pointF = new PointF[checked(checked(this._Values.Count + 1) + 1)];
                this.FB1 = (float)((double)(checked(this.R2.Width - 1)) / (double)(checked(this._Values.Count - 1)));
                int count = checked(this._Values.Count - 1);
                for (int i = 0; i <= count; i = checked(i + 1))
                {
                    this.FB2 = (float)this.R2.X + (float)i * this.FB1;
                    this._CurrentValue = (this._Values[i] - this._Minimum) / Math.Max(this._Maximum - this._Minimum, 1f);
                    if (this._CurrentValue > 1f)
                    {
                        this._CurrentValue = 1f;
                    }
                    else if (this._CurrentValue < 0f)
                    {
                        this._CurrentValue = 0f;
                    }
                    pointF[i] = new PointF(this.FB2, (float)(checked((int)Math.Round((double)((float)((float)this.R2.Bottom - (float)(checked(this.R2.Height - 1)) * this._CurrentValue - 1f))))));
                    if (this._DrawVerticalLines)
                    {
                        graphics.DrawLine(pen, this.FB2, (float)this.R1.Y, this.FB2, (float)this.R1.Bottom);
                    }
                }
                pointF[checked(checked((int)pointF.Length) - 2)] = new PointF((float)(checked(this.R2.Right - 1)), (float)(checked(this.R1.Bottom - 1)));
                pointF[checked(checked((int)pointF.Length) - 1)] = new PointF((float)this.R2.X, (float)(checked(this.R1.Bottom - 1)));
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pen.DashStyle = this._DashStyle;
                if (!this._SingleLine)
                {
                    graphicsPath.AddPolygon(pointF);
                    graphicsPath.CloseFigure();
                    pen.Color = this._ClassicLineColor;
                    pen.Width = (float)this._ClassicLineThickness;
                    Color color = (this._UseGradient ? this._GradientColor : this._ClassicFillColor);
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this._GradientPointA, this._GradientPointB, this._ClassicFillColor, color))
                    {
                        graphics.FillPath(linearGradientBrush, graphicsPath);
                        graphics.DrawPath(pen, graphicsPath);
                        using (Pen pen1 = new Pen(linearGradientBrush, 3f))
                        {
                            Point point1 = new Point(0, this.Height);
                            graphics.DrawLine(pen1, graphicsPath.PathPoints[0], point1);
                            point1 = new Point(checked((int)Math.Round((double)((float)(graphicsPath.PathPoints[checked(checked((int)pointF.Length) - 3)].X - 1f)))), checked(checked((int)Math.Round((double)graphicsPath.PathPoints[checked(checked((int)pointF.Length) - 3)].Y)) + 4));
                            point = new Point(checked(this.Width - 2), this.Height);
                            graphics.DrawLine(pen1, point1, point);
                            point = new Point(this.Width, checked(this.Height - 1));
                            point1 = new Point(0, checked(this.Height - 1));
                            graphics.DrawLine(pen1, point, point1);
                        }
                    }
                    graphicsPath.Reset();
                    graphicsPath.Dispose();
                }
                else
                {
                    Array.Resize<PointF>(ref pointF, checked(checked((int)pointF.Length) - 2));
                    if (this._SingleLineShadow)
                    {
                        pen.Color = Design.MetroColors.TextShadow;
                        pen.Width = (float)(checked(this._SingleLineThickness + 2));
                        graphics.DrawLines(pen, pointF);
                    }
                    pen.Color = this._SingleLineColor;
                    pen.Width = (float)this._SingleLineThickness;
                    graphics.DrawLines(pen, pointF);
                }
                if ((!this._DrawHoverData || this._Index < 0 ? false : true))
                {
                    graphics.SetClip(this.R1);
                    Point client = new Point(checked((int)Math.Round((double)pointF[this._Index].X)), checked((int)Math.Round((double)pointF[this._Index].Y)));
                    this.R3 = new Rectangle(checked(client.X - 4), checked(client.Y - 4), 8, 8);
                    pen.Color = this._HoverColor;
                    pen.Width = 1f;
                    if (this._DrawHoverLine)
                    {
                        graphics.DrawLine(pen, client.X, this.R1.Y, client.X, checked(this.R1.Bottom - 1));
                    }
                    SolidBrush foreColor = new SolidBrush(Design.MetroColors.ChangeColorBrightness(this._HoverColor, 0.2f));
                    graphics.FillEllipse(foreColor, this.R3);
                    graphics.DrawEllipse(pen, this.R3);
                    string str = this._Values[this._Index].ToString();
                    SizeF sizeF = graphics.MeasureString(str, this.Font);
                    System.Drawing.Size size = sizeF.ToSize();
                    client = this.PointToClient(Control.MousePosition);
                    this.R3 = new Rectangle(checked(client.X + 24), client.Y, checked(size.Width + 20), checked(size.Height + 10));
                    if (checked(this.R3.X + this.R3.Width) > checked(this.R1.Right - 1))
                    {
                        this.R3.X = checked(checked(client.X - this.R3.Width) - 16);
                    }
                    if (checked(this.R3.Y + this.R3.Height) > checked(this.R1.Bottom - 1))
                    {
                        this.R3.Y = checked(checked(this.R1.Bottom - this.R3.Height) - 1);
                    }
                    foreColor.Color = this._HoverBoxColor;
                    pen.Color = this._HoverBoxBorderColor;
                    graphics.FillRectangle(foreColor, this.R3);
                    graphics.DrawRectangle(pen, this.R3);
                    foreColor.Color = this.ForeColor;
                    System.Drawing.Font font = this.Font;
                    point = new Point(checked(this.R3.X + 10), checked(this.R3.Y + 5));
                    graphics.DrawString(str, font, foreColor, point);
                    foreColor.Dispose();
                }
                graphics.ResetClip();
                graphics.SmoothingMode = SmoothingMode.None;
            }
            pen.Color = this._BorderColor;
            pen.Width = 1f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (outerBorder)
            {
                graphics.DrawRectangle(pen, this.R1.X, this.R1.Y, checked(this.R1.Width - 1), checked(this.R1.Height - 1));
            }
            pen.Dispose();
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.DesignMode)
            {
                this._GradientPointA = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
                this._GradientPointB = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
            }
            base.OnSizeChanged(e);
        }
        /**/
        #endregion

    }

    

}