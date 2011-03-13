removeScriptingControls
	| toClobber |
	toClobber _ self submorphs select: [:m | m hasProperty: #scriptingControl].
	toClobber do: [:m | m delete].