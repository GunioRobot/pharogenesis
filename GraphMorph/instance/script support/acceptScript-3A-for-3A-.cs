acceptScript: aScriptEditorMorph for: ignored

	lastAcceptedScript _ aScriptEditorMorph.
	self world model class
		compile: lastAcceptedScript methodString
		classified: 'scripts'
		notifying: nil.
