renameScript: oldSelector newSelector: newSelector
	|  oldStatus aUserScript aScriptEditor |
	aUserScript _ self class userScriptForPlayer: self selector: oldSelector.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	oldStatus _ aScriptEditor scriptInstantiation status.
	aScriptEditor renameScript: newSelector.
	aScriptEditor bringUpToDate.
	self class removeScriptNamed: oldSelector.
	self class atSelector: newSelector putScriptEditor: aScriptEditor.
	aScriptEditor scriptInstantiation status: oldStatus.
	self actorState instantiatedUserScriptsDictionary removeKey: oldSelector.
	self updateAllViewersAndForceToShow: 'scripts'
