createScene6

	| camera |

	camera _ B3DCamera new.
	camera position: 0@0@-100.
	camera target: 0@0@0.
	camera fov: 4.5.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene6: scene;
          createLightsForScene6: scene.