createScene9

	| camera |

	camera _ B3DCamera new.
	camera position: 0@0@25.
	camera target: 0@0@0.
	camera fov: 9.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene9: scene;
          createLightsForScene9: scene.