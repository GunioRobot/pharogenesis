addFovAngle: delta
	| camera new |
     scene isNil ifTrue: [^self].
	camera := scene defaultCamera.
	new := camera fov + delta.
	0 < new ifTrue: [
		camera fov: new].
	self changed.