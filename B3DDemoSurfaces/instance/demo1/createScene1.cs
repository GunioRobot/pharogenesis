createScene1

	| camera |

	camera _ B3DCamera new.
	camera position: 20@0@20.
	camera fov: 12.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene1: scene;
          createLightsForScene1: scene.

	camera target: scene boundingBox center.
