createScene3

	| camera |

	camera _ B3DCamera new.
	camera position: 0@0@-6.
	camera target: 0@0@0.
	camera fov: 15.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene3: scene;
          createLightsForScene3: scene.