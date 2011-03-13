initialize
	"Initialize the receiver to refer to only the background controller."
	| screenView |
	screenController := ScreenController new.
	screenView := FormView new.
	screenView model: (InfiniteForm with: Color gray) controller: screenController.
	screenView window: Display boundingBox.
	scheduledControllers := OrderedCollection with: screenController