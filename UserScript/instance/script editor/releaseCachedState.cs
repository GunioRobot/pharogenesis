releaseCachedState
	"release all non-showing scriptors.  What do we do about versions????"

	currentScriptEditor ifNil: [^ self].
	true ifTrue: [^ self].	"<<< to test the reconstruction of scripts, change to false"
	currentScriptEditor world ifNil: ["not showing"
		currentScriptEditor _ nil].

