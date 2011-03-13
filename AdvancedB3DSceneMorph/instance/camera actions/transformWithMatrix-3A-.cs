transformWithMatrix: matrix
	| camera |
	camera := scene defaultCamera.
	camera position: (matrix localPointToGlobal: camera position).
	camera up: (matrix localPointToGlobal: camera up).
	self updateHeadlight.
	self changed.