createScene4

	| camera |

	camera _ B3DCamera new.
	camera position: 20@0@20.
	camera fov: 16.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene4: scene;
          createLightsForScene4: scene.

	camera target: scene boundingBox center.