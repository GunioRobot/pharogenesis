descriptionScene4

  ^'A single white sphere is shown in the light of three directed lights of different color.

Proposals for further work:
You should now be able to add (in method createLightsForScene4:) an ambient white light. When you do only that, you will notice no difference in the scene. To see a difference, you will have to add an additional ambient part to the material of the sphere. This has to be be done in method createSolidsForScene4:. Add this statement:

mat ambientPart: (Color gray: 0.2)

It is instructive to vary the argument of message ''gray:'' and to observe the effect. Try to forecast what you will see. (B3DDemoSpheres>>demo4a shows that exercise.)'