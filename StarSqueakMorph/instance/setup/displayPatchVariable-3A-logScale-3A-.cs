displayPatchVariable: patchVarName logScale: logBase2OfScaleFactor
	"Make this StarSqueak world display the patch variable of the given name. Only one patch variable can be displayed at any given time. Values are scaled by 2^logBase2OfScaleFactor. For example, a value of 5 scales by 32 and a value of -2 scales by 1/4."

	(patchVariables includesKey: patchVarName) ifFalse: [
		patchVariableToDisplay := nil.
		patchVarDisplayForm := nil.
		^ self].
	patchVariableToDisplay := patchVarName.
	patchVarDisplayForm := Form extent: (dimensions * pixelsPerPatch) depth: 32.
	logPatchVariableScale := logBase2OfScaleFactor.
	self clearPatches.

