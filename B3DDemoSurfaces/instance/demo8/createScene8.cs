createScene8

	| camera |

	camera _ B3DCamera new.
	camera position: 0@0@-50.
	camera target: 0@0@0.
	camera fov: 2.5.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene8: scene;
          createLightsForScene8: scene.