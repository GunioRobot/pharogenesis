pacifyScript: aSymbol
	| editor aHandler aUserScript |
	aUserScript _ self class userScriptForPlayer: self selector: aSymbol.
	aUserScript ifNil: [self flag: #deferred.  ^ self beep].  "Maddeningly, without this line here the thing IS nil and the debugger is in a bad state"
	editor _ aUserScript instantiatedScriptEditor.
	editor scriptInstantiation status: #normal.
	self actorState instantiatedUserScriptsDictionary removeKey: aSymbol.

	(aHandler _ costume renderedMorph eventHandler) ifNotNil:
		[aHandler forgetDispatchesTo: aSymbol]