createSolidsForScene9: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 0.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 3.0  z: 0.0).
	scene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Stick1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateCylinderFaces) asIndexedMesh.
     sceneObj texture: self gradientTexture.
     mat := B3DMaterial new.
	mat emission: (Color lightGray);
          shininess: 0.7;
         diffusePart: ("Color gray: 0.25" Color r: 0.6 g: 0.1 b: 0.7).
	mat ambientPart: (Color r:0.4 g: 0.7 b: 0.3).
	sceneObj material: mat.
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.1 y: 1.5 z: 0.1)).
     sceneObj geometry translateBy: (B3DVector3 x: 0.0  y: 1.5  z: 0.0). 

	scene objects add: sceneObj.


	sceneObj _ B3DSceneObject named: 'Sphere2'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.7 y: 0.7 z: 0.7)).

	scene objects add: sceneObj.