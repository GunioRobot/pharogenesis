createScene10

	| camera |

	camera _ B3DCamera new.
	camera position: 0@0@25.
	camera target: 0@0@0.
	camera fov: 9.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene10: scene;
          createLightsForScene10: scene.