createScene2

	| camera |

	camera _ B3DCamera new.
	camera position: 10@0@10.
	camera target: 2@0@0.
	camera fov: 12.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene2: scene;
          createLightsForScene2: scene.