pacifyScript: aSymbol
	"Make sure the script represented by the symbol doesn't do damage by lingering in related structures on the morph side"

	| editor aHandler aUserScript |
	aUserScript _ self class userScriptForPlayer: self selector: aSymbol.
	aUserScript ifNil: [self flag: #deferred.  ^ self beep].  
	"Maddeningly, without this line here the thing IS nil and the debugger is in a bad state
	(the above note dates from 1/12/99 ?!"

	editor _ aUserScript instantiatedScriptEditor.
	editor scriptInstantiation status: #normal.
	self class allInstancesDo:
		[:aPlayer | aPlayer actorState instantiatedUserScriptsDictionary removeKey: aSymbol.

		(aHandler _ aPlayer costume renderedMorph eventHandler) ifNotNil:
			[aHandler forgetDispatchesTo: aSymbol]]