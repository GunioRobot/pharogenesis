createSolidsForScene3: aScene

	| sceneObj mat |

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.
     sceneObj texture: (self colorTilesWith: (Color r: 0.0 g: 0.8 b: 0.0)
                                and: (Color r: 0.0 g: 0.55 b: 0.0)). 
     mat := B3DMaterial new.
	mat ambientPart: (Color gray: 0.99).  " this is suitable for ambient light of all colors. "
							" change the ambient part to see how this property works
							  together with the color of the ambient light. "

	sceneObj material: mat.

	scene objects add: sceneObj.
