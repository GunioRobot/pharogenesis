createDefaultScene
	| sceneObj camera |
	sceneObj _ B3DSceneObject named: 'Sample Cube'.
	sceneObj geometry: (B3DBox from: (-0.7@-0.7@-0.7) to: (0.7@0.7@0.7)).
	camera _ B3DCamera new.
	camera position: 0@0@-1.5.
	self extent: 100@100.
	scene _ B3DScene new.
	scene defaultCamera: camera.
	scene objects add: sceneObj.