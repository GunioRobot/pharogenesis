makeAnonymousScriptsPermanent
	"ScriptingSystem makeAnonymousScriptsPermanent"

	ScriptEditorMorph allSubInstances do: [:m | 
		m playerScripted ifNotNil: [m isAnonymous ifTrue: [m modernizeScript]]]