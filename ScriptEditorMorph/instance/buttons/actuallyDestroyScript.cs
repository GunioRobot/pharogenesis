actuallyDestroyScript
	| aHandler |

	self delete.
	playerScripted class removeScriptNamed: scriptName.
	playerScripted actorState instantiatedUserScriptsDictionary removeKey: scriptName.
		"not quite enough yet in the multiple-instance case..."
	(aHandler _ playerScripted costume renderedMorph eventHandler) ifNotNil:
		[aHandler forgetDispatchesTo: scriptName].
	playerScripted updateAllViewersAndForceToShow: 'scripts'