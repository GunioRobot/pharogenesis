removeScriptNamed: aScriptName
	aScriptName ifNotNil:
		[scripts removeKey: aScriptName.
		self removeSelectorUnlogged: aScriptName]