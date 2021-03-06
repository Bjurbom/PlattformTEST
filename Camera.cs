﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plattformer_test
{
    public class Camera
    {
        Matrix transform;
        Vector2 center;
        Viewport viewport;

        float zoom = 1;
        float rotation = 0;

        #region Properties
        public Matrix Transform
        {
            get
            {
                return transform;
            }
        }

        public float X
        {
            get
            {
                return center.X;
            }
            set
            {
                center.X = value;
            }
        }

        public float Y
        {
            get
            {
                return center.Y;
            }
            set
            {
                center.Y = value;
            }
        }

        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                //gör så att man kan inte zooma ut föralltid (kan ändras)
                if (zoom < 0.1f)
                {
                    zoom = 0.1f;
                }
            }
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }
        #endregion


        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
        }

        public void Update(Vector2 position)
        {
            //får centern av spelet
            center = new Vector2(position.X + 32, position.Y + 32);

            //kamra rörelserna
            transform = Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0)) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom, Zoom, 0) * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
        }
    }
}
