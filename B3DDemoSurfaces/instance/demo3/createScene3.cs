createScene3

	| camera |

	camera _ B3DCamera new.
	camera position: 20@0@20.
	camera fov: 12.0.

	scene _ B3DScene new.
	scene defaultCamera: camera.

     self createSolidsForScene3: scene;
          createLightsForScene3: scene.

	camera target: scene boundingBox center.