addFovAngle: delta
	| camera new |
	camera := scene defaultCamera.
	new := camera fov + delta.
	0 < new ifTrue: [
		camera fov: new].
	self updateHeadlight.
	self changed.