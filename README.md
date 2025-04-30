# Flappy Bird

By Ilya Vaschillo

Date: 4/14/25

[https://manyak404.github.io/FlappyBird/](https://manyak404.github.io/FlappyBird/)

**CONTROLS: SPACE TO JUMP**

# Flappy Bird

*   Spent time making adjustments to gravity and flap physics to make the jump feel not to floaty and not to heavy. Helped using the pause feature and make slight edits in editor because they were unsaved
*   Imported asset as a child sprite render object to the rest of the flappy bird object. That way I could move the gameobject with simple code and rotate sprite separately without affecting up, right vectors in original objects transform.
*   Made sure flappy bird didn’t leave the camera view using viewport.

# Background

*   ASSET WAS NOT MY OWN. Scrolling background effect was made using two of the same asset. The asset itself was chosen to look good next to itself.
*   Manager object helped move backgrounds to always appear behind bird when the camera was not looking at them.

# Pipes

*   Prefabs of size 1. Simple assets so I could scale to fit the randomly generating gaps.
*   Selected a random y value every constant time increment to be the location flappy bird needs to fly through.
*   Two pipe prefabs were scaled around the gap to form hoops for the bird to fly though, had colliders to kill flappy bird if he misses.

All in all, I learned how to use my own assets and how to import pixel assets, as well as how to make iterative changes in editor to test slight changes to movement script. It took me around 6 hours to complete the program. The most challenging part was spawning pipes in a random way but also so the player could always get through the gap.
