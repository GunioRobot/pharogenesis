removeScriptNamed: aScriptName
	aScriptName ifNotNil:
		[scripts removeKey: aScriptName.
		self removeSelector: aScriptName]