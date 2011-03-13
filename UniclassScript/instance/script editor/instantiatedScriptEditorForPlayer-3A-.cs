instantiatedScriptEditorForPlayer: aPlayer
	"Return the current script editor, creating it if necessary"

	currentScriptEditor ifNil:
		[currentScriptEditor _ (playerClass includesSelector: selector) 
			ifTrue: [ScriptEditorMorph new 
				fromExistingMethod: selector 
				forPlayer: aPlayer]
			ifFalse: [ScriptEditorMorph new
				setMorph: aPlayer costume
				scriptName: selector].
		defaultStatus == #ticking ifTrue:
			[aPlayer costume arrangeToStartStepping]].
	
	^ currentScriptEditor