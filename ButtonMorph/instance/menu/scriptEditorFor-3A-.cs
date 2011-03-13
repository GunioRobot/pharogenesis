scriptEditorFor: ignored

	(lastScriptEditor ~= nil and: [lastScriptEditor isInWorld])
		ifTrue: [^ lastScriptEditor].

	lastAcceptedScript = nil ifTrue: [
		^ lastScriptEditor _ ScriptEditorMorph new
			setMorph: self
			scriptName: 'ButtonUp'.
	] ifFalse: [
		^ lastScriptEditor _ lastAcceptedScript fullCopy].
