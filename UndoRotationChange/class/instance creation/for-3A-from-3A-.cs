for: anActor from: rotation
	"Create a new UndoRotationChange instance using rotation as the original rotation"

	^ self new setActor: anActor andOriginalRotation: rotation.
