for: anActor from: aVisibility
	"Create a new UndoVisibilityChange instance using aVisibility as the original visibility"

	^ super new setActor: anActor andOriginalVisibility: aVisibility.
