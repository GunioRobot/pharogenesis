createSolidsForScene2: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Stick1'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat  shininess: 0.8;
          ambientPart: (Color r: 0.3 g: 0.04 b: 0.0);
          specularPart: (Color r: 0.8 g: 0.3 b: 0.1). 

	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 1.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: 2.0).

	scene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Stick2'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat  shininess: 0.9;
          ambientPart: (Color r: 0.0 g: 0.3 b: 0.04);
          specularPart: (Color r: 0.1 g: 0.8 b: 0.3). 
	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 3.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: 0.0). 

	scene objects add: sceneObj.


	sceneObj _ B3DSceneObject named: 'Stick3'.
	sceneObj geometry: self createStick.
     mat := B3DMaterial new.
	mat  shininess: 0.8;
          ambientPart: (Color r: 0.05 g: 0.0 b: 0.3);
          specularPart: (Color r: 0.3 g: 0.1 b: 0.8). 
	
	sceneObj material: mat.
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.0  z: 0.0).
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 2.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 2.0  y: -4.0  z: -2.0). 

	scene objects add: sceneObj.
