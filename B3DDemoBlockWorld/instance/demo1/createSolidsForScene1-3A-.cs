createSolidsForScene1: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Stick1'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat ambientPart: (Color gray: 0.99).  " this is suitable for ambient light of all colors. "
							" change the ambient part to see how this property works
							  together with the color of the ambient light. "

	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 1.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: 2.0).

	scene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Stick2'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat emission: (Color r: 0.8 g: 0.6 b: 0.3);
          shininess: 0.7;
         diffusePart: ("Color gray: 0.25" Color r: 0.6 g: 0.3 b: 0.7).
	mat ambientPart: (Color r:0.4 g: 0.4 b: 0.3).
	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 3.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: 0.0). 

	scene objects add: sceneObj.


	sceneObj _ B3DSceneObject named: 'Stick3'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat emission: (Color r:0.5 g: 0.1 b: 0.2);
          shininess: 0.3;
         diffusePart: ("Color gray: 0.25" Color r: 0.6 g: 0.3 b: 0.7).
	mat ambientPart: (Color r:0.4 g: 0.4 b: 0.3).
	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 2.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: -2.0). 

	scene objects add: sceneObj.
