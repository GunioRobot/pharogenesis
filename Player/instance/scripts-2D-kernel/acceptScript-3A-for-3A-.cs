acceptScript: aScriptEditorMorph for: aSelector
	"Accept the code in the script editor as the code for the given selector"

	self class
		compileUnlogged: aScriptEditorMorph methodString
		classified: 'scripts'
		notifying: nil.
	self class atSelector: aSelector putScriptEditor: aScriptEditorMorph