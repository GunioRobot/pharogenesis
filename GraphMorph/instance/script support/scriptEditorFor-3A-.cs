scriptEditorFor: ignored

	(lastScriptEditor ~= nil and: [lastScriptEditor isInWorld])
		ifTrue: [^ lastScriptEditor].

	lastAcceptedScript = nil ifTrue: [
		^ lastScriptEditor _ ScriptEditorMorph new
			setMorph: self
			scriptName: 'ProcessSamples'.
	] ifFalse: [
		^ lastScriptEditor _ lastAcceptedScript fullCopy].
