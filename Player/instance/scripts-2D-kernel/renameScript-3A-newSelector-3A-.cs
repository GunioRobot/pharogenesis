renameScript: oldSelector newSelector: newSelector
	"Rename the given script to have the new selector"

	|  aUserScript aScriptEditor anInstantiation |
	aUserScript _ self class userScriptForPlayer: self selector: oldSelector.
	aScriptEditor _ aUserScript instantiatedScriptEditor.
	aScriptEditor renameScriptTo: newSelector.
	aUserScript bringUpToDate.
	self class removeScriptNamed: oldSelector.
	self class atSelector: newSelector putScriptEditor: aScriptEditor.
	self class allSubInstancesDo:
		[:aPlayer |
			anInstantiation _ aPlayer scriptInstantiationForSelector: oldSelector.
			anInstantiation changeSelectorTo: newSelector.
			aPlayer costume actorState instantiatedUserScriptsDictionary
				removeKey: oldSelector;
				at: newSelector put: anInstantiation.
			anInstantiation assureEventHandlerRepresentsStatus].
	
	self updateAllViewersAndForceToShow: 'scripts'
