clearAll
	"Reset this StarSqueak world. All patch variables are cleared, all turtles are removed, and all demons are turned off."

	patchVariables := Dictionary new: 10.
	patchVariableToDisplay := nil.
	logPatchVariableScale := 0.
	patchForm := Form extent: (dimensions * pixelsPerPatch) depth: 32.
	self createPatchFormGetterAndSetter.
	patchVarDisplayForm := nil.
	self clearPatches.
	turtles := #().
	turtleDemons := #().
	worldDemons := #().
	sniffRange := 1.
	lastTurtleID := -1.
	generation := 0.
	running := false.
	stepTime := 0.  "full speed"
	turtlesAtPatchCache := nil.
	turtlesAtPatchCacheValid := false.
