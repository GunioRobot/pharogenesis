descriptionScene1

  ^'Two intersecting surfaces are drawn. Both surfaces are drawn with textures. A white ambient light is used to illuminate the scene. (White light was choosen to ensure that the textures are displayed with their true colors. Use of colored light would change the texture colors.)
In the presence of ambient light we do not need to add materials to the surfaces.
Equations of the surfaces:
(1 - sin(x))*(2 - cos(2*y))/2
(2 + sin(x))*(1 + cos(2*y))/2

The example uses textures with only four colored fields. To cover the entire  surface, the texture is continued. 
In method createScene1  the statement
camera target: scene boundingBox center.
causes the camera to look at the center of the scene.'