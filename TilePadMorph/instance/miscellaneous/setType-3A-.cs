setType: aSymbol

	type _ aSymbol.
	self color: (ScriptingSystem colorForType: type).
	self extent: (self basicWidth @ TileMorph defaultH)
