clearAll
	"Reset this StarSqueak world. All patch variables are cleared, all turtles are removed, and all demons are turned off."

	patchVariables _ Dictionary new: 10.
	patchVariableToDisplay _ nil.
	logPatchVariableScale _ 0.
	patchForm _ Form extent: (dimensions * pixelsPerPatch) depth: 32.
	self createPatchFormGetterAndSetter.
	patchVarDisplayForm _ nil.
	self clearPatches.
	turtles _ #().
	turtleDemons _ #().
	worldDemons _ #().
	sniffRange _ 1.
	lastTurtleID _ -1.
	generation _ 0.
	running _ false.
	stepTime _ 0.  "full speed"
	turtlesAtPatchCache _ nil.
	turtlesAtPatchCacheValid _ false.
