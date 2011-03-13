clearAll
	"Reset this StarSqueak world. All patch variables are cleared, all turtles are removed, and all demons are turned off."

	patchVarDisplayForm _ Form extent: dimensions depth: 32.
	self initializePatch.
	self recreateMagnifiedDisplayForm.
	self initializeTurtlesDict.

	turtleCount _ 0.
	lastTurtleID _ 0.

	self color: Color black.

