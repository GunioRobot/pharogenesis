for: anActor from: position
	"Create a new UndoPositionChange instance using position as the original position"

	^ self new setActor: anActor andOriginalPosition: position.
