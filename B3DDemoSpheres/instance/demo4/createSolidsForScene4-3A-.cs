createSolidsForScene4: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.

	scene objects add: sceneObj.