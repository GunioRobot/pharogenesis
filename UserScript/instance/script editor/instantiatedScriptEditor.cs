instantiatedScriptEditor
	"return the current script editor, creating it if necessary"
	self isAnonymous ifTrue:
		[currentScriptEditor _ ScriptEditorMorph new playerScripted: player].

	self isTextuallyCoded ifTrue: [
			"path thought not to be reached now"
			^ player costume pasteUpMorph scriptorForTextualScript: selector ofPlayer: player].

	currentScriptEditor ifNil:
		[currentScriptEditor _ (player class includesSelector: selector) 
			ifTrue: [ScriptEditorMorph new 
				fromExistingMethod: selector 
				forPlayer: player]
			ifFalse: [ScriptEditorMorph new
				setMorph: player costume
				scriptName: selector].
		status == #ticking ifTrue: [player costume arrangeToStartStepping]].
	
	^ currentScriptEditor