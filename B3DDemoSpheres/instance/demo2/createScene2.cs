createScene2

	| sceneObj camera mat |

	camera _ B3DCamera new.
	camera position: 0@0@-6.
	camera target: 0@0@0.
	camera fov: 15.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.
     sceneObj texture: (self colorTilesWith: (Color r: 0.0 g: 0.8 b: 0.0)
                                and: (Color r: 0.0 g: 0.55 b: 0.0)). 
     mat := B3DMaterial new.
	mat emission: Color yellow.  "  a red light would show a black sphere "
	sceneObj material: mat.

	scene objects add: sceneObj.
