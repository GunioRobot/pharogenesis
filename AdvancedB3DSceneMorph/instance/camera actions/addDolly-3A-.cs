addDolly: delta
	| camera new |
	camera := scene defaultCamera.
	new := camera position - (camera direction * delta).
	camera target = new ifFalse: [
		camera position: new].
	self updateHeadlight.
	self changed.