createSolidsForScene6: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.7 y: 0.7 z: 0.7)).
	scene objects add: sceneObj.

	sceneObj _ B3DSceneObject named: 'Sphere2'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.
     sceneObj geometry transformBy: (B3DMatrix4x4 identity setScale: (B3DVector3 x: 0.5 y: 0.5 z: 0.5)).
     sceneObj geometry translateBy: (B3DVector3 x: 1.0  y: 0.5  z: 1.0).

	scene objects add: sceneObj.