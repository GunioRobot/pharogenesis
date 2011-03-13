addDolly: delta
	| camera new |
	camera := scene defaultCamera.
	new := camera position - (camera direction * delta).
	camera target = new ifFalse: [
		camera position: new].
	"new := camera direction * delta.
	camera position: camera position - new.
	camera target: camera target - new."
	self updateHeadlight.
	self changed.