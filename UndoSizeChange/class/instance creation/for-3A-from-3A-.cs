for: anActor from: size
	"Create a new UndoSizeChange instance using size as the original size"

	^ self new setActor: anActor andOriginalSize: size.
