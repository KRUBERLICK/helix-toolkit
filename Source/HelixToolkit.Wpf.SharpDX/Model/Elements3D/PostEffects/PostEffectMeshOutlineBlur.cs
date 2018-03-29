﻿using System.Windows;
using Color = System.Windows.Media.Color;
using Colors = System.Windows.Media.Colors;

namespace HelixToolkit.Wpf.SharpDX
{
    using Model;
    using Model.Scene;
    /// <summary>
    /// Highlight the border of meshes
    /// </summary>
    /// <seealso cref="HelixToolkit.Wpf.SharpDX.Element3D" />
    public class PostEffectMeshOutlineBlur : Element3D
    {
        /// <summary>
        /// Gets or sets the name of the effect.
        /// </summary>
        /// <value>
        /// The name of the effect.
        /// </value>
        public string EffectName
        {
            get { return (string)GetValue(EffectNameProperty); }
            set { SetValue(EffectNameProperty, value); }
        }

        /// <summary>
        /// The effect name property
        /// </summary>
        public static readonly DependencyProperty EffectNameProperty =
            DependencyProperty.Register("EffectName", typeof(string), typeof(PostEffectMeshOutlineBlur), 
                new PropertyMetadata(DefaultRenderTechniqueNames.PostEffectMeshOutlineBlur, (d, e) =>
            {
                ((d as Element3DCore).SceneNode as PostEffectMeshOutlineBlurNode).EffectName = (string)e.NewValue;
            }));


        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// The color property
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(PostEffectMeshOutlineBlur), new PropertyMetadata(Colors.Red, (d, e) =>
            {
                ((d as Element3DCore).SceneNode as PostEffectMeshOutlineBlurNode).Color = ((Color)e.NewValue).ToColor4();
            }));


        /// <summary>
        /// Gets or sets the scale x.
        /// </summary>
        /// <value>
        /// The scale x.
        /// </value>
        public double ScaleX
        {
            get { return (double)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }

        /// <summary>
        /// The scale x property
        /// </summary>
        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register("ScaleX", typeof(double), typeof(PostEffectMeshOutlineBlur), new PropertyMetadata(1.0, (d, e) =>
            {
                ((d as Element3DCore).SceneNode as PostEffectMeshOutlineBlurNode).ScaleX = (float)(double)e.NewValue;
            }));
        /// <summary>
        /// Gets or sets the scale y.
        /// </summary>
        /// <value>
        /// The scale y.
        /// </value>
        public double ScaleY
        {
            get { return (double)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }

        /// <summary>
        /// The scale y property
        /// </summary>
        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register("ScaleY", typeof(double), typeof(PostEffectMeshOutlineBlur), new PropertyMetadata(1.0, (d, e) =>
            {
                ((d as Element3DCore).SceneNode as PostEffectMeshOutlineBlurNode).ScaleY = (float)(double)e.NewValue;
            }));

        /// <summary>
        /// Gets or sets the number of blur pass.
        /// </summary>
        /// <value>
        /// The number of blur pass.
        /// </value>
        public int NumberOfBlurPass
        {
            get { return (int)GetValue(NumberOfBlurPassProperty); }
            set { SetValue(NumberOfBlurPassProperty, value); }
        }

        /// <summary>
        /// The number of blur pass property
        /// </summary>
        public static readonly DependencyProperty NumberOfBlurPassProperty =
            DependencyProperty.Register("NumberOfBlurPass", typeof(int), typeof(PostEffectMeshOutlineBlur), new PropertyMetadata(1, (d,e)=> 
            {
                ((d as Element3DCore).SceneNode as PostEffectMeshOutlineBlurNode).NumberOfBlurPass = (int)e.NewValue;
            }));

        protected override SceneNode OnCreateSceneNode()
        {
            return new PostEffectMeshOutlineBlurNode();
        }

        protected override void AssignDefaultValuesToSceneNode(SceneNode core)
        {
            base.AssignDefaultValuesToSceneNode(core);
            if(core is PostEffectMeshOutlineBlurNode c)
            {
                c.EffectName = EffectName;
                c.Color = Color.ToColor4();
                c.ScaleX = (float)ScaleX;
                c.ScaleY = (float)ScaleY;
                c.NumberOfBlurPass = (int)NumberOfBlurPass;
            }
        }

    }
}
