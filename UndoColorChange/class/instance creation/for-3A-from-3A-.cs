for: anActor from: aColor
	"Create a new UndoColorChange instance using aColor as the original color"

	^ self new setActor: anActor andOriginalColor: aColor.
