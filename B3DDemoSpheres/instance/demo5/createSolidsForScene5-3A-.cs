createSolidsForScene5: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.
     sceneObj texture: (self colorTilesWith: (Color r: 0.8 g: 0.8 b: 0.8)
                                and: (Color r: 0.9 g: 0.9 b: 0.9)). 

     mat := B3DMaterial new.
	mat shininess: 0.9;
          specularPart: (Color gray: 0.99). 

	sceneObj material: mat.

	scene objects add: sceneObj.