instantiatedScriptEditor
	"Return the current script editor, creating it if necessary"

	| aPlayer |
	(currentScriptEditor == nil or: [currentScriptEditor == #textuallyCoded]) ifTrue:
		[aPlayer _ playerClass someInstance.
		currentScriptEditor _ ScriptEditorMorph new
				setMorph: aPlayer costume
				scriptName: selector.
		self isTextuallyCoded ifTrue:
			[currentScriptEditor showSourceInScriptor].
		defaultStatus == #ticking ifTrue:
			[aPlayer costume arrangeToStartStepping]].
	
	^ currentScriptEditor