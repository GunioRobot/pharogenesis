createScene1
  
	| sceneObj camera mat |

	camera _ B3DCamera new.
	camera position: 0@0@-6.
	camera target: 0@0@0.
	camera fov: 15.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

	sceneObj _ B3DSceneObject named: 'Sphere1'.
	sceneObj geometry: (B3DSimpleMesh withAll: B3DIndexedMesh vrmlCreateSphereFaces) asIndexedMesh.
     mat := B3DMaterial new.
	mat emission: Color yellow.  "remove this line tto get a black sphere. "
	sceneObj material: mat.

	scene objects add: sceneObj.