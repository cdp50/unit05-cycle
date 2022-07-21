using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A second long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake2 : Actor
    {
        private List<Actor> segments2 = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Snake2()
        {
            PrepareBody2();
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody2()
        {
            return new List<Actor>(segments2.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead2()
        {
            return segments2[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments2()
        {
            return segments2;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail2(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments2.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.ORANGE);
                segments2.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments2)
            {
                segment.MoveNext();
            }

            for (int i = segments2.Count - 1; i > 0; i--)
            {
                Actor trailing = segments2[i];
                Actor previous = segments2[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead2(Point direction)
        {
            segments2[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody2()
        {
            int x = Constants.MAX_X * 3 / 4;
            int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? Constants.ORANGE : Constants.ORANGE;

                Actor segment2 = new Actor();
                segment2.SetPosition(position);
                segment2.SetVelocity(velocity);
                segment2.SetText(text);
                segment2.SetColor(color);
                segments2.Add(segment2);
            }
        }
    }
}