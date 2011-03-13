actuallyDestroyScript
	"Carry out the actual destruction of the associated script."

	| aHandler itsCostume |
	self delete.
	playerScripted class removeScriptNamed: scriptName.
	playerScripted actorState instantiatedUserScriptsDictionary removeKey: scriptName ifAbsent: [].
		"not quite enough yet in the multiple-instance case..."
	itsCostume _ playerScripted costume.
	(aHandler _ itsCostume renderedMorph eventHandler) ifNotNil:
		[aHandler forgetDispatchesTo: scriptName].
	itsCostume removeActionsSatisfying: [ :act | act receiver == playerScripted and: [ act selector == scriptName ]].
	itsCostume currentWorld removeActionsSatisfying: [ :act | act receiver == playerScripted and: [ act selector == scriptName ]].
	playerScripted updateAllViewersAndForceToShow: ScriptingSystem nameForScriptsCategory